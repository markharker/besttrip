using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestTrip
{
    public class Graph
    {
        List<Edge>[] _adjacencyList;
        private int _ver;
        private int _edge;

        public Graph(VertexReader reader, int ver)
        {
            _ver = ver;
            _edge = reader.Edges;
            _adjacencyList = new List<Edge>[_ver];
            for(int i = 0; i < _ver; i++)
            {
                _adjacencyList[i] = new List<Edge>();
            }
           
            foreach(var edge in  reader.ReadEdge())
            {
                AddEdge(edge);
            }
        }

        public void AddEdge(Edge e)
        {
            int vertex = e.From;
            _adjacencyList[vertex].Add(e);
        }
      
        public IEnumerable<Edge> Adj(int v)
        {
            return _adjacencyList[v];
        }
      
        public IEnumerable<Edge> Edges()
        {
            List<Edge> list = new List<Edge>();
            for (int v = 0; v < _ver; v++)
            {
                foreach (Edge e in Adj(v))
                {
                    list.Add(e);
                }
            }
            return list;
        }
      
        public int VertexeCount { get { return _ver; } }
        public int EdgesCount { get { return _edge; } }
    }
}
