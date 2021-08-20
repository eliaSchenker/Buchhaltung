
namespace Buchhaltung_New.GUI
{
    partial class AddKonto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.kontonameinput = new System.Windows.Forms.TextBox();
            this.isactivecheckbox = new System.Windows.Forms.CheckBox();
            this.hinzufuegenbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Konto hinzufügen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kontoname:";
            // 
            // kontonameinput
            // 
            this.kontonameinput.Location = new System.Drawing.Point(91, 41);
            this.kontonameinput.Name = "kontonameinput";
            this.kontonameinput.Size = new System.Drawing.Size(270, 23);
            this.kontonameinput.TabIndex = 2;
            // 
            // isactivecheckbox
            // 
            this.isactivecheckbox.AutoSize = true;
            this.isactivecheckbox.Checked = true;
            this.isactivecheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isactivecheckbox.Location = new System.Drawing.Point(13, 79);
            this.isactivecheckbox.Name = "isactivecheckbox";
            this.isactivecheckbox.Size = new System.Drawing.Size(179, 19);
            this.isactivecheckbox.TabIndex = 4;
            this.isactivecheckbox.Text = "Ist das Konto ein Aktivkonto?";
            this.isactivecheckbox.UseVisualStyleBackColor = true;
            // 
            // hinzufuegenbutton
            // 
            this.hinzufuegenbutton.Location = new System.Drawing.Point(220, 79);
            this.hinzufuegenbutton.Name = "hinzufuegenbutton";
            this.hinzufuegenbutton.Size = new System.Drawing.Size(141, 23);
            this.hinzufuegenbutton.TabIndex = 5;
            this.hinzufuegenbutton.Text = "Hinzufügen";
            this.hinzufuegenbutton.UseVisualStyleBackColor = true;
            this.hinzufuegenbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddKonto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 114);
            this.Controls.Add(this.hinzufuegenbutton);
            this.Controls.Add(this.isactivecheckbox);
            this.Controls.Add(this.kontonameinput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddKonto";
            this.Text = "AddKonto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox kontonameinput;
        private System.Windows.Forms.CheckBox isactivecheckbox;
        private System.Windows.Forms.Button hinzufuegenbutton;
    }
}