using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace EF_Core_Sample.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Students> Students { get; set; } = new List<Students>();
    }
}
