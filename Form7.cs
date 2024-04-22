using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using buy_and_selldb;

namespace RymeInformation_System
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Hide the current form (Form7)
            this.Hide();

            // Create an instance of the second form (Form1)
            Form1 form1 = new Form1();

            // Show the second form
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string newEmail = guna2TextBox1.Text;
            string newPassword = guna2TextBox2.Text;
            string confirmPassword = guna2TextBox5.Text;
            buyDB dbManage = new buyDB(); // Create an instance of DatabaseManager
                                          // Check if email, password, and confirm password are not empty
            if (!string.IsNullOrEmpty(newEmail) && !string.IsNullOrEmpty(newPassword) && !string.IsNullOrEmpty(confirmPassword))
            {
                // Check if new password and confirm password match
                if (newPassword == confirmPassword)
                {
                    // Insert the new user into the database
                    if (dbManage.InsertUser(newEmail, newPassword))
                    {
                        MessageBox.Show("New user created successfully! Please log in.");

                        // Close the current form and show the login form
                        Form1 loginForm = new Form1();
                        loginForm.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create user. Please try again.");
                    }
                }
                else
                {
                    MessageBox.Show("Password and Confirm Password do not match.");
                }
            }
            else
            {
                MessageBox.Show("Email, Password, and Confirm Password cannot be empty.");
            }
        
         }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
