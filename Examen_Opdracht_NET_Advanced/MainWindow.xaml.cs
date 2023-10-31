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

namespace Examen_Opdracht_NET_Advanced
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         
        MyDbContext context= new MyDbContext();
        public MainWindow()
        {
            Initializer.DbSetInitializer(context);
            InitializeComponent();
            App.MainWindow = this;
            App.context= context;
        }
    }
}
