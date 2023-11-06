using Examen_Opdracht_NET_Advanced.Data;
using Microsoft.EntityFrameworkCore.Internal;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Examen_Opdracht_NET_Advanced.Models;
using Examen_Opdracht_NET_Advanced.Data;
using System.Collections;

namespace Examen_Opdracht_NET_Advanced
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Route> routesList = null;
        MyDbContext context= new MyDbContext();
        Route selectedRoute = null;
        List<Progres> allProgreses = null;
        public MainWindow()
        {
            Initializer.DbSetInitializer(context);
            InitializeComponent();
            App.MainWindow = this;
            App.context= context;

            routesList= context.Routes.ToList();
            lbRoutes.ItemsSource = routesList;
            
            
        }

        

        private void lbRoutes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedRoute = (Route)lbRoutes.SelectedItem;
            allProgreses = context.Progreses.Where(c => c.RouteId == selectedRoute.Id).ToList();
            


            if (App.LoggedInUser != null )
            {
                var matches = allProgreses.Where(j => j.UserId == App.LoggedInUser.Id).ToList();
                if (matches.Count > 0)
                {
                    var routeQuerry = from progres in context.Progreses
                                      from route in context.Routes

                                      where route.Id == selectedRoute.Id
                                      && progres.UserId == App.LoggedInUser.Id
                                      && progres.RouteId == selectedRoute.Id
                                      select new { Name = route.Name, Completed = progres.Completed, Description = route.Description, Length = route.Length, Duration = route.Duration };

                    lbDetails.ItemsSource = routeQuerry.ToList();


                } else
                {
                    var routeQuerry2 =
                                          from route in context.Routes

                                          where route.Id == selectedRoute.Id
                                          select new { Name = route.Name, Completed = false, Description = route.Description, Length = route.Length, Duration = route.Duration };

                    lbDetails.ItemsSource = routeQuerry2.ToList();
                }

            }
            else
            {
                var routeQuerry2 =
                                          from route in context.Routes

                                          where route.Id == selectedRoute.Id
                                          select new { Name = route.Name, Completed = false, Description = route.Description, Length = route.Length, Duration = route.Duration };

                lbDetails.ItemsSource = routeQuerry2.ToList();
            }
        }

        private void btAddRoute_Click(object sender, RoutedEventArgs e)
        {
            new AddRoute().Show();
        }

        private void btEditRoute_Click(object sender, RoutedEventArgs e)
        {
            selectedRoute= (Route)lbRoutes.SelectedItem;
            var editRoute = new EditRoute(selectedRoute.Name);
            editRoute.Show();
        }

        private void btConfirmProgres_Click(object sender, RoutedEventArgs e)
        {
            if (App.LoggedInUser != null)
            {
                selectedRoute = (Route)lbRoutes.SelectedItem;
                var confirm = new ConfirmProgres(selectedRoute.Name);
                confirm.Show();
            }
        }

        private void miLoginClick(object sender, RoutedEventArgs e)
        {
            new Login().Show();
        }

        private void miRegisterClick(object sender, RoutedEventArgs e)
        {
            new RegisterUser().Show();
        }

        private void miLogoffClick(object sender, RoutedEventArgs e)
        {
            App.LoggedInUser = null;
            miLogin.Visibility = Visibility.Visible;
            miLogoff.Visibility = Visibility.Collapsed;
            miProfile.Visibility = Visibility.Collapsed;
            miRegister.Visibility = Visibility.Visible;
        }
    }
}
