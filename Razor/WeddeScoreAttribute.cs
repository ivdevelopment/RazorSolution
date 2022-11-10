using Razor.Models;
using System.ComponentModel.DataAnnotations;

namespace Razor
{
    public class WeddeScoreAttribute : ValidationAttribute
    {
        public WeddeScoreAttribute()
        {
            ErrorMessage = "Personen met score onder de 3 kunnen geen wedde boven 3000 hebben.";
        }
        public override bool IsValid(object? value)
        {
            Persoon? p = value as Persoon;
            if (p == null) return false;
            else
                return !((p.Score < 3) && (p.Wedde > 3000));
        }
    }
}
