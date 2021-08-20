using Buchhaltung_New.GUI;
using Buchhaltung_New.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Buchhaltung_New
{
    public class Controller
    {
        //Reference to Main Window
        private MainWindow mainWindow;

        public List<Mode> modes;

        public Controller()
        {
            mainWindow = new MainWindow(this);
            Buchhaltung.buchungen = FileManager.loadBuchungen();
            Buchhaltung.konten = FileManager.loadKonten();

            initModes();
            fillModeList();

            Application.Run(mainWindow);
        }

        public void initModes()
        {
            modes = new List<Mode>();
            modes.Add(new Mode("Buchen", new BuchenWindow()));
            modes.Add(new Mode("Kontoübersicht", new Kontouebersicht()));
        }

        private void fillModeList()
        {
            mainWindow.getModeSelectionList().Items.Clear();
            foreach(Mode m in modes)
            {
                mainWindow.getModeSelectionList().Items.Add(m.name);
            }
        }

        /// <summary>
        /// Opens the current selected mode (Programm)
        /// </summary>
        public void openCurrentMode()
        {
            if (mainWindow.getModeSelectionList().SelectedIndex != -1)
            {
                Debug.WriteLine("Opening Mode " + modes[mainWindow.getModeSelectionList().SelectedIndex].name);

                //Get the Interface of the current selected mode
                IMode mode = modes[mainWindow.getModeSelectionList().SelectedIndex].window;
                //Cast it to a form for execution
                Form windowForm = (Form)mode;

                //Check if the cast was successfull
                if(windowForm == null)
                {
                    MessageHandler.showError("Beim öffnen des selektierten Programmes ist ein Fehler aufgetreten.");
                }else
                {
                    mode.setupForShow();
                    windowForm.ShowDialog();
                }
            }else
            {
                MessageHandler.showWarning("Kein Item selektiert.");
            }
        }
    }
}
