using Buchhaltung_New.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Buchhaltung_New
{
    public partial class MainWindow : Form
    {
        private Controller controller;

        public MainWindow(Controller c)
        {
            this.controller = c;
            InitializeComponent();
        }

        public ListBox getModeSelectionList()
        {
            return modeSelection;
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            controller.openCurrentMode();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            new AboutWindow().ShowDialog();
        }
    }
}
