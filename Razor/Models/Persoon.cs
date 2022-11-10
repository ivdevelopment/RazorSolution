using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Razor.Models
{
    [WeddeScore]
    public class Persoon
    {
        public int ID { get; set; }
        public string Voornaam { get; set; }


        [StringLength(255, ErrorMessage = "Max. {1} tekens voor {0}")]
        public string Familienaam { get; set; }

        [Remote("ValideerGebruikersnaam", "Persoon", ErrorMessage ="Deze gebruikersnaam is reeds in gebruik.")]
        public string? Gebruikersnaam { get; set; }

        [OnevenTussenTweeGrenzen(1, 5, ErrorMessage =
        "Enkel oneven scores tussen {1} en {2} !")]
        public int Score { get; set; }


        [DisplayFormat(DataFormatString = "{0:€ #,##0.00}")]
        public decimal Wedde { get; set; }


        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8, ErrorMessage =
        "Het wachtwoord bevat min. {2}, max. {1} tekens")]
        [Required]
        public string Paswoord { get; set; }
        [Compare("Paswoord", ErrorMessage = "{0} verschilt van {1}")]
        [Required]
        [DataType(DataType.Password)]
        public string HerhaalPaswoord { get; set; }


        [DataType(DataType.Date)]
        [Verleden(ErrorMessage="Geboortedatum moet in het verleden liggen")]
        public DateTime Geboren { get; set; }


        public bool Gehuwd { get; set; }

        public string? Opmerkingen { get; set; }

        public Geslacht Geslacht { get; set; }


        [RegularExpression(@"[A-Z]{2}\d{2}-\d{4}-\d{4}-\d{4}",
        ErrorMessage = "Rekeningnummer verkeerd")]
        public string? RekeningNummer { get; set; }
    }
}
