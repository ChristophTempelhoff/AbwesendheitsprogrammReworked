using AbwesendheitsprogrammReworked.Controllers;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AbwesendheitsprogrammReworked
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LogInController logInController;
        public MainWindow()
        {
            InitializeComponent();
            logInController = new LogInController(new Models.User(0, "", "", "", ""), this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTB.Text;
            string password = PasswordTB.Password;

            bool isLoggedIn = logInController.tryLogIn(username, password);
        }
    }
}