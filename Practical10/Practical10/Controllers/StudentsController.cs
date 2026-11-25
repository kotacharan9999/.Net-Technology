using Microsoft.AspNetCore.Mvc;
using Practical10.Models;
using Practical10.Services;

namespace Practical10.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly StudentService _studentService;

    public StudentsController(StudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Student>> GetAll()
    {
        return Ok(_studentService.GetAll());
    }

    [HttpGet("{id:int}")]
    public ActionResult<Student> GetById(int id)
    {
        var student = _studentService.GetById(id);
        return student is null ? NotFound(new { message = "Student not found." }) : Ok(student);
    }

    [HttpPost]
    public ActionResult<Student> Create(Student student)
    {
        var created = _studentService.Add(student);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Student student)
    {
        return _studentService.Update(id, student)
            ? NoContent()
            : NotFound(new { message = "Student not found." });
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        return _studentService.Delete(id)
            ? NoContent()
            : NotFound(new { message = "Student not found." });
    }
}
