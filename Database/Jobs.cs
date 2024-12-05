using System.ComponentModel.DataAnnotations;

namespace TuyenDungTopIT.Models
{
    public class Jobs
    {
        [Key]
        public int JobId { get; set; } // Primary Key
        public string Title { get; set; }
        public string Description { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public float Salary { get; set; }
        public DateTime PostedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
