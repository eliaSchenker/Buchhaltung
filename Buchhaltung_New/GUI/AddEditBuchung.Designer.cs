
namespace Buchhaltung_New.GUI
{
    partial class AddEditBuchung
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
            this.titlelabel = new System.Windows.Forms.Label();
            this.konto1label = new System.Windows.Forms.Label();
            this.konto2label = new System.Windows.Forms.Label();
            this.datumlabel = new System.Windows.Forms.Label();
            this.beschreibunglabel = new System.Windows.Forms.Label();
            this.konto1input = new System.Windows.Forms.TextBox();
            this.konto2input = new System.Windows.Forms.TextBox();
            this.datuminput = new System.Windows.Forms.DateTimePicker();
            this.beschreibunginput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.submitbutton = new System.Windows.Forms.Button();
            this.betraginput = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.betraginput)).BeginInit();
            this.SuspendLayout();
            // 
            // titlelabel
            // 
            this.titlelabel.AutoSize = true;
            this.titlelabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.titlelabel.Location = new System.Drawing.Point(12, 9);
            this.titlelabel.Name = "titlelabel";
            this.titlelabel.Size = new System.Drawing.Size(52, 21);
            this.titlelabel.TabIndex = 0;
            this.titlelabel.Text = "label1";
            // 
            // konto1label
            // 
            this.konto1label.AutoSize = true;
            this.konto1label.Location = new System.Drawing.Point(13, 38);
            this.konto1label.Name = "konto1label";
            this.konto1label.Size = new System.Drawing.Size(51, 15);
            this.konto1label.TabIndex = 1;
            this.konto1label.Text = "Konto 1:";
            // 
            // konto2label
            // 
            this.konto2label.AutoSize = true;
            this.konto2label.Location = new System.Drawing.Point(176, 38);
            this.konto2label.Name = "konto2label";
            this.konto2label.Size = new System.Drawing.Size(51, 15);
            this.konto2label.TabIndex = 2;
            this.konto2label.Text = "Konto 2:";
            // 
            // datumlabel
            // 
            this.datumlabel.AutoSize = true;
            this.datumlabel.Location = new System.Drawing.Point(13, 72);
            this.datumlabel.Name = "datumlabel";
            this.datumlabel.Size = new System.Drawing.Size(46, 15);
            this.datumlabel.TabIndex = 3;
            this.datumlabel.Text = "Datum:";
            // 
            // beschreibunglabel
            // 
            this.beschreibunglabel.AutoSize = true;
            this.beschreibunglabel.Location = new System.Drawing.Point(13, 107);
            this.beschreibunglabel.Name = "beschreibunglabel";
            this.beschreibunglabel.Size = new System.Drawing.Size(82, 15);
            this.beschreibunglabel.TabIndex = 4;
            this.beschreibunglabel.Text = "Beschreibung:";
            // 
            // konto1input
            // 
            this.konto1input.Location = new System.Drawing.Point(70, 35);
            this.konto1input.Name = "konto1input";
            this.konto1input.Size = new System.Drawing.Size(100, 23);
            this.konto1input.TabIndex = 1;
            // 
            // konto2input
            // 
            this.konto2input.Location = new System.Drawing.Point(233, 35);
            this.konto2input.Name = "konto2input";
            this.konto2input.Size = new System.Drawing.Size(100, 23);
            this.konto2input.TabIndex = 2;
            // 
            // datuminput
            // 
            this.datuminput.Location = new System.Drawing.Point(70, 66);
            this.datuminput.Name = "datuminput";
            this.datuminput.Size = new System.Drawing.Size(263, 23);
            this.datuminput.TabIndex = 3;
            // 
            // beschreibunginput
            // 
            this.beschreibunginput.Location = new System.Drawing.Point(102, 104);
            this.beschreibunginput.Name = "beschreibunginput";
            this.beschreibunginput.Size = new System.Drawing.Size(231, 23);
            this.beschreibunginput.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Betrag:";
            // 
            // submitbutton
            // 
            this.submitbutton.Location = new System.Drawing.Point(339, 139);
            this.submitbutton.Name = "submitbutton";
            this.submitbutton.Size = new System.Drawing.Size(113, 23);
            this.submitbutton.TabIndex = 6;
            this.submitbutton.Text = "button1";
            this.submitbutton.UseVisualStyleBackColor = true;
            this.submitbutton.Click += new System.EventHandler(this.submitbutton_Click);
            // 
            // betraginput
            // 
            this.betraginput.DecimalPlaces = 2;
            this.betraginput.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.betraginput.Location = new System.Drawing.Point(63, 139);
            this.betraginput.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.betraginput.Name = "betraginput";
            this.betraginput.Size = new System.Drawing.Size(269, 23);
            this.betraginput.TabIndex = 5;
            // 
            // AddEditBuchung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 178);
            this.Controls.Add(this.betraginput);
            this.Controls.Add(this.submitbutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.beschreibunginput);
            this.Controls.Add(this.datuminput);
            this.Controls.Add(this.konto2input);
            this.Controls.Add(this.konto1input);
            this.Controls.Add(this.beschreibunglabel);
            this.Controls.Add(this.datumlabel);
            this.Controls.Add(this.konto2label);
            this.Controls.Add(this.konto1label);
            this.Controls.Add(this.titlelabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditBuchung";
            ((System.ComponentModel.ISupportInitialize)(this.betraginput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titlelabel;
        private System.Windows.Forms.Label konto1label;
        private System.Windows.Forms.Label konto2label;
        private System.Windows.Forms.Label datumlabel;
        private System.Windows.Forms.Label beschreibunglabel;
        private System.Windows.Forms.TextBox konto1input;
        private System.Windows.Forms.TextBox konto2input;
        private System.Windows.Forms.DateTimePicker datuminput;
        private System.Windows.Forms.TextBox beschreibunginput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button submitbutton;
        private System.Windows.Forms.NumericUpDown betraginput;
    }
}