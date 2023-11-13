using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Opdracht_NET_Advanced.Models
{
    internal class Route
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Length { get; set; }
        public double Duration { get; set; }

        public List<Progres>? ProgresesRoute { get; set; }
    }
}
