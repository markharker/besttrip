using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestTrip
{
    public class VertexReader
    {
        private Dictionary<string, int> _stLookup;
        private List<string> _keys;
        private string _path;
        private char _separator;
        private int _edges;
        private IEnumerable<string> _lines;
       
        public VertexReader(string path, char separator)
        {
            _path = path;
            _separator = separator;
            _stLookup = new Dictionary<string, int>();
            _keys = new List<string>();
            _lines = File.ReadLines(path);
            _edges = _lines.Count();
        }

        public IEnumerable<Edge> ReadEdge()
        {
            foreach(var line in _lines)
            {
                var tokens = line.Split(_separator);
                AddVertex(tokens[0]);
                AddVertex(tokens[1]);

                Edge edge = new Edge(_stLookup[tokens[0]], 
                                                         _stLookup[tokens[1]],
                                                         double.Parse(tokens[2].Trim()), 
                                                         double.Parse(tokens[3].Trim())
                                                         );
                yield return edge;
            }
        }

        private void AddVertex(string v)
        { 
            if (!_stLookup.ContainsKey(v))
            {
                _stLookup.Add(v, _stLookup.Count());
                _keys.Add(v);
            }
        }

        public int Vertices { get { return _keys.Count(); } }
        public int Edges { get { return _edges; }  }
        public int GetIndex(string name) 
        {
            if (_stLookup.ContainsKey(name))
                return _stLookup[name];
            else
                throw new ArgumentException("Wrong name");
        }
        public string GetName(int index) { return _keys[index]; }
    }
}
