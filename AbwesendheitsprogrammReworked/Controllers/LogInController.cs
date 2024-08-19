using AbwesendheitsprogrammReworked.Models;
using AbwesendheitsprogrammReworked.Utils;

namespace AbwesendheitsprogrammReworked.Controllers
{
    internal class LogInController
    {
        User model;
        MainWindow view;

        public LogInController(User model, MainWindow view)
        {
            this.model = model;
            this.view = view;

            this.instiateTables();
        }

        private void instiateTables() 
        {
            model.executeQuerry("CreateTables");
        }

        public bool tryLogIn(string username, string password)
        {
            bool isLoggedIn = false;

            List<User> users = model.GetUsers(username);
            foreach (User user in users)
            {
                if (user.getName() == username && Cryptography.ValidatePassword(password, user.getPassword())) { return true; }
            }

            return isLoggedIn;
        }
    }
}
