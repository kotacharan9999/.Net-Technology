using Practical10.Models;

namespace Practical10.Services;

public class StudentService
{
    private readonly List<Student> _students =
    [
        new Student { Id = 1, Name = "Rahul Sharma", Department = "Computer Science", Email = "rahul@example.com", Company = "TCS", Package = 4.5m },
        new Student { Id = 2, Name = "Priya Patel", Department = "Information Technology", Email = "priya@example.com", Company = "Infosys", Package = 5.2m },
        new Student { Id = 3, Name = "Kiran Reddy", Department = "Artificial Intelligence", Email = "kiran@example.com", Company = "Wipro", Package = 6.0m }
    ];

    private int _nextId = 4;
    private readonly object _lock = new();

    public List<Student> GetAll()
    {
        lock (_lock)
            return _students.Select(Clone).ToList();
    }

    public Student? GetById(int id)
    {
        lock (_lock)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            return student is null ? null : Clone(student);
        }
    }

    public Student Add(Student student)
    {
        lock (_lock)
        {
            student.Id = _nextId++;
            var saved = Clone(student);
            _students.Add(saved);
            return Clone(saved);
        }
    }

    public bool Update(int id, Student updatedStudent)
    {
        lock (_lock)
        {
            var existing = _students.FirstOrDefault(s => s.Id == id);
            if (existing is null) return false;

            existing.Name = updatedStudent.Name;
            existing.Department = updatedStudent.Department;
            existing.Email = updatedStudent.Email;
            existing.Company = updatedStudent.Company;
            existing.Package = updatedStudent.Package;
            return true;
        }
    }

    public bool Delete(int id)
    {
        lock (_lock)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student is null) return false;
            _students.Remove(student);
            return true;
        }
    }

    private static Student Clone(Student s) => new()
    {
        Id = s.Id,
        Name = s.Name,
        Department = s.Department,
        Email = s.Email,
        Company = s.Company,
        Package = s.Package
    };
}
