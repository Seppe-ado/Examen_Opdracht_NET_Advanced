using Examen_Opdracht_NET_Advanced.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Opdracht_NET_Advanced.Data
{
    internal static class Initializer
    {
        internal static void DbSetInitializer(MyDbContext context) 
        {
            if (!context.Users.Any())
            {
                context.Add( new User { FirstName = "user1", LastName = "-", Email = "-", Password = "-", UserName = "user1" });
                context.Add(new User { FirstName = "user2", LastName = "-", Email = "-", Password = "-", UserName = "user2" });
                context.SaveChanges();
            }
            if (!context.Routes.Any())
            {
                context.Add(new Route { Name = "Route1", Description = "Route1Description", Length = 5, Duration = 65 });
                context.Add(new Route { Name = "Route2", Description = "Route2Description", Length = 6, Duration = 80 });
                context.Add(new Route { Name = "Route3", Description = "Route3Description", Length = 7, Duration = 90 });
                context.Add(new Route { Name = "Route4", Description = "Route4Description", Length = 8, Duration = 110 });
                context.Add(new Route { Name = "Route5", Description = "Route5Description", Length = 9, Duration = 130 });
                context.SaveChanges() ;

            }

            if (!context.Progreses.Any())
            {
                context.Add(new Progres { Comment = "1", Completed=true, DateTime= DateTime.Now, RouteId=1, UserId=1 });
                context.Add(new Progres { Comment = "2", Completed = true, DateTime = DateTime.Now, RouteId = 2, UserId = 1 });
                context.Add(new Progres { Comment = "3", Completed = true, DateTime = DateTime.Now, RouteId = 3, UserId = 1 });
                context.Add(new Progres { Comment = "4", Completed = true, DateTime = DateTime.Now, RouteId = 4, UserId = 1 });
                context.SaveChanges();
            }
       


        }
    }
}
