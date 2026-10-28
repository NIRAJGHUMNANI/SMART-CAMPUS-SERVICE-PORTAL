using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCampusServicePortal.Data;

namespace SmartCampusServicePortal.Controllers;

public class HomeController(CampusDbContext db) : Controller
{
    public async Task<IActionResult> Index()
    {
        ViewBag.Total = await db.ServiceRequests.CountAsync();
        ViewBag.Pending = await db.ServiceRequests.CountAsync(r => r.Status == "Pending");
        ViewBag.Completed = await db.ServiceRequests.CountAsync(r => r.Status == "Completed");
        ViewBag.Recent = await db.ServiceRequests.OrderByDescending(r => r.CreatedAt).Take(5).ToListAsync();
        return View();
    }
}
