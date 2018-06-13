namespace spaceX
{
    partial class Intro
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnUpatstvo = new System.Windows.Forms.Button();
            this.lblTezina = new System.Windows.Forms.Label();
            this.gbTezina = new System.Windows.Forms.GroupBox();
            this.rbHard = new System.Windows.Forms.RadioButton();
            this.rbMedium = new System.Windows.Forms.RadioButton();
            this.rbEasy = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.gbTezina.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(579, 403);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(223, 429);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 51);
            this.button1.TabIndex = 2;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUpatstvo
            // 
            this.btnUpatstvo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpatstvo.Location = new System.Drawing.Point(417, 429);
            this.btnUpatstvo.Name = "btnUpatstvo";
            this.btnUpatstvo.Size = new System.Drawing.Size(164, 51);
            this.btnUpatstvo.TabIndex = 4;
            this.btnUpatstvo.Text = "How to play";
            this.btnUpatstvo.UseVisualStyleBackColor = true;
            this.btnUpatstvo.Visible = false;
            this.btnUpatstvo.Click += new System.EventHandler(this.btnUpatstvo_Click);
            // 
            // lblTezina
            // 
            this.lblTezina.AutoSize = true;
            this.lblTezina.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTezina.Location = new System.Drawing.Point(597, 100);
            this.lblTezina.Name = "lblTezina";
            this.lblTezina.Size = new System.Drawing.Size(221, 24);
            this.lblTezina.TabIndex = 5;
            this.lblTezina.Text = "Избери тежина на игра";
            this.lblTezina.Visible = false;
            // 
            // gbTezina
            // 
            this.gbTezina.Controls.Add(this.rbHard);
            this.gbTezina.Controls.Add(this.rbMedium);
            this.gbTezina.Controls.Add(this.rbEasy);
            this.gbTezina.Location = new System.Drawing.Point(621, 135);
            this.gbTezina.Name = "gbTezina";
            this.gbTezina.Size = new System.Drawing.Size(185, 118);
            this.gbTezina.TabIndex = 6;
            this.gbTezina.TabStop = false;
            this.gbTezina.Text = "Тежина";
            this.gbTezina.Visible = false;
            // 
            // rbHard
            // 
            this.rbHard.AutoSize = true;
            this.rbHard.Location = new System.Drawing.Point(18, 80);
            this.rbHard.Name = "rbHard";
            this.rbHard.Size = new System.Drawing.Size(72, 17);
            this.rbHard.TabIndex = 2;
            this.rbHard.Text = "I dare you";
            this.rbHard.UseVisualStyleBackColor = true;
            // 
            // rbMedium
            // 
            this.rbMedium.AutoSize = true;
            this.rbMedium.Checked = true;
            this.rbMedium.Location = new System.Drawing.Point(18, 49);
            this.rbMedium.Name = "rbMedium";
            this.rbMedium.Size = new System.Drawing.Size(40, 17);
            this.rbMedium.TabIndex = 1;
            this.rbMedium.TabStop = true;
            this.rbMedium.Text = "OK";
            this.rbMedium.UseVisualStyleBackColor = true;
            // 
            // rbEasy
            // 
            this.rbEasy.AutoSize = true;
            this.rbEasy.Location = new System.Drawing.Point(18, 20);
            this.rbEasy.Name = "rbEasy";
            this.rbEasy.Size = new System.Drawing.Size(60, 17);
            this.rbEasy.TabIndex = 0;
            this.rbEasy.Text = "Not fun";
            this.rbEasy.UseVisualStyleBackColor = true;
            // 
            // Intro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 492);
            this.Controls.Add(this.gbTezina);
            this.Controls.Add(this.lblTezina);
            this.Controls.Add(this.btnUpatstvo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Name = "Intro";
            this.Text = "Intro";
            this.Load += new System.EventHandler(this.Intro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.gbTezina.ResumeLayout(false);
            this.gbTezina.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnUpatstvo;
        private System.Windows.Forms.Label lblTezina;
        private System.Windows.Forms.GroupBox gbTezina;
        private System.Windows.Forms.RadioButton rbHard;
        private System.Windows.Forms.RadioButton rbMedium;
        private System.Windows.Forms.RadioButton rbEasy;
    }
}