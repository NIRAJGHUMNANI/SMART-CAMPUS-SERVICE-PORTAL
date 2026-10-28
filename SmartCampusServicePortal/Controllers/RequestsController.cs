using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCampusServicePortal.Data;
using SmartCampusServicePortal.Models;

namespace SmartCampusServicePortal.Controllers;

public class RequestsController(CampusDbContext db) : Controller
{
    public async Task<IActionResult> Index() => View(await db.ServiceRequests.OrderByDescending(r => r.CreatedAt).ToListAsync());

    public IActionResult Create() => View(new ServiceRequest());

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ServiceRequest request)
    {
        if (!ModelState.IsValid) return View(request);
        request.Status = "Pending";
        request.CreatedAt = DateTime.Now;
        db.ServiceRequests.Add(request);
        await db.SaveChangesAsync();
        TempData["Message"] = "Service request submitted successfully.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateStatus(int id, string status)
    {
        var allowed = new[] { "Pending", "In Progress", "Completed" };
        var request = await db.ServiceRequests.FindAsync(id);
        if (request is null || !allowed.Contains(status)) return NotFound();
        request.Status = status;
        await db.SaveChangesAsync();
        TempData["Message"] = "Request status updated.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var request = await db.ServiceRequests.FindAsync(id);
        if (request is not null) { db.ServiceRequests.Remove(request); await db.SaveChangesAsync(); }
        return RedirectToAction(nameof(Index));
    }
}
