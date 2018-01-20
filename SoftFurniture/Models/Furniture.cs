using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SofFurniture.Models
{
    public class Furniture
    {
        [Key]
        public int Id { get; set; }
        public string Model { get; set; }
        public float Price { get; set; }

        public virtual ICollection<Characteristic> Characteristics { get; set; }
    }
}