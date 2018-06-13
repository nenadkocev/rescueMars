using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spaceX
{
    public partial class Intro : Form
    {
        ResourceManager resourceManager = Properties.Resources.ResourceManager;
        int i;
        spaceX.Form1.Level level;
        // sekoja slika od introto se cuva vo resursi i se loadira na klik na Next
        public Intro()
        {
            InitializeComponent();
            pictureBox2.Image = (Image)resourceManager.GetObject("i1");
            i = 1;
            level = Form1.Level.Medium;
        }

        private void Intro_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(i == 4)
            {
                btnUpatstvo.Visible = true;
                button1.Text = "Play";
                button1.BackColor = Color.Red;
                lblTezina.Visible = true;
                gbTezina.Visible = true;

            }
            else if (i == 5)
            {
                if (rbEasy.Checked)
                    level = Form1.Level.Easy;
                else if (rbHard.Checked)
                    level = Form1.Level.Hard;
                this.Close();
            }
            string name = "i" + (++i);
            pictureBox2.Image = (Image)resourceManager.GetObject(name);
        }

        private void btnUpatstvo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Авионот се движи на стрелките LEFT, RIGHT, UP и DOWN. За пукање се користи CTRL. Обиди се да ги избегнеш Астероидите.");
        }

        public Form1.Level getLevel()
        {
            return level;
        }
    }
}
