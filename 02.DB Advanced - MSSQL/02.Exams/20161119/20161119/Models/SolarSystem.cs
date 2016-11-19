namespace _20161119.Models
{
    using System.ComponentModel.DataAnnotations;
    public class SolarSystem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
