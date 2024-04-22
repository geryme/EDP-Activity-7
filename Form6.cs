using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using MySql.Data.MySqlClient;
using static buy_and_selldb.buyDB;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using buy_and_selldb;

namespace RymeInformation_System
{
    public partial class Form6 : Form
    {
        private buyDB dbManage;
        public Form6()
        {
            InitializeComponent();
            dbManage = new buyDB();
        }



        private void buttonDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear the existing rows in the DataGridView
                dataGridView1.Rows.Clear();

                // Retrieve all the contents from the database
                var contents = dbManage.GetAllContents();

                // Add each content to the DataGridView
                foreach (var content in contents)
                {
                    dataGridView1.Rows.Add(content.Id, content.Email, content.Password, content.Status);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving contents: " + ex.Message);
            }
        }





        private void button1_Click(object sender, EventArgs e)
        {
            // Hide the current form (Form6)
            this.Hide();

            // Create an instance of the second form (Form4)
            Form4 form4 = new Form4();

            // Show the second form
            form4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Hide the current form (Form6)
            this.Hide();

            // Create an instance of the second form (Form5)
            Form5 form5 = new Form5();

            // Show the second form
            form5.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Hide the current form (Form6)
            this.Hide();

            // Create an instance of the second form (Form8)
            Form8 form8 = new Form8();

            // Show the second form
            form8.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Create an instance of the second form (Form1)
            Form1 form1 = new Form1();

            // Show the second form
            form1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string email = guna2TextBox1.Text;
            string password = guna2TextBox2.Text;
            string status = guna2TextBox3.Text;

            // Check if username and password are not empty
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(status))
            {
                // Check if username already exists
                if (!dbManage.CheckUsernameExists(email))
                {
                    // Insert the new username and password into the database
                    if (dbManage.InsertViewUser(email, password, status))
                    {
                        MessageBox.Show("User added successfully.");

                        // Refresh the DataGridView with updated data
                        RefreshDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add user. Please try again.");
                    }
                }
                else
                {
                    MessageBox.Show("Email already exists. Please choose a different email.");
                }
            }
            else
            {
                MessageBox.Show("Email and Password cannot be empty.");
            }
        }
        private void RefreshDataGridView()
        {
            try
            {
                // Clear the existing rows in the DataGridView
                dataGridView1.Rows.Clear();

                // Retrieve all the contents from the database
                var contents = dbManage.GetAllContents();

                // Add each content to the DataGridView
                foreach (var content in contents)
                {
                    dataGridView1.Rows.Add(content.Id, content.Email, content.Password, content.Status);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while refreshing DataGridView: " + ex.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Check if any row is selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the ID of the selected row
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                // Delete the selected row from the DataGridView
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);

                // Delete the corresponding data from the database
                if (dbManage.DeleteUser(id))
                {
                    MessageBox.Show("User deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to delete user. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
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
