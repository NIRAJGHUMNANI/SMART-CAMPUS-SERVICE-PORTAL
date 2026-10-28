using System.ComponentModel.DataAnnotations;

namespace SmartCampusServicePortal.Models;

public class ServiceRequest
{
    public int Id { get; set; }

    [Required, StringLength(80)]
    [Display(Name = "Student name")]
    public string StudentName { get; set; } = "";

    [Required]
    public string Category { get; set; } = "IT Support";

    [Required, StringLength(500)]
    public string Description { get; set; } = "";

    public string Status { get; set; } = "Pending";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
