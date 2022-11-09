﻿using Razor.Models;

namespace Razor.Services
{
    public class PersoonService
    {
        private Dictionary<int, Persoon> personen = new()
        {
            {
                1, new Persoon {ID=1, Voornaam = "Jesse", Familienaam = "James", Score = 5, Wedde = 1000m, Paswoord = "123", Geboren = new DateTime(1966,1,1), Gehuwd = true, Opmerkingen = "Schurk van het wilde westen", Geslacht = Geslacht.Man}
            },
            {
                2, new Persoon {ID=2, Voornaam = "Jane", Familienaam = "Calamity", Score=4,
                Wedde=2000m, Paswoord="123", Geboren=new DateTime(1966,2,2), Gehuwd=true,
                Opmerkingen="Martha Jane Cannary", Geslacht=Geslacht.Vrouw}
            },
            {
                3, new Persoon {ID=3, Voornaam="Billy",Familienaam="The Kid", Score=5,
                Wedde=3000m, Paswoord="123", Geboren=new DateTime(1966,3,3), Gehuwd=false,
                Opmerkingen="Revolverheld", Geslacht=Geslacht.Man}
            },
            {
                4, new Persoon {ID=4, Voornaam="Sarah",Familienaam="Bernhardt", Score=3,
                Wedde=4000m, Paswoord="123", Geboren=new DateTime(1966,4,4), Gehuwd=false,
                Opmerkingen="Rosine Bernardt", Geslacht=Geslacht.Vrouw}
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
    }
}
