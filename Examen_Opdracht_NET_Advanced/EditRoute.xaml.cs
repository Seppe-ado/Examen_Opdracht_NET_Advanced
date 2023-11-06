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
    /// Interaction logic for EditRoute.xaml
    /// </summary>
    /// 

   
    public partial class EditRoute : Window
    {
        private Route routed = null;
        public EditRoute(String name)
        {
            InitializeComponent();
            
            routed= App.context.Routes.Where(r => r.Name == name).First();
            tbRouteName.Text= routed.Name;
            tbDescription.Text= routed.Description;
            tbDuration.Text = routed.Duration.ToString();
            tbDistance.Text=routed.Length.ToString();
           
        }

        private void btRegister_Click(object sender, RoutedEventArgs e)
        {
            if (tbRouteName.Text == "" || tbDescription.Text == "" || tbDuration.Text == "" || tbDistance.Text == "")
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
                    routed.Name = tbRouteName.Text;
                    routed.Description = tbDescription.Text;
                    routed.Duration= int.Parse(tbDuration.Text);
                    routed.Length= int.Parse(tbDistance.Text);
                    
                    App.context.Update(routed);
                    App.context.SaveChanges();
                    
                    this.Close();
                }
                if (route.Id != routed.Id)
                {
                    tbMededeling.Text = "This Route Name already exists, enter a new Route Name";
                } else
                {
                    routed.Name = tbRouteName.Text;
                    routed.Description = tbDescription.Text;
                    routed.Duration = int.Parse(tbDuration.Text);
                    routed.Length = int.Parse(tbDistance.Text);

                    App.context.Update(routed);
                    App.context.SaveChanges();
                    
                    this.Close();
                }
            }
            tbMededeling.Visibility = Visibility.Visible;
        }
    }
}
