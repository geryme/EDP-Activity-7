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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string email = guna2TextBox3.Text;
            string newPassword = guna2TextBox1.Text;
            string confirmPassword = guna2TextBox2.Text;
            buyDB dbManage = new buyDB(); // Create an instance of DatabaseManager
                                          // Check if username, new password, and confirm password are not empty
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(newPassword) && !string.IsNullOrEmpty(confirmPassword))
            {
                // Retrieve the current password for the given username
                string currentPassword = dbManage.GetPassword(email);

                if (currentPassword != null)
                {
                    // Check if new password and confirm password match
                    if (newPassword == confirmPassword)
                    {
                        // Update the password in the database
                        if (dbManage.UpdatePassword(email, newPassword))
                        {
                            MessageBox.Show("Password successfully recovered! Please log in.");
                          
                        // Close the current form and show the login form
                            Form1 loginForm = new Form1();
                            loginForm.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to reset password. Please try again.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("New Password and Confirm Password do not match.");
                    }
                }
                else
                {
                    MessageBox.Show("Email does not exist.");
                }
            }
            else
            {
                MessageBox.Show("Email, New Password, and Confirm Password cannot be empty.");
            }
        }

    

        private void button1_Click(object sender, EventArgs e)
        {
            // Hide the current form (Form3)
            this.Hide();

            // Create an instance of the second form (Form2)
            Form2 form2 = new Form2();

            // Show the second form
            form2.Show();
        }

        
    }
}
