using Buchhaltung_New.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Buchhaltung_New
{
    class FileManager
    {
        /// <summary>
        /// Checks if the Folder in which the files for the Application are stored exists and if it doesn't creates it.
        /// </summary>
        private static void checkFolder()
        {
            if (!Directory.Exists(getPath()))
            {
                Directory.CreateDirectory(getPath());
            }
        }

        /// <summary>
        /// Loads all the Buchungen out of the file
        /// </summary>
        public static List<Buchung> loadBuchungen()
        {
            checkFolder();
            List<Buchung> buchungen = new List<Buchung>();
            using (StreamReader sr = new StreamReader(getPath() + @"\Buchungssätze.txt"))
            {
                string[] loaded = sr.ReadToEnd().Split('\n');
                for (int i = 0; i < loaded.Length; i++)
                {
                    if (loaded[i] != "")
                    {
                        string[] temp = loaded[i].Split('|');
                        if (temp.Length == 5)
                        {
                            buchungen.Add(new Buchung(temp[0], temp[1], temp[2], temp[3], float.Parse(temp[4])));
                        }
                        else
                        {
                            MessageHandler.showWarning("---------------------------------\nBuchung inkorrekt formatiert. Folgende Buchung wird ignoriert:\n"
                                + loaded[i] + "\n---------------------------------");
                        }
                    }
                }
            }
            return buchungen;
        }

        /// <summary>
        /// Loads all the Konten out of the file
        /// </summary>
        /// <returns></returns>
        public static List<Konto> loadKonten()
        {
            List<Konto> konten = new List<Konto>();
            using (StreamReader sr = new StreamReader(getPath() +  @"\Konten.txt"))
            {
                string[] loaded = sr.ReadToEnd().Split('\n');
                for (int i = 0; i < loaded.Length; i++)
                {
                    if (loaded[i] != "")
                    {
                        string[] temp = loaded[i].Split('|');
                        if (temp.Length == 2)
                        {
                            konten.Add(new Konto(temp[0], temp[1][0] == 'A', 0));
                        }
                        else
                        {
                            MessageHandler.showWarning("---------------------------------\nKonto inkorrekt formatiert. Folgendes Konto wird ignoriert:\n"
                                + loaded[i] + "\n---------------------------------");
                        }
                    }
                }
            }
            return konten;
        }

        /// <summary>
        /// Saves all the data to the disk
        /// </summary>
        public static void saveAll()
        {
            saveBuchungen();
            saveKonten();
        }

        /// <summary>
        /// Saves the Buchungen
        /// </summary>
        public static void saveBuchungen()
        {
            using (StreamWriter sr = new StreamWriter(getPath() + @"\Buchungssätze.txt"))
            {
                for (int i = 0; i < Buchhaltung.buchungen.Count; i++)
                {
                    Buchung b = Buchhaltung.buchungen[i];
                    sr.WriteLine(b.konto1 + "|" + b.konto2 + "|" + b.datum.Date.ToString() + "|" + b.beschreibung + "|" + b.betrag);
                }
            }
        }

        /// <summary>
        /// Saves the Konten
        /// </summary>
        public static void saveKonten()
        {
            using (StreamWriter sr = new StreamWriter(getPath() + @"\Konten.txt"))
            {
                for (int i = 0; i < Buchhaltung.konten.Count; i++)
                {
                    Konto k = Buchhaltung.konten[i];
                    sr.WriteLine(k.name + "|" + (k.isActive ? "A" : "P"));
                }
            }
        }

        /// <summary>
        /// Returns the Path were the save files for the application are located
        /// </summary>
        /// <returns>The path</returns>
        public static string getPath() {
            return @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\Buchhaltung";
        }
    }
}
