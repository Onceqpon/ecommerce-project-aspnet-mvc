using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ProjektASPNET.Data.Enums;
using ProjektASPNET.Models;



namespace ProjektASPNET.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();   

                if(!context.Manufacturers.Any())
                {
                    context.Manufacturers.AddRange(new List<Manufacturer>()
                    {
                        new Manufacturer()
                        {
                            Name = "Microsoft",
                            CompanyLogoURL = "https://commons.wikimedia.org/wiki/File:Microsoft_logo.jpg",
                            Description = "Amerykańskie przedsiębiorstwo informatyczne. Najbardziej znane jako producent systemów operacyjnych MS-DOS, Microsoft Windows i oprogramowania biurowego Microsoft Office. Spółka publiczna z siedzibą w Redmond w stanie Waszyngton.",

                        },
                        new Manufacturer()
                        {
                            Name = "Sony",
                            CompanyLogoURL = "https://commons.wikimedia.org/wiki/File:Sony_logos.JPG",
                            Description = "Japoński producent elektroniki użytkowej i zarazem jeden z największych światowych producentów w tej branży, założony 7 maja 1946 roku przez Masaru Ibukę i Akio Moritę w Tokio jako Tokyo Communication Industry.",

                        },
                        new Manufacturer()
                        {
                            Name = "Samsung",
                            CompanyLogoURL = "https://pl.wikipedia.org/wiki/Plik:Logo_samsung_5.jpg",
                            Description = "Grupa biznesowa Samsung to potężny konglomerat, działający w przemyśle elektronicznym, samochodowym, chemicznym, lotniczym, tekstylnym, spożywczym, a także w hotelarstwie, handlu, parkach rozrywki oraz projektowaniu i budowaniu wysokościowców. Swoją siedzibę ma w mieście Suwon, potocznie zwanym „miastem Samsunga.”",

                        }
                    });
                    context.SaveChanges();
                }

                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Surface Go 3",
                            Description = "Najbardziej przenośne urządzenie Surface 2 w 1 z ekranem dotykowym idealnie sprawdzi się w codziennych zadaniach, pracach domowych i rozrywce. Urządzenie Surface Go 3 wykorzystuje wszystko, co najlepsze w systemie Windows 11, jest zoptymalizowane pod kątem obsługi dotykowej i za pomocą pióra cyfrowego, a do tego ma szybszy procesor Intel® Core™ i umożliwia całodzienną pracę na baterii. Może być tabletem lub laptopem i ma wbudowane zabezpieczenia Microsoft.",
                            Price = 2173.99,
                            ImageURL = "https://th.bing.com/th/id/OIP.zi801rYOccfivC3VRbf2WgAAAA?rs=1&pid=ImgDetMain",
                            ReleaseDate = new DateTime(2021, 09, 21),
                            ProductCategory = ProductCategory.Laptop,
                            ManufacturerId = 1,
                        },

                    });
                    context.SaveChanges();

                }

            }
        }
    }
}
