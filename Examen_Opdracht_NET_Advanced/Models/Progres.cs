using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Opdracht_NET_Advanced.Models
{
    internal class Progres
    {
        public int Id { get; set; }
        [ForeignKey("Route")]
        public int RouteId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        public string Comment { get; set; }
        public Boolean Completed { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;

        public User? Users { get; set; }
        public Route? Route { get; set; }
    }
}
