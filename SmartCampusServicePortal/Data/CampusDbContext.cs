using Microsoft.EntityFrameworkCore;
using SmartCampusServicePortal.Models;

namespace SmartCampusServicePortal.Data;

public class CampusDbContext(DbContextOptions<CampusDbContext> options) : DbContext(options)
{
    public DbSet<ServiceRequest> ServiceRequests => Set<ServiceRequest>();
}
