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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Hide the current form (Form2)
            this.Hide();

            // Create an instance of the second form (Form2)
            Form3 form3 = new Form3();

            // Show the second form
            form3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Hide the current form (Form2)
            this.Hide();

            // Create an instance of the second form (Form1)
            Form1 form1 = new Form1();

            // Show the second form
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Display the message box with the desired message
            MessageBox.Show("The Code: 12345");
        }
    }
}
