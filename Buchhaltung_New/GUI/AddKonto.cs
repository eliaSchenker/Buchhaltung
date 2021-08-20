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
    public partial class AddKonto : Form
    {
        public bool userCancelled;

        public AddKonto()
        {
            InitializeComponent();
            userCancelled = true;
        }

        /// <summary>
        /// Returns the result (content of the input field/checkbox as a new Konto)
        /// </summary>
        /// <returns>The new Konto</returns>
        public Konto getResult()
        {
            return new Konto(kontonameinput.Text, isactivecheckbox.Checked, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userCancelled = false;
            Close();
        }
    }
}
