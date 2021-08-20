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
    public partial class AddEditBuchung : Form
    {
        //Did the user cancel the form (e.g by closing it)
        public bool userCancelled;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="b">Buchung to edit (in case of editing these are the existing parameters in case of adding these will be default parameters)</param>
        /// <param name="title">Title the form should have</param>
        /// <param name="buttontext">Text the button should have</param>
        public AddEditBuchung(Buchung b, string title, string buttontext)
        {
            InitializeComponent();
            konto1input.Text = b.konto1;
            konto2input.Text = b.konto2;
            datuminput.Value = b.datum;
            beschreibunginput.Text = b.beschreibung;
            betraginput.Value = (decimal)b.betrag;
            Text = title; //Set the title for the form

            titlelabel.Text = title;
            submitbutton.Text = buttontext;

            userCancelled = true;

            //Initialize the autocomplete for the konto/beschreibung input
            AutoCompleteStringCollection kontoCollection = new AutoCompleteStringCollection();

            foreach(Konto konto in Buchhaltung.konten)
            {
                kontoCollection.Add(konto.name);
            }

            konto1input.AutoCompleteMode = AutoCompleteMode.Suggest;
            konto1input.AutoCompleteSource = AutoCompleteSource.CustomSource;
            konto1input.AutoCompleteCustomSource = kontoCollection;

            konto2input.AutoCompleteMode = AutoCompleteMode.Suggest;
            konto2input.AutoCompleteSource = AutoCompleteSource.CustomSource;
            konto2input.AutoCompleteCustomSource = kontoCollection;

            AutoCompleteStringCollection beschreibungCollection = new AutoCompleteStringCollection();

            foreach (Buchung buchung in Buchhaltung.buchungen)
            {
                beschreibungCollection.Add(buchung.beschreibung);
            }

            beschreibunginput.AutoCompleteMode = AutoCompleteMode.Suggest;
            beschreibunginput.AutoCompleteSource = AutoCompleteSource.CustomSource;
            beschreibunginput.AutoCompleteCustomSource = beschreibungCollection;
        }

        /// <summary>
        /// Returns the result (content of the input fields as a new Buchung)
        /// </summary>
        /// <returns>The new Buchung</returns>
        public Buchung getResult()
        {
            return new Buchung(konto1input.Text, konto2input.Text, datuminput.Value, beschreibunginput.Text, (float)betraginput.Value);
        }

        /// <summary>
        /// Event for Submit Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitbutton_Click(object sender, EventArgs e)
        {
            userCancelled = false;
            Close();
        }
    }
}
