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
    /// Interaction logic for AddRoute.xaml
    /// </summary>
    public partial class AddRoute : Window
    {
        public AddRoute()
        {
            InitializeComponent();
        }

        private void btRegister_Click(object sender, RoutedEventArgs e)
        {
            if ( tbRouteName.Text == "" || tbDescription.Text == "" || tbDuration.Text == "" || tbDistance.Text == "")
            {
                tbMededeling.Text = "All fields must be filled in";
            }
            
            else
            {
                Route? route = null;
                try
                {
                    route = App.context.Routes.First(g => g.Name == tbRouteName.Text);
                }
                catch
                {
                    route = new Route { Name=tbRouteName.Text, Description=tbDescription.Text, Length=int.Parse(tbDistance.Text), Duration=int.Parse(tbDuration.Text) };
                    App.context.Add(route);
                    App.context.SaveChanges();
                    App.MainWindow.refreshList();
                    this.Close();
                }
                tbMededeling.Text = "This Route Name already exists, enter a new Route Name";
            }
            tbMededeling.Visibility = Visibility.Visible;
        }
    }
}
