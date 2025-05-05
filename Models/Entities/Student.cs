using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace StudentRecord.Models.Entities;

public class Student
{
    [Required]
    public Guid Id { get; init; } = Guid.NewGuid();
    [Required]
    public string Name { get; set; }
    [Required]
    public int Age { get; set; }

    
    public override bool Equals(object? obj) // need this for simulating update in list perfectly
    {
        if (obj is Student s)
            return this.Id == s.Id;
        else
            return false;
    }

}
