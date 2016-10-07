using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_UWP.Classes
{
    public class Magazijn
    {
        private string naam;
        private string locatie;
        private string bedrijf;

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        public string Locatie
        {
            get { return locatie; }
            set { locatie = value; }
        }

        public string Bedrijf
        {
            get { return bedrijf; }
            set { bedrijf = value; }
        }

        public Magazijn(string naam, string locatie, string bedrijf)
        {
            this.naam = naam;
            this.locatie = locatie;
            this.bedrijf = bedrijf;
        }
    }
}
