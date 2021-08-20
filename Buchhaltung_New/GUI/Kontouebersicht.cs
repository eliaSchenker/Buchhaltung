using Buchhaltung_New.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Buchhaltung_New.GUI
{
    public partial class Kontouebersicht : Form, IMode
    {
        public Kontouebersicht()
        {
            InitializeComponent();
            updateDataGridViewContent();
        }

        public void setupForShow()
        {
            updateDataGridViewContent();
        }

        /// <summary>
        /// Function which filles the DataGridView with the Konten
        /// </summary>
        public void updateDataGridViewContent()
        {
            dataGridView1.Rows.Clear();

            //Refresh all the values of the konten
            Buchhaltung.refreshKontoValues();

            //Fill the DataGridView with the Buchungen
            foreach (Konto k in Buchhaltung.konten)
            {
                dataGridView1.Rows.Add(new string[] { k.name, k.currentValue.ToString("#.##")});
            }
        }

        /// <summary>
        /// Menustrip Excel Spreadsheet Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void excelSpreadsheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO Implement Excel export for Konto
        }

        /// <summary>
        /// Menustrip Exit Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Menustrip Neu Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddKonto newWindow = new AddKonto();
            newWindow.ShowDialog();

            //If the user hasn't cancelled the dialog add the Buchung at the beginning
            if (!newWindow.userCancelled)
            {
                Buchhaltung.konten.Add(newWindow.getResult());
                FileManager.saveAll();
                updateDataGridViewContent();
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
                if (selectedRowCount == 1)
                {
                    result = MessageHandler.showOkCancelDialog("Sind Sie sicher, dass Sie das 1 selektierte Konto löschen wollen? (Buchungen werden davon nicht betroffen)", "Warnung");
                }
                else
                {
                    result = MessageHandler.showOkCancelDialog("Sind Sie sicher, dass Sie die " + selectedRowCount + " selektierten Konten löschen wollen? (Buchungen werden davon nicht betroffen)", "Warnung");
                }

                if (result)
                {
                    //Iterate through the selected rows and delete the corresponding Buchungen
                    for (int i = 0; i < selectedRowCount; i++)
                    {
                        Buchhaltung.konten.RemoveAt(dataGridView1.SelectedRows[i].Index);
                    }
                    FileManager.saveAll();
                    updateDataGridViewContent();
                }

            }
            else
            {
                MessageHandler.showWarning("Konnte die Buchungen nicht löschen, da keine selektiert sind.");
            }
        }
    }
}
