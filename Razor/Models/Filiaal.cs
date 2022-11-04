using System.ComponentModel.DataAnnotations;

namespace Razor.Models
{
    public class Filiaal
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        [UIHint("sterretjes")]
        public DateTime Gebouwd { get; set; }
        public decimal Waarde { get; set; }
        public Eigenaar Eigenaar { get; set; }
    }
}
