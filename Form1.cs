using buy_and_selldb;

namespace RymeInformation_System
{
    public partial class Form1 : Form
    {
        private buyDB dbManage;
        public Form1()
        {
            InitializeComponent();
            dbManage = new buyDB();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Hide the current form (Form1)
            this.Hide();

            // Create an instance of the second form (Form2)
            Form2 form2 = new Form2();

            // Show the second form
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = guna2TextBox1.Text;
            string password = guna2TextBox2.Text;

            buyDB dbManage = new buyDB(); // Create an instance of DatabaseManager
            if (dbManage.AuthenticateUser(email, password)) // Call AuthenticateUser method
            {
                // Open the Dashboard form
                Form4 form4 = new Form4();
                form4.Show();
                this.Hide(); // Hide the login form
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }
        private bool AuthenticateUser(string email, string password)
        {
            try
            {
                string query = $"SELECT * FROM Users WHERE email = '{email}' AND password = '{password}'";
                var result = dbManage.ExecuteScalar(query);

                return result != null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while authenticating user: " + ex.Message);
                return false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Hide the current form (Form2)
            this.Hide();

            // Create an instance of the second form (Form1)
            Form7 form7 = new Form7();

            // Show the second form
            form7.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
