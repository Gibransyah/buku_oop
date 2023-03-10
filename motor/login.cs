using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace motor
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                new Form1().Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("salah");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }

        }
    }
}
