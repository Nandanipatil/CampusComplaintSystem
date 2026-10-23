using System.ComponentModel.DataAnnotations;

namespace CampusComplaintSystem.Models
{
    public class Complaint
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; } = string.Empty; // e.g. Hostel, Academics, Infrastructure

        public string Status { get; set; } = "Pending"; // Pending, In Progress, Resolved

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}