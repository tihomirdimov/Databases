namespace _20161119.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Anomaly
    {
        public Anomaly()
        {
            this.Victims = new HashSet<Person>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public int? OriginPlanetId { get; set; }
        [Required]
        public int? TeleportPlanetId { get; set; }
        [Required]
        public ICollection<Person> Victims { get; set; }
    }
}
