using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace AbwesendheitsprogrammReworked.Models
{
    internal class User
    {
        private int ID;
        private string Name;
        private string Email;
        private string Password;
        private string PhoneNumber;
        private Absenty? Absenty;

        public User(int id, string name,  string email, string password, string phoneNumber)
        {
            this.ID = id;
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.PhoneNumber = phoneNumber;
            this.Absenty = null;
        } 

        public void executeQuerry(string querryToExecute, bool isProcedure = false)
        {
            using (MySqlConnection conn = new MySqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(querryToExecute, conn);
                    if (isProcedure)
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    }
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    throw;
                }
            }
        }

        public List<User> GetUsers(string username) 
        {
            List<User> users = new List<User>();
            using (MySqlConnection conn = new MySqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    conn.Open();
                    MySqlDataReader dataReader;
                    string query = "SELECT * FROM users where name = @username";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    command.Parameters.Add(new MySqlParameter("@username", username));
                    dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        users.Add(new User(dataReader.GetInt32("id"), dataReader.GetString("name"), dataReader.GetString("email"), dataReader.GetString("password"), dataReader.GetString("telNr")));
                    }
                    return users;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    throw;
                }
            }
        }


        public int getID()
        {
            return ID;
        }

        public string getName()
        {
            return Name;
        }

        public string getEmail()
        {
            return Email;
        }

        public string getPassword()
        {
            return Password;
        }

        public string getPhoneNumber()
        {
            return PhoneNumber;
        }
    }
}
