using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SofFurniture.Models
{
    public class Characteristic
    {
        [Key]
        public int Id { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }

        public virtual ICollection<Furniture> Furniture { get; set; }
    }
}