using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Razor.Models
{
    public class OpslagViewModel
    {
        [Display(Name = "Van wedde:")]
        [Required(ErrorMessage = "Van wedde is een verplicht veld")]
        public decimal? VanWedde { get; set; }
        [Display(Name = "Tot wedde:")]
        [Required(ErrorMessage = "Tot wedde is een verplicht veld")]
        public decimal? TotWedde { get; set; }
        [Display(Name = "Percentage:")]
        [Required(ErrorMessage = "Percentage is een verplicht veld")]
        [Range(0, 100, ErrorMessage = "{0} minimum {1}, maximum {2}")]
        public decimal Percentage { get; set; }
    }
}
