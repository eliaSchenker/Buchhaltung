using System;
using System.Collections.Generic;
using System.Text;

namespace Buchhaltung_New.Model
{
    public class Buchung
    {
        public string konto1;
        public string konto2;
        public DateTime datum;
        public string beschreibung;
        public float betrag;

        public Buchung(string konto1, string konto2, string datum, string beschreibung, float betrag)
        {
            this.konto1 = konto1;
            this.konto2 = konto2;
            this.datum = DateTime.Parse(datum);
            this.beschreibung = beschreibung;
            this.betrag = betrag;
        }

        public Buchung(string konto1, string konto2, DateTime datum, string beschreibung, float betrag)
        {
            this.konto1 = konto1;
            this.konto2 = konto2;
            this.datum = datum;
            this.beschreibung = beschreibung;
            this.betrag = betrag;
        }
    }
}
