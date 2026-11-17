using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Cache;

namespace EF_Core_Sample.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int Age { get; set; }
        [Required]
        public DateOnly DOB { get; set;  }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required,StringLength(15)]
        [Phone]
        public string Phone { get; set; } = string.Empty;
        [Required,StringLength(10,MinimumLength =6)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        public Course? course { get; set; }

    }
}
