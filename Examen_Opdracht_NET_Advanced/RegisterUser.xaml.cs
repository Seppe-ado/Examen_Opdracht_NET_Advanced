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
using Examen_Opdracht_NET_Advanced.Models;

namespace Examen_Opdracht_NET_Advanced
{
    /// <summary>
    /// Interaction logic for RegisterUser.xaml
    /// </summary>
    public partial class RegisterUser : Window
    {
        public RegisterUser()
        {
            InitializeComponent();
        }
        private void btRegisterClick(object sender, RoutedEventArgs e)
        {
            if (pwPassword.Password == "" || tbFirstName.Text == "" || tbLastName.Text == "" || tbEmail.Text == "" || tbUsername.Text == "")
            {
                tbMededeling.Text = "All fields must be filled in";
            }
            else if (pwPassword.Password != pwPasswordRepeat.Password)
            {
                tbMededeling.Text = "Passwords do not match";
            }
            else
            {
                User? user = null;
                try
                {
                    user = App.context.Users.First(g => g.UserName == tbUsername.Text);
                }
                catch
                {
                    user = new User { FirstName = tbFirstName.Text, LastName=tbLastName.Text,Email= tbEmail.Text, Password = pwPassword.Password, UserName= tbUsername.Text };
                    App.context.Add(user);
                    App.context.SaveChanges();
                    this.Close();
                }
                tbMededeling.Text = "This username already exists, enter a new Username";
            }
            tbMededeling.Visibility = Visibility.Visible;
        }
    }
}
