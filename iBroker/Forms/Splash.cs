using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iBroker.Forms
{
    public partial class Splash : Form
    {
        public int counter = 0;
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            int a = 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;
            if(counter == 3)
            {
                this.Hide();
                new Forms.Home().ShowDialog();
                this.Close();
                timer1.Stop();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
