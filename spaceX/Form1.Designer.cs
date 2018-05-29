namespace spaceX
{
    partial class Form1
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
            this.lblHp = new System.Windows.Forms.Label();
            this.ustekolku = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblHp
            // 
            this.lblHp.AutoSize = true;
            this.lblHp.BackColor = System.Drawing.Color.Black;
            this.lblHp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHp.ForeColor = System.Drawing.Color.White;
            this.lblHp.Location = new System.Drawing.Point(12, 480);
            this.lblHp.Name = "lblHp";
            this.lblHp.Size = new System.Drawing.Size(60, 24);
            this.lblHp.TabIndex = 0;
            this.lblHp.Text = "label1";
            // 
            // ustekolku
            // 
            this.ustekolku.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ustekolku.Location = new System.Drawing.Point(105, 480);
            this.ustekolku.Name = "ustekolku";
            this.ustekolku.Size = new System.Drawing.Size(823, 21);
            this.ustekolku.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 502);
            this.Controls.Add(this.ustekolku);
            this.Controls.Add(this.lblHp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHp;
        private System.Windows.Forms.ProgressBar ustekolku;
    }
}

