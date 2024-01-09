using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using ProjektASPNET.Data.Base;
using ProjektASPNET.Data.Enums;

namespace ProjektASPNET.Models
{
    public class Product : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string ImageURL { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        [Required]

        public ProductCategory ProductCategory { get; set; }
        [Required]
        public int AvaibleParts { get; set; }

        //Manufakturer
        public int ManufacturerId { get; set; }
        [ForeignKey("ManufacturerId")]
        public Manufacturer Manufacturer { get; set; }
    }
}
