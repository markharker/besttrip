using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestTrip
{
    public class Edge
    {
        public Edge(int from, int to, double distance, double profit)
        {
            From = from;
            To = to;
            Distance = distance;
            Profit = profit;
        }

        public double Distance { get; set; }
        public double Profit { get; set; }
        
        public int From { get; set; }
        public int To { get; set; }
       
    }
}
