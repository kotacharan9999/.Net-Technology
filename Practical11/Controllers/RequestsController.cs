using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practical11.Data;
using Practical11.Models;

namespace Practical11.Controllers;

public class RequestsController : Controller
{
    private readonly CampusDbContext _db;
    public RequestsController(CampusDbContext db) => _db = db;

    public async Task<IActionResult> Index(string? search, string? status)
    {
        var query = _db.ServiceRequests.AsNoTracking().AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(r => r.StudentName.Contains(search) || r.Title.Contains(search) ||
                                     r.Category.Contains(search) || r.Email.Contains(search));
        if (!string.IsNullOrWhiteSpace(status) && status != "All")
            query = query.Where(r => r.Status == status);

        ViewBag.Total = await _db.ServiceRequests.CountAsync();
        ViewBag.Pending = await _db.ServiceRequests.CountAsync(r => r.Status == "Pending");
        ViewBag.InProgress = await _db.ServiceRequests.CountAsync(r => r.Status == "In Progress");
        ViewBag.Resolved = await _db.ServiceRequests.CountAsync(r => r.Status == "Resolved");
        ViewBag.Search = search;
        ViewBag.SelectedStatus = status;
        return View(await query.OrderByDescending(r => r.CreatedAt).ToListAsync());
    }

    public IActionResult Create() => View(new CampusServiceRequest());

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CampusServiceRequest request)
    {
        if (!ModelState.IsValid) return View(request);
        request.Id = 0;
        request.CreatedAt = DateTime.Now;
        request.Status = "Pending";
        _db.ServiceRequests.Add(request);
        await _db.SaveChangesAsync();
        TempData["Success"] = "Your campus service request has been submitted.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var item = await _db.ServiceRequests.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
        return item is null ? NotFound() : View(item);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var item = await _db.ServiceRequests.FindAsync(id);
        return item is null ? NotFound() : View(item);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, CampusServiceRequest input)
    {
        if (id != input.Id) return BadRequest();
        if (!ModelState.IsValid) return View(input);
        var item = await _db.ServiceRequests.FindAsync(id);
        if (item is null) return NotFound();
        item.StudentName = input.StudentName;
        item.Email = input.Email;
        item.Department = input.Department;
        item.Category = input.Category;
        item.Title = input.Title;
        item.Description = input.Description;
        item.Priority = input.Priority;
        await _db.SaveChangesAsync();
        TempData["Success"] = "Request details updated successfully.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateStatus(int id, string status)
    {
        if (!new[] { "Pending", "In Progress", "Resolved" }.Contains(status)) return BadRequest();
        var item = await _db.ServiceRequests.FindAsync(id);
        if (item is null) return NotFound();
        item.Status = status;
        await _db.SaveChangesAsync();
        TempData["Success"] = "Request status updated.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var item = await _db.ServiceRequests.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
        return item is null ? NotFound() : View(item);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var item = await _db.ServiceRequests.FindAsync(id);
        if (item is not null)
        {
            _db.ServiceRequests.Remove(item);
            await _db.SaveChangesAsync();
            TempData["Success"] = "Request deleted.";
        }
        return RedirectToAction(nameof(Index));
    }
}
