using Microsoft.AspNetCore.SignalR;
using StudentRecord.Models.Entities;

namespace StudentRecord.Models.Data;

public class AppDbContext
{
    private static readonly List<Student> _student = new List<Student>()
    {
        new Student()
            {
                Id = Guid.NewGuid(),
                Name = "name 1",
                Age = 15,
            },
            new Student()
            {
                 Id = Guid.NewGuid(),
                Name = "name 2",
                Age = 20,
            },
             new Student()
            {
                Id = Guid.NewGuid(),
                Name = "name 3",
                Age = 25,
            }
    };
    public  void AddStudent(Student student)
    {
        _student.Add(student);
    }
    public  void UpdateStudent(Student student)
    {
        foreach (var stu in _student)
        {
            if (stu.Id == student.Id)
            {
               stu.Name =  student.Name;
               stu.Age = student.Age;
                break;
            }
        }

    }
    public void RemoveStudent(Student student)
    {
        _student.Remove(student);
    }

    public Student GetStudent(Guid id)
    {
        return _student .FirstOrDefault(s => s.Id == id);
    }
    public List<Student> GetStudents()
    {
        return _student;
    }
    public List<Student> Students { get; set; } = _student;

}
