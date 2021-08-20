using Buchhaltung_New.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Buchhaltung_New.GUI
{
    public partial class BuchenWindow : Form, IMode
    {
        public BuchenWindow()
        {
            InitializeComponent();
            updateDataGridViewContent();
        }

        public void setupForShow()
        {
            updateDataGridViewContent();
        }

        /// <summary>
        /// Function which filles the DataGridView with the Buchungen
        /// </summary>
        public void updateDataGridViewContent()
        {
            dataGridView1.Rows.Clear();

            //Fill the DataGridView with the Buchungen
            foreach(Buchung b in Buchhaltung.buchungen)
            {
                dataGridView1.Rows.Add(new string[] { b.konto1, b.konto2, b.datum.ToString(), b.beschreibung, b.betrag.ToString() });
            }
        }

        /// <summary>
        /// Menustrip Neu click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditBuchung newWindow = new AddEditBuchung(new Buchung("", "", DateTime.Now.Date, "", 0f), "Neue Buchung erstellen", "Erstellen");
            newWindow.ShowDialog();

            //If the user hasn't cancelled the dialog add the Buchung at the beginning
            if (!newWindow.userCancelled)
            {
                Buchhaltung.buchungen.Insert(0, newWindow.getResult());
                FileManager.saveAll();
                Buchhaltung.refreshKontoValues();
                updateDataGridViewContent();
            }
        }

        /// <summary>
        /// Menustrip Bearbeiten click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0) //If there are any selected rows
            {
                Buchung b = Buchhaltung.buchungen[dataGridView1.SelectedRows[0].Index]; //Get the Buchung with index of the first selected row
                AddEditBuchung newWindow = new AddEditBuchung(b, "Buchung editieren", "Editieren");
                newWindow.ShowDialog();

                //If the user hasn't cancelled the dialog save the edited Buchung
                if (!newWindow.userCancelled)
                {
                    Buchhaltung.buchungen[dataGridView1.SelectedRows[0].Index] = newWindow.getResult();
                    FileManager.saveAll();
                    Buchhaltung.refreshKontoValues();
                    updateDataGridViewContent();
                }
            }else
            {
                MessageHandler.showWarning("Editieren nicht möglich, da keine Buchung ausgewählt wurde");
            }
        }

        /// <summary>
        /// Menustrip Löschen Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void löschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                bool result;
                if(selectedRowCount == 1)
                {
                    result = MessageHandler.showOkCancelDialog("Sind Sie sicher, dass Sie die 1 selektierte Buchung löschen wollen?", "Warnung");
                }
                else
                {
                    result = MessageHandler.showOkCancelDialog("Sind Sie sicher, dass Sie die " + selectedRowCount + " selektierten Buchungen löschen wollen?", "Warnung");
                }

                if(result)
                {
                    //Iterate through the selected rows and delete the corresponding Buchungen
                    for(int i = 0;i<selectedRowCount;i++)
                    {
                        Buchhaltung.buchungen.RemoveAt(dataGridView1.SelectedRows[i].Index);
                    }
                    FileManager.saveAll();
                    Buchhaltung.refreshKontoValues();
                    updateDataGridViewContent();
                }
               
            }else
            {
                MessageHandler.showWarning("Konnte die Buchungen nicht löschen, da keine selektiert sind.");
            }
        }

        private void excelSpreadsheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create a save file dialog for the excel spread sheet
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "xlsx files (*.xlsx)|*.xlsx";
            if (s.ShowDialog() == DialogResult.OK)
            {
                new Exporter(Path.GetFullPath(s.FileName)).exportBuchungenToExcel();
            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
