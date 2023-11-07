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
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
            tbFirstName.Text= App.LoggedInUser.FirstName;
            tbLastName.Text = App.LoggedInUser.LastName;
            tbEmail.Text = App.LoggedInUser.Email;
            tbUsername.Text = App.LoggedInUser.UserName;
            pwPassword.Password = App.LoggedInUser.Password;
            pwPasswordRepeat.Password = App.LoggedInUser.Password;
        }

       

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            User? todelete = null;
            todelete = App.LoggedInUser;
            App.MainWindow.realLogoff();
            App.context.Remove(todelete);
            App.context.SaveChanges();
            App.MainWindow.refreshList();
            this.Close();
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
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
                    App.LoggedInUser.UserName = tbUsername.Text;
                    App.LoggedInUser.Email = tbEmail.Text;
                    App.LoggedInUser.FirstName = tbFirstName.Text;
                    App.LoggedInUser.LastName = tbLastName.Text;
                    App.LoggedInUser.Password= pwPassword.Password;

                    
                    App.context.SaveChanges();
                    App.MainWindow.refreshList();
                    this.Close();
                }
                if (user.UserName == tbUsername.Text && App.LoggedInUser.UserName != user.UserName)
                {
                    tbMededeling.Text = "This username already exists, enter a new Username";
                }else
                {
                    App.LoggedInUser.UserName = tbUsername.Text;
                    App.LoggedInUser.Email = tbEmail.Text;
                    App.LoggedInUser.FirstName = tbFirstName.Text;
                    App.LoggedInUser.LastName = tbLastName.Text;
                    App.LoggedInUser.Password = pwPassword.Password;


                    App.context.SaveChanges();
                    App.MainWindow.refreshList();
                    this.Close();
                }
               
            }
            tbMededeling.Visibility = Visibility.Visible;
        }
    }
}
