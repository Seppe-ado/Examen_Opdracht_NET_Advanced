using Examen_Opdracht_NET_Advanced.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ConfirmProgres.xaml
    /// </summary>
    public partial class ConfirmProgres : Window
    {
        private Route routed = null;
        public ConfirmProgres(String name)
        {
            InitializeComponent();
            
            routed = App.context.Routes.Where(r => r.Name == name).First();
        }

        private void btConfirm_Click(object sender, RoutedEventArgs e)
        {
           Progres? progres = null;
            String commented = "";
            if (tbComment != null)
            {
                commented=tbComment.Text;
            } 
            progres = new Progres { Completed=true, DateTime=DateTime.Now,UserId=App.LoggedInUser.Id,RouteId=routed.Id,Comment= commented };
            App.context.Add(progres);
            App.context.SaveChanges();
            App.MainWindow.refreshList();
            App.MainWindow.showRouteDetails();
            this.Close();

        }
    }
}
