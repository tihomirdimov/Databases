using System.ComponentModel.DataAnnotations;

namespace _20161119.Models
{
    public class Star
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? SolarSystemId { get; set; }
    }
}
