using Examen_Opdracht_NET_Advanced.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Examen_Opdracht_NET_Advanced
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            User? user = null;
            try
            {
                user = App.context.Users.First(g => g.UserName == tbUsername.Text && g.Password == pwPassword.Password);
            }
            catch
            {
                tbMededeling.Text = "Incorrect Login Attempt";
                tbMededeling.Visibility = Visibility.Visible;
            }
            if (user != null)
            {
                App.LoggedInUser = user;
                App.MainWindow.miProfile.Visibility = Visibility.Visible;
                App.MainWindow.miLogoff.Visibility = Visibility.Visible;
                App.MainWindow.miRegister.Visibility = Visibility.Collapsed;
                App.MainWindow.miLogin.Visibility = Visibility.Collapsed;
                this.Close();
            }
        }
    }
}
