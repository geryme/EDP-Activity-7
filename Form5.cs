using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RymeInformation_System
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Hide the current form (Form5)
            this.Hide();

            // Create an instance of the second form (Form4)
            Form4 form4 = new Form4();

            // Show the second form
            form4.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Hide the current form (Form5)
            this.Hide();

            // Create an instance of the second form (Form6)
            Form6 form6 = new Form6();

            // Show the second form
            form6.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Hide the current form (Form5)
            this.Hide();

            // Create an instance of the second form (Form8)
            Form8 form8 = new Form8();

            // Show the second form
            form8.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Hide the current form (Form5)
            this.Hide();

            // Create an instance of the second form (Form1)
            Form1 form1 = new Form1();

            // Show the second form
            form1.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            this.Hide();

            // Create an instance of the second form (Form1)
            Form9 form9 = new Form9();

            // Show the second form
            form9.Show();
        }
    }
}
