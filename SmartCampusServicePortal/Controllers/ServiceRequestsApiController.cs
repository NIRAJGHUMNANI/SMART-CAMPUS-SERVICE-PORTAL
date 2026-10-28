using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCampusServicePortal.Data;
using SmartCampusServicePortal.Models;

namespace SmartCampusServicePortal.Controllers;

[ApiController]
[Route("api/requests")]
public class ServiceRequestsApiController(CampusDbContext db) : ControllerBase
{
    // GET /api/requests - returns all service requests as JSON
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServiceRequest>>> GetAll() =>
        await db.ServiceRequests.OrderByDescending(r => r.CreatedAt).ToListAsync();

    // GET /api/requests/1 - returns one request
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ServiceRequest>> GetById(int id)
    {
        var request = await db.ServiceRequests.FindAsync(id);
        return request is null ? NotFound() : Ok(request);
    }

    // POST /api/requests - creates a request from JSON
    [HttpPost]
    public async Task<ActionResult<ServiceRequest>> Create(ServiceRequest request)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        request.Id = 0;
        request.Status = "Pending";
        request.CreatedAt = DateTime.Now;
        db.ServiceRequests.Add(request);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = request.Id }, request);
    }
}
