using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Buchhaltung_New.Model
{
    public class Mode
    {
        public string name;
        public IMode window;

        public Mode(string name, IMode window)
        {
            this.name = name;
            this.window = window;
        }
    }
}
