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
    /// Interaction logic for DeleteRoute.xaml
    /// </summary>
    public partial class DeleteRoute : Window
    {
        private Route routed = null;
        public DeleteRoute(String name)
        {
            InitializeComponent();
            routed = App.context.Routes.Where(r => r.Name == name).First();
        }

        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            App.context.Remove(routed);
            App.context.SaveChanges();
            App.MainWindow.refreshList();
            this.Close();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
