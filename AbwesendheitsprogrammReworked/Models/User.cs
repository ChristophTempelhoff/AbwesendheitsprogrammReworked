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
    }
}
