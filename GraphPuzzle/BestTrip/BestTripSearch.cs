using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestTrip
{
    public class BestTripSearch
    {

        private class StateCompar : IComparer<State>
        {

            public int Compare(State x, State y)
            {
                int comp = x.Profit.CompareTo(y.Profit);
              
                // if the weight is the same, use distance
                if (comp == 0)
                {
                    int distComp = x.Distance.CompareTo(x.Distance);
                    return distComp == 0 ? distComp : ~distComp;
                }
                return comp;
            }
        }

        private class State
        {
            internal State(int index, double profit, double distance)
            {
                Index = index;
                Profit = profit;
                Distance = distance;
           }
           
            internal int Index { get; set; }
            internal double Profit { get; set; }
            internal double Distance { get; set; }
         }
        
        int _target;
        int _source;
        private double _pathDistance;
        private double _pathProfit;
        double _maxDistance;
        List<int[]> _paths;
        Csla.C5.IntervalHeap<State> _pq;

        public BestTripSearch(Graph g, int start, int end, double distance)
        { 
             _source = start;
             _target = end;
             _maxDistance = distance;
             LinkedList<int> visited = new LinkedList<int>();
             _paths = new List<int[]>();
             visited.AddLast(start);
             _pq = new Csla.C5.IntervalHeap<State>(new StateCompar());
           
             Search(g, visited);
       }

       private void Search(Graph g, LinkedList<int> visited)
        {
             var nodes =  g.Adj(visited.Last.Value);
              foreach (var edge in nodes)
              {
                  int w = edge.To;
                
                  if (_pathDistance + edge.Distance > _maxDistance)
                      continue;
                                      
                  if (w  == _target)
                  {
                      visited.AddLast(w);
                      _pathDistance += edge.Distance;
                      _pathProfit += edge.Profit;
                      SavePath(visited);
                      Print(visited);
                      visited.RemoveLast();
                      _pathDistance -= edge.Distance;
                      _pathProfit -= edge.Profit;
                  }
              }

              foreach (var edge in nodes)
              {
                  int w = edge.To;
                  if (_pathDistance + edge.Distance > _maxDistance)
                  {
                      continue;
                  }
                   visited.AddLast(w);
                  _pathDistance += edge.Distance;
                  _pathProfit += edge.Profit;
                  Search(g, visited);
                  visited.RemoveLast();
                  _pathDistance -= edge.Distance;
                  _pathProfit -= edge.Profit;
              }
        }
         
        private void SavePath(LinkedList<int> visited)
        {
            _paths.Add(visited.ToArray());
            _pq.Add(new State(_paths.Count() - 1, _pathProfit, _pathDistance ));
       }

       private void Print(LinkedList<int> visited)
        {
            foreach (var node in visited)
            {
                Console.Write(node);
                Console.Write(" ");
            }
            Console.WriteLine();
        }

        public int Count()
        {
            return _paths.Count;
        }

        public IEnumerable<int> Path(int index)
        {
            return _paths[index];
        }

        public double BestProfit()
        {
            return _pq.FindMax().Profit;
        }

        public double BestDistance()
        {
            return _pq.FindMax().Distance;
        }
       
        public int BestTripIndex()
        {
            return  HasPath() ? _pq.FindMax().Index : -1;
        }

        public IEnumerable<int> BestPath()
        {
            return Path(BestTripIndex());
        }

        public bool HasPath()
        {
            return !_pq.IsEmpty;
        }
    }
}
