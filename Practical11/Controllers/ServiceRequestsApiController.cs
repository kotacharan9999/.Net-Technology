using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practical11.Data;
using Practical11.Models;

namespace Practical11.Controllers;

[ApiController]
[Route("api/servicerequests")]
public class ServiceRequestsApiController : ControllerBase
{
    private readonly CampusDbContext _db;
    public ServiceRequestsApiController(CampusDbContext db) => _db = db;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CampusServiceRequest>>> GetAll() =>
        Ok(await _db.ServiceRequests.AsNoTracking().OrderByDescending(r => r.CreatedAt).ToListAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CampusServiceRequest>> GetById(int id)
    {
        var item = await _db.ServiceRequests.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
        return item is null ? NotFound(new { message = "Request not found." }) : Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<CampusServiceRequest>> Create(CampusServiceRequest request)
    {
        request.Id = 0;
        request.CreatedAt = DateTime.Now;
        request.Status = "Pending";
        _db.ServiceRequests.Add(request);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = request.Id }, request);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, CampusServiceRequest input)
    {
        var item = await _db.ServiceRequests.FindAsync(id);
        if (item is null) return NotFound(new { message = "Request not found." });
        item.StudentName = input.StudentName;
        item.Email = input.Email;
        item.Department = input.Department;
        item.Category = input.Category;
        item.Title = input.Title;
        item.Description = input.Description;
        item.Priority = input.Priority;
        item.Status = input.Status;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _db.ServiceRequests.FindAsync(id);
        if (item is null) return NotFound(new { message = "Request not found." });
        _db.ServiceRequests.Remove(item);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
