using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Buchhaltung_New.Model
{
    class Buchhaltung
    {
        public static List<Konto> konten;
        public static List<Buchung> buchungen;

        public static void refreshKontoValues()
        {
            //Reset all the values of Konto to 0
            foreach(Konto k in konten)
            {
                k.currentValue = 0;
            }

            //Iterate through the Buchungen and update the Konto value
            foreach(Buchung b in buchungen)
            {
                Konto k1 = konten.Find(p => p.name == b.konto1);
                Konto k2 = konten.Find(p => p.name == b.konto2);
                if(k1 != null)
                {
                    k1.buchung(b.betrag, true);
                }else
                {
                    Debug.WriteLine("Buchung konnten nicht durchgeführt werden. Konto \"" + b.konto1 + "\" nicht gefunden.");
                }

                if(k2 != null)
                {
                    k2.buchung(b.betrag, false);
                }
                else
                {
                    Debug.WriteLine("Buchung konnten nicht durchgeführt werden. Konto \""  + b.konto2 + "\" nicht gefunden.");
                }
            }
        }
    }
}
