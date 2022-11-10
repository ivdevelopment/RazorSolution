using Razor.Models;

namespace Razor.Services
{
    public class PersoonService
    {
        private Dictionary<int, Persoon> personen = new()
        {
            {
                1, new Persoon {ID=1, Voornaam = "Jesse", Familienaam = "James", Gebruikersnaam="jessejames2", Score = 5, Wedde = 1000m, Paswoord = "Dejesse8777", HerhaalPaswoord = "Dejesse8777", Geboren = new DateTime(1966,1,1), Gehuwd = true, Opmerkingen = "Schurk van het wilde westen", Geslacht = Geslacht.Man, RekeningNummer="BE71-1998-2138-4369"}
            },
            {
                2, new Persoon {ID=2, Voornaam = "Jane", Familienaam = "Calamity", Gebruikersnaam="janecalaa", Score=4,
                Wedde=2000m, Paswoord="janedejane22", HerhaalPaswoord="janedejane22", Geboren=new DateTime(1966,2,2), Gehuwd=true,
                Opmerkingen="Martha Jane Cannary", Geslacht=Geslacht.Vrouw, RekeningNummer = "BE05-9995-3853-4875"}
            },
            {
                3, new Persoon {ID=3, Voornaam="Billy",Familienaam="The Kid", Gebruikersnaam="thekidrich", Score=5,
                Wedde=3000m, Paswoord="billyruiterr", HerhaalPaswoord = "billyruiterr", Geboren=new DateTime(1966,3,3), Gehuwd=false,
                Opmerkingen="Revolverheld", Geslacht=Geslacht.Man, RekeningNummer="BE75-7351-6522-6451"}
            },
            {
                4, new Persoon {ID=4, Voornaam="Sarah",Familienaam="Bernhardt", Gebruikersnaam="bernsarah", Score=3,
                Wedde=4000m, Paswoord="sarah546", HerhaalPaswoord="sarah546", Geboren=new DateTime(1966,4,4), Gehuwd=false,
                Opmerkingen="Rosine Bernardt", Geslacht=Geslacht.Vrouw, RekeningNummer="BE89-9543-3482-8685"}
            }
        };

        public List<Persoon> FindAll()
        {
            return personen.Values.ToList();
        }
        public Persoon? FindByID(int id)
        {
            Persoon? gelezenPersoon = null;
            personen.TryGetValue(id, out gelezenPersoon);
            return gelezenPersoon;
        }

        public void Delete(int id)
        {
            personen.Remove(id);
        }

        public void Opslag(decimal? vanWedde, decimal? totWedde, decimal percentage)
        {
            foreach (var p in
                (from persoon in personen.Values
                where persoon.Wedde >= vanWedde && persoon.Wedde <= totWedde
                select persoon) //linq-query selecteert personen op basis van wedde
                )
            {
                p.Wedde += p.Wedde * percentage / 100;
            }
        }

        public List<Persoon> VanTotWedde(decimal? van, decimal? tot)
        {
            return (from persoon in personen.Values
                    where persoon.Wedde >= van && persoon.Wedde <= tot
                    orderby persoon.Wedde
                    select persoon).ToList();
        }

        public void Add(Persoon p)
        {
            p.ID = personen.Keys.Max() + 1;
            personen.Add(p.ID, p);
        }

        public void Update(Persoon p)
        {
            personen[p.ID] = p;
        }

        public bool Bestaat(string naam)
        {
            if ((from persoon in personen.Values
                 where persoon.Gebruikersnaam == naam
                 select persoon).Count() != 0)
                return true;
            else
                return false;
        }
    }
}
