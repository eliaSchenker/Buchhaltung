using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buchhaltung_New
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                new Controller();
            }catch(Exception e)
            {
                bool result = MessageHandler.showOkCancelDialog(e.Message + "\nEs ist ein Fehler aufgetreten und die Applikation wird nun geschlossen. Ich entschuldige für die Unannehmlichkeiten. Applikation neustarten?", "Error", MessageBoxIcon.Error);
                
                //if the user answered yes to restart the application, restart it
                if(result)
                {
                    Restart();
                }
            }
        }

        /// <summary>
        /// Restarts the application
        /// Found on github: https://github.com/dotnet/winforms/issues/2769
        /// </summary>
        private static void Restart()
        {
            string[] arguments = Environment.GetCommandLineArgs();
            Debug.Assert(arguments != null && arguments.Length > 0);
            StringBuilder sb = new StringBuilder((arguments.Length - 1) * 16);
            for (int argumentIndex = 1; argumentIndex < arguments.Length - 1; argumentIndex++)
            {
                sb.Append('"');
                sb.Append(arguments[argumentIndex]);
                sb.Append("\" ");
            }
            if (arguments.Length > 1)
            {
                sb.Append('"');
                sb.Append(arguments[arguments.Length - 1]);
                sb.Append('"');
            }
            ProcessStartInfo currentStartInfo = new ProcessStartInfo();
            currentStartInfo.FileName = Path.ChangeExtension(Application.ExecutablePath, "exe");
            if (sb.Length > 0)
            {
                currentStartInfo.Arguments = sb.ToString();
            }
            Application.Exit();
            Process.Start(currentStartInfo);
        }
    }
}
