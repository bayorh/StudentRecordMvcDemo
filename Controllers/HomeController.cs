using Microsoft.AspNetCore.Mvc;
using StudentRecord.Models.Data;
using StudentRecord.Models.Entities;

namespace StudentRecord.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _appDbContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _appDbContext = dbContext;
        }
        public IActionResult Index()
        {
            var students = _appDbContext.GetStudents();
            ViewBag.Count=students.Count();
            return View(students);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            _appDbContext.AddStudent(student);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(Guid id)
        {
            var student = _appDbContext.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        public IActionResult Edit(Guid id)
        {
            var _stud = _appDbContext.GetStudent(id);
            if (_stud == null)
            {
                return NotFound();
            }
            return View(_stud);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            
            if (ModelState.IsValid)
            {
                _appDbContext.UpdateStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }
        public IActionResult Delete(Guid id)
        {
            var student = _appDbContext.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        public IActionResult ConfirmDelete(Student student)
        {
            _appDbContext.RemoveStudent(student);
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View(); 
        }

    }
}
