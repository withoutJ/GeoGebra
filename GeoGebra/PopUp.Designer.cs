namespace GeoGebra
{
    partial class PopUp
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.potvrdi = new System.Windows.Forms.Button();
            this.tekst = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(280, 20);
            this.textBox1.TabIndex = 0;
            // 
            // potvrdi
            // 
            this.potvrdi.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.potvrdi.Location = new System.Drawing.Point(280, 29);
            this.potvrdi.Name = "potvrdi";
            this.potvrdi.Size = new System.Drawing.Size(100, 22);
            this.potvrdi.TabIndex = 1;
            this.potvrdi.Text = "Potvrdi";
            this.potvrdi.UseVisualStyleBackColor = true;
            this.potvrdi.Click += new System.EventHandler(this.potvrdi_Click);
            // 
            // tekst
            // 
            this.tekst.AutoSize = true;
            this.tekst.Location = new System.Drawing.Point(10, 15);
            this.tekst.Name = "tekst";
            this.tekst.Size = new System.Drawing.Size(25, 13);
            this.tekst.TabIndex = 2;
            this.tekst.Text = "___";
            // 
            // PopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 61);
            this.Controls.Add(this.tekst);
            this.Controls.Add(this.potvrdi);
            this.Controls.Add(this.textBox1);
            this.Name = "PopUp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button potvrdi;
        private System.Windows.Forms.Label tekst;
    }
}