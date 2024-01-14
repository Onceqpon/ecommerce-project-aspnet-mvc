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
                            CompanyLogoURL = "https://upload.wikimedia.org/wikipedia/commons/9/98/Microsoft_logo.jpg",
                            Description = "Amerykańskie przedsiębiorstwo informatyczne. Najbardziej znane jako producent systemów operacyjnych MS-DOS, Microsoft Windows i oprogramowania biurowego Microsoft Office. Spółka publiczna z siedzibą w Redmond w stanie Waszyngton.",

                        },
                        new Manufacturer()
                        {
                            Name = "Sony",
                            CompanyLogoURL = "https://upload.wikimedia.org/wikipedia/commons/c/c5/Sony_logos.JPG",
                            Description = "Japoński producent elektroniki użytkowej i zarazem jeden z największych światowych producentów w tej branży, założony 7 maja 1946 roku przez Masaru Ibukę i Akio Moritę w Tokio jako Tokyo Communication Industry.",

                        },
                        new Manufacturer()
                        {
                            Name = "Samsung",
                            CompanyLogoURL = "https://upload.wikimedia.org/wikipedia/commons/6/6e/Logo_samsung_5.jpg",
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
                            ShortDescription = "Urządzenie Przenośne",
                            Description = "Najbardziej przenośne urządzenie Surface 2 w 1 z ekranem dotykowym idealnie sprawdzi się w codziennych zadaniach, pracach domowych i rozrywce. Urządzenie Surface Go 3 wykorzystuje wszystko, co najlepsze w systemie Windows 11, jest zoptymalizowane pod kątem obsługi dotykowej i za pomocą pióra cyfrowego, a do tego ma szybszy procesor Intel® Core™ i umożliwia całodzienną pracę na baterii. Może być tabletem lub laptopem i ma wbudowane zabezpieczenia Microsoft.",
                            Price = 2137.99,
                            ImageURL = "https://polsoft.pl/microsoft-surface/wp-content/uploads/2022/05/tablet-microsoft-surface-go-3-czarny-matowy-z-klawiatura-8VI-00016.jpg",
                            ReleaseYear = 2021,
                            ProductCategory = ProductCategory.Laptop,
                            ManufacturerId = 1,
                        },

                        new Product()
                        {
                            Name = "Galaxy S22",
                            ShortDescription = "Telefon",
                            Description = "Galaxy S22 zachwyca nowoczesnym i stylowym wyglądem. Ma płaską konstrukcję i ograniczone do minimum ramki. Został wykonany w przykuwających uwagę kolorach z materiałów w najwyższej jakości. Każdy dzień jego użytkowania będzie dla Ciebie przyjemnością.",
                            Price = 2699.99,
                            ImageURL = "https://images.samsung.com/is/image/samsung/p6pim/pl/2302/gallery/pl-galaxy-s23-s911-448254-sm-s911bzageue-thumb-534993002?imwidth=480",
                            ReleaseYear = 2021,
                            ProductCategory = ProductCategory.Telefon,
                            ManufacturerId = 3,
                        },

                        new Product()
                        {
                            Name = "Sony Xperia Pro-I 12",
                            ShortDescription = "Telefon",
                            Description = "Litera „I” oznacza imponujące zdjęcia. Smartfon Xperia PRO-I jest wyposażony w rewolucyjny aparat, który łączy w sobie profesjonalną jakość zdjęć z możliwościami komunikacji charakterystycznymi dla smartfonów. Dzięki temu możesz wykazywać się kreatywnością zawsze i wszędzie.",
                            Price = 8399.99,
                            ImageURL = "https://fotoforma.pl/userdata/public/gfx/122850/sony-xperia-pro-i-512-gb-5g_1.jpg",
                            ReleaseYear = 2022,
                            ProductCategory = ProductCategory.Telefon,
                            ManufacturerId = 2,
                        },

                        new Product()
                        {
                            Name = "77\" OLED 4K S95C",
                            ShortDescription = "Telewizor",
                            Description = "Matryca OLED o rozdzielczości 4K do 144Hz gwarantująca szeroką paletę żywych kolorów oraz certyfikowany HDR10+\r\nUltrasmukły Design Telewizora zamknięty w obudowie o głębokości zaledwie ok. 11 mm oraz wszystkie przewody w jednym miejscu dzięki Modułowi One Connect Pro\r\nFunkcje dla graczy: 144Hz, Freesync Premium Pro, 4 porty HDMI 2.1, niski Input Lag, Zaawansowany Upłynniacz Ruchu Pro\r\nSpektakularny dźwięk przestrzenny oferujący kinowe wrażenia dzięki Dolby Atmos® (4.2.2CH)\r\nSmart TV Tizen oferujący dostęp do ponad 500 aplikacji, takich jak Netflix, YouTube, Prime Video, CANAL+ oraz możliwość sterowania urządzeniami za pomocą SmartThings\r\nUltraszeroki Kąt Widzenia i Powłoka Antyrefleksyjna eliminująca odblaski na ekranie",
                            Price = 17999.99,
                            ImageURL = "https://images.samsung.com/is/image/samsung/p6pim/pl/qe77s95catxxh/gallery/pl-oled-s95c-qe77s95catxxh-536566894?$650_519_PNG$",
                            ReleaseYear = 2022,
                            ProductCategory = ProductCategory.RTV,
                            ManufacturerId = 3,
                        },

                        new Product()
                        {
                            Name = "RB38C776CB1 Lodówka z dolnym zamrażalnikiem Wi-Fi 2,03 m 390 l",
                            ShortDescription = "Lodówka",
                            Description = "AI Energy - nawet o 15% mniej zużycia energii\r\nMetal Cooling - minimalna utrata zimna\r\nSpaceMax™ - więcej miejsca\r\n20 lat gwarancji - na kompresor Digital Inverter\r\nPełny No Frost - lodówka bez szronu i lodu\r\nAll-Around Cooling - równomierne chłodzenie",
                            Price = 3799.99,
                            ImageURL = "https://images.samsung.com/is/image/samsung/p6pim/pl/rb38c776cb1-ef/gallery/pl-rb7300t-wifi-a-445197-rb38c776cb1-ef-534713909?$2052_1641_PNG$",
                            ReleaseYear = 2021,
                            ProductCategory = ProductCategory.AGD,
                            ManufacturerId = 3,
                        },

                        new Product()
                        {
                            Name = "Alpha A7 III Czarny + Obiektyw 24-105 f/4.0 OOS",
                            ShortDescription = "Aparat",
                            Description = "Sony α (Alfa) to bardzo rozbudowany system aparatów przeznaczonych zarówno dla amatorów jak i najwyższej klasy profesjonalistów. W ofercie systemu Alfa znajdują się nowoczesne aparaty bezlusterkowe (mocowanie obiektywów Sony E) jak i klasyczne lustrzanki cyfrowe (mocowanie Sony A). Obydwa typy aparatów dzielą się na mniejsze z matrycą APS-C oraz profesjonalne, nieco większe gabarytowo z matrycą pełnoklatkową. Firma Sony w 2013 r. jako pierwsza wprowadziła do sprzedaży pełnoklatkowe aparaty bezlusterkowe gwarantując doskonałą jakość zdjęć i filmów oraz wygodę użytkowania.",
                            Price = 10895.99,
                            ImageURL = "https://prod-api.mediaexpert.pl/api/images/gallery_500_500/thumbnails/images/20/2059149/Aparat-SONY-Alpha-A7-III-Czarny-Obiektyw-24-105-f4.0-OOS-front.jpg",
                            ReleaseYear = 2022,
                            ProductCategory = ProductCategory.Aparat,
                            ManufacturerId = 2,
                        },

                        new Product()
                        {
                            Name = "SONY HDR-CX405",
                            ShortDescription = "Kamera",
                            Description = "Możliwości kamey Handycam HDR-CX405 wynikają nie tylko z zaawansowanej technologii: ich projektanci zwracają także uwagę aspekty związane z naturą człowieka. Opracowują urządzenia uniwersalne, pozwalające tworzyć, kształtować, dzielić się z innymi i wciąż odkrywać nowe sposoby nagrywania naprawdę poruszających filmów. Funkcjonalność kamer Sony umożliwia dostrzeżenie i pokazanie sedna filmowanego tematu bez konieczności ciągłego dobierania optymalnych ustawień.",
                            Price = 1199.99,
                            ImageURL = "https://prod-api.mediamarkt.pl/api/images/gallery_545_400/thumbnails/images/10/1024039/0f40c0146e92cfa2f4e3307316ac3ac3.jpg",
                            ReleaseYear = 2019,
                            ProductCategory = ProductCategory.Kamera,
                            ManufacturerId = 2,
                        },

                        new Product()
                        {
                            Name = "Galaxy Tab S9 FE 10.9\" 6/128 GB",
                            ShortDescription = "Tablet",
                            Description = "Zacznij odkrywać świat pełen zabawy, kreatywnych możliwości oraz rozrywki razem z Galaxy Tab S9 FE oraz Tab S9 FE+. Oglądaj, twórz i dziel się tym co kochasz na pełnym detali i barw, jasnym immersyjnym ekranie. Oba modele dostępne są w kolorach, które doskonale podkreślą Twój wyjątkowy vibe – szarym, miętowym oraz lawendowym.",
                            Price = 2259.99,
                            ImageURL = "https://prod-api.mediaexpert.pl/api/images/gallery_500_500/thumbnails/images/58/5846604/Galaxy-Tab-S9-FE-5G-SZARY-WIFI-1.jpg",
                            ReleaseYear = 2021,
                            ProductCategory = ProductCategory.Tablet,
                            ManufacturerId = 3,
                        },

                        new Product()
                        {
                            Name = "XBOX Series X z napędem Blu-ray 4K UHD",
                            ShortDescription = "Konsola",
                            Description = "Poznaj Xbox Series X, szybką i potężną konsolę Xbox w historii. Odkryj ekscytujące światy 12 teraflopów czystej mocy przetwarzania grafiki, śledzenia promieni DirectX i gier 4K. Wykorzystaj w pełni każdą minutę gry dzięki funkcji szybkiego wznawiania, szybkiemu ładowaniu i szybkości do 120 klatek na sekundę dzięki technologii Xbox Velocity Architecture.",
                            Price = 2399.99,
                            ImageURL = "https://prod-api.mediaexpert.pl/api/images/gallery_500_500/thumbnails/images/21/2138549/Konsola-MICROSOFT-XBOX-Series-X-z-napedem-Blu-ray-4K-UHD-front-skos-pad.jpg",
                            ReleaseYear = 2021,
                            ProductCategory = ProductCategory.Konsola,
                            ManufacturerId = 1,
                        },

                        new Product()
                        {
                            Name = "Galaxy Watch6 (Bluetooth, 40mm)\r\n",
                            ShortDescription = "Smartwatch",
                            Description = "Duży, okrągły widok na nadgarstku\r\nWypracuj zdrowe nawyki związane ze snem\r\nPoznaj lepiej swoje ciało i samopoczucie",
                            Price = 1499.99,
                            ImageURL = "https://images.samsung.com/is/image/samsung/p6pim/pl/2307/gallery/pl-galaxy-watch6-r935-sm-r930nzeaeue-537483831?$1300_1038_PNG$",
                            ReleaseYear = 2020,
                            ProductCategory = ProductCategory.Smartwatch,
                            ManufacturerId = 3,
                        },

                        new Product()
                        {
                            Name = "MICROSOFT Ergonomic Keyboard",
                            ShortDescription = "Akcesoria",
                            Description = "Udoskonalona, konstrukcja, z wygodniejszą podpórką pod dłoń i klawiszami skrótów usprawniającymi pracę. Udoskonalona podkładka i ergonomiczna podpórka pod dłoń zapewnia komfort prze cały dzień i pozwala ułożyć nadgarstki w neutralnej pozycji. Ułatw sobie pracę dzięki dedykowanym klawiszom do Microsoft 365, wyszukiwania oraz łatwego sterowania multimediami i innymi funkcjami. Pracuj szybko i wydajnie dzięki zintegrowanej klawiaturze numerycznej. Klawiaturę Microsoft Ergonomic Keyboard można sparować z innymi akcesoriami. Funkcje personalizowane: Zmiana przypisania klawiszy ulubionych i klawiszy multimediów, zarządzanie wskaźnikiem LED (NumLock, CapsLock, ScrollLock), włączanie / wyłączanie klawisza aplikacji, zmiana przypisania klawisza emoji (można przypisać tylko do klawisza aplikacji).",
                            Price = 259.99,
                            ImageURL = "https://prod-api.mediaexpert.pl/api/images/gallery_500_500/thumbnails/images/23/2375448/Klawiatura-MICROSOFT-Ergonomic-Keyboard-gora-1.jpg",
                            ReleaseYear = 2018,
                            ProductCategory = ProductCategory.Akcesoria,
                            ManufacturerId = 1,
                        },

                    });

                    context.SaveChanges();
                }

            }
        }
    }
}
