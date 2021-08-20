using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Buchhaltung_New
{
    /// <summary>
    /// Class responsible for displaying error messages and warnings
    /// </summary>
    class MessageHandler
    {
        /// <summary>
        /// Displays a warning popup on the users screen
        /// </summary>
        /// <param name="warning">The warning message</param>
        public static void showWarning(string warningMessage)
        {
            MessageBox.Show(warningMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Displays an error popup on the users screen
        /// </summary>
        /// <param name="errorMessage">The error message</param>
        public static void showError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Shows an okay cancel dialog
        /// </summary>
        /// <param name="message">Message of the dialog</param>
        /// <param name="title">Title of the dialog</param>
        /// <param name="icon">Icon of the dialog</param>
        /// <returns>Did the user press okay or cancel</returns>
        public static bool showOkCancelDialog(string message, string title, MessageBoxIcon icon = MessageBoxIcon.Exclamation)
        {
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.OKCancel, icon);
            return result == DialogResult.OK;
        }
    }
}
