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
                context.Add( new User { FirstName = "Bob", LastName = "VanVlaanderen", Email = "bob.vanV@gmail.com", Password = "test", UserName = "user1" });
                context.Add(new User { FirstName = "Bobbette", LastName = "VanDenWalen", Email = "Bobbette.VanDW@gmail.com", Password = "test", UserName = "user2" });
                context.SaveChanges();
            }
            if (!context.Routes.Any())
            {
                context.Add(new Route { Name = "Sentier des Sables", Description = "Through the woods", Length = 10.6, Duration = 2.5 });
                context.Add(new Route { Name = "Brussels Green Walk", Description = "Loop through Brussels", Length = 58.6, Duration = 15 });
                context.Add(new Route { Name = "Red Monastry", Description = "Viscinity of Brussels", Length = 9.5, Duration = 2.5 });
                context.Add(new Route { Name = "Sonian Forest", Description = "Trail through Sonian Forest", Length = 18.8, Duration = 5 });
                context.Add(new Route { Name = "Culture and Arts Tour", Description = "Heart of Brussels", Length = 5, Duration = 1.5 });
                context.SaveChanges() ;

            }

            if (!context.Progreses.Any())
            {
                context.Add(new Progres { Comment = "Such nice forest with so much history!", Completed=true, DateTime= DateTime.Now, RouteId=1, UserId=1 });
                context.Add(new Progres { Comment = "Definitely a route to split up.", Completed = true, DateTime = DateTime.Now, RouteId = 2, UserId = 1 });
                context.Add(new Progres { Comment = "A beautiful monastry", Completed = true, DateTime = DateTime.Now, RouteId = 3, UserId = 1 });
                context.Add(new Progres { Comment = "A stunning forest", Completed = true, DateTime = DateTime.Now, RouteId = 4, UserId = 1 });
                context.SaveChanges();
            }
       


        }
    }
}
