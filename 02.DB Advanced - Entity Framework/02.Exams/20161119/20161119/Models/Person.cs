namespace _20161119.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? HomePlanetId { get; set; }
    }
}
