﻿using Examen_Opdracht_NET_Advanced.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Examen_Opdracht_NET_Advanced
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal static MyDbContext context = null;
        internal static MainWindow MainWindow= null;
        internal static User LoggedInUser = null;
        internal static Route AppselectedRoute = null;
    }
}
