using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;


namespace buy_and_selldb
{

    // Define the Content class
    public class Content
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Status { get; set; }
    }

    public class OrderReport
    {
        public int Order_No { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }


    internal class buyDB
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        // Constructor
        public buyDB()
        {
            Initialize();
        }

        // Initialize connection properties
        private void Initialize()
        {
            server = "localhost";
            database = "buy_and_selldb";
            uid = "root";
            password = "1234";
            string connectionString;
            connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            connection = new MySqlConnection(connectionString);
        }

        // Open connection to the database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                // Handle any exceptions here
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Close connection to the database
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                // Handle any exceptions here
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Execute SQL query
        public void ExecuteQuery(string query)
        {
            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }

        // Authenticate user
        public bool AuthenticateUser(string email, string password)
        {
            try
            {
                string query = $"SELECT * FROM Users WHERE email = '{email}' AND password = '{password}'";
                var result = ExecuteScalar(query);

                return result != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while authenticating user: " + ex.Message);
                return false;
            }
        }

        // Execute SQL query and return single result
        public object ExecuteScalar(string query)
        {
            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    object result = cmd.ExecuteScalar();
                    CloseConnection();
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while executing query: " + ex.Message);
                return null;
            }
        }

        // Insert new user into the database
public bool InsertUser(string email, string password)
        {
            try
            {
                string query = $"INSERT INTO Users (email, password) VALUES ('{email}', '{password}')";
                ExecuteQuery(query);
                return true; // User inserted successfully
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while inserting user: " + ex.Message);
                return false; // Failed to insert user
            }

        }

        public bool InsertViewUser(string email, string password, string status)
        {
            try
            {
                string query = $"INSERT INTO ViewUsers (email, password, status) VALUES ('{email}', '{password}', '{status}')";
                ExecuteQuery(query);
                return true; // User inserted successfully
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while inserting user: " + ex.Message);
                return false; // Failed to insert user
            }

        }

        // Get password for a given username
        public string GetPassword(string email)
        {
            try
            {
                string query = $"SELECT password FROM Users WHERE email = '{email}'";
                return ExecuteScalar(query) as string;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while getting password: " + ex.Message);
                return null;
            }
        }

        // Update password for a given username
        public bool UpdatePassword(string email, string newPassword)
        {
            try
            {
                string query = $"UPDATE Users SET password = '{newPassword}' WHERE email = '{email}'";
                ExecuteQuery(query);
                return true; // Password updated successfully
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating password: " + ex.Message);
                return false; // Failed to update password
            }
        }

        // Get all contents from the database
        public List<Content> GetAllContents()
        {
            List<Content> contents = new List<Content>();

            try
            {
                string query = "SELECT * FROM ViewUsers";
                OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Content content = new Content();
                    content.Id = Convert.ToInt32(dataReader["id"]);
                    content.Email = dataReader["email"].ToString();
                    content.Password = dataReader["password"].ToString();
                    content.Status = dataReader["status"].ToString();
                    contents.Add(content);
                }

                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving contents: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return contents;
        }

        // Check if username exists in the database(ADD)
        public bool CheckUsernameExists(string email)
        {
            try
            {
                string query = $"SELECT COUNT(*) FROM ViewUsers WHERE email = '{email}'";
                OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0; // If count > 0, username exists; otherwise, it doesn't exist
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while checking email: " + ex.Message);
                return false; // Return false in case of any error
            }
            finally
            {
                CloseConnection();
            }
        }

        //DELETE
        public bool DeleteUser(int id)
        {
            try
            {
                string query = $"DELETE FROM ViewUsers WHERE id = {id}";
                OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0; // If rowsAffected > 0, user deleted successfully; otherwise, deletion failed
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting user: " + ex.Message);
                return false; // Return false in case of any error
            }
            finally
            {
                CloseConnection();
            }
        }
        public List<OrderReport> GetAllOrderReports()
        {
            List<OrderReport> orderReports = new List<OrderReport>();

            try
            {
                string query = "SELECT order_no, item, quantity, price FROM orderreport"; // Change column names accordingly
                OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    OrderReport orderReport = new OrderReport();
                    orderReport.Order_No = Convert.ToInt32(dataReader["order_no"]);
                    orderReport.Item = dataReader["item"].ToString();
                    orderReport.Quantity = Convert.ToInt32(dataReader["quantity"]);
                    orderReport.Price = Convert.ToDecimal(dataReader["price"]);
                    // Add other properties as needed
                    orderReports.Add(orderReport);
                }

                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving order reports: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return orderReports;
        }

    }

}
