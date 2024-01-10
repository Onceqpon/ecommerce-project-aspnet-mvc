using ProjektASPNET.Data.Enums;
using ProjektASPNET.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjektASPNET.Data.ViewModel
{
    public class NewProductVM
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa produktu")]
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string Name { get; set; }

        [Display(Name = "Krótki opis produktu")]
        [Required(ErrorMessage = "Krótki opis jest wymagana")]
        public string ShortDescription { get; set; }

        [Display(Name = "Opis produktu")]
        [Required(ErrorMessage = "Opis jest wymagana")]
        public string Description { get; set; }

        [Display(Name = "Cena produktu")]
        [Required(ErrorMessage = "Cena jest wymagana")]
        public double Price { get; set; }

        [Display(Name = "Zdjęcie produktu")]
        [RegularExpression(@"^(http|https)://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(/\S*)?$", ErrorMessage = "Pole Logo Producenta musi być poprawnym URL-em HTTP lub HTTPS.")]
        [Required(ErrorMessage = "Zdjęcie jest wymagana")]
        public string ImageURL { get; set; }

        [Display(Name = "Rok produkcji")]
        [Required(ErrorMessage = "Rok produkcji jest wymagana")]
        public int ReleaseYear { get; set; }

        [Display(Name = "Kategoria produktu")]
        [Required(ErrorMessage = "Kategoria jest wymagana")]
        public ProductCategory ProductCategory { get; set; }

        [Display(Name = "Dostępność produktu")]
        [Required(ErrorMessage = "Dostępne sztuki są wymagana")]
        public int AvaibleParts { get; set; }

        //Manufakturer
        [Display(Name = "Producent produktu")]
        [Required(ErrorMessage = "Producent jest wymagana")]
        public int ManufacturerId { get; set; }
    }
}
