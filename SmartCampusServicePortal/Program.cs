using Microsoft.EntityFrameworkCore;
using SmartCampusServicePortal.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CampusDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CampusDatabase") ?? "Data Source=campus.db"));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CampusDbContext>();
    db.Database.EnsureCreated();
    if (!db.ServiceRequests.Any())
    {
        db.ServiceRequests.AddRange(
            new SmartCampusServicePortal.Models.ServiceRequest { StudentName = "Aarav Patel", Category = "IT Support", Description = "Wi-Fi is not connecting in the library.", Status = "Pending" },
            new SmartCampusServicePortal.Models.ServiceRequest { StudentName = "Diya Shah", Category = "Maintenance", Description = "Classroom projector needs checking.", Status = "In Progress" });
        db.SaveChanges();
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllers();
app.Run();
