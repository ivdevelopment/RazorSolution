using Razor.Models;

namespace Razor.Services
{
    public class FiliaalService
    {
        private Dictionary<int, Filiaal> filialen = new Dictionary<int, Filiaal>();
        public FiliaalService()
        {
            filialen[1] = new Filiaal
            {
                ID = 1,
                Naam = "Antwerpen",
                Gebouwd = new DateTime(2003, 1, 1),
                Waarde = 2000000m,
                Eigenaar = Eigenaar.Gehuurd
            };
            filialen[2] = new Filiaal
            {
                ID = 2,
                Naam = "Wondelgem",
                Gebouwd = new DateTime(1979, 1, 1),
                Waarde = 2500000m,
                Eigenaar = Eigenaar.Gehuurd
            };
            filialen[3] = new Filiaal
            {
                ID = 3,
                Naam = "Haasrode",
                Gebouwd = new DateTime(1976, 1, 1),
                Waarde = 1000000m,
                Eigenaar = Eigenaar.Eigendom
            };
            filialen[4] = new Filiaal
            {
                ID = 4,
                Naam = "Wevelgem",
                Gebouwd = new DateTime(1981, 1, 1),
                Waarde = 1600000m,
                Eigenaar = Eigenaar.Eigendom
            };
            filialen[5] = new Filiaal
            {
                ID = 5,
                Naam = "Genk",
                Gebouwd = new DateTime(1990, 1, 1),
                Waarde = 4000000m,
                Eigenaar = Eigenaar.Gehuurd
            };
        }

        public List<Filiaal> FindAll()
        {
            // levert enkel de values op van de dictionary
            return filialen.Values.ToList();
        }
        public Filiaal? Read(int id)
        {
            Filiaal? gelezenFiliaal = null;
            filialen.TryGetValue(id, out gelezenFiliaal);
            return gelezenFiliaal;
        }

        public void Delete(int id)
        {
            filialen.Remove(id);
        }
    }
}
