namespace _20161119.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Planet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? SunId { get; set; }
        public int? SolarSystemId { get; set; }
    }
}
