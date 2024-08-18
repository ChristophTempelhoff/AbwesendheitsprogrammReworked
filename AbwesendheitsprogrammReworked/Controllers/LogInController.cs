using AbwesendheitsprogrammReworked.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
