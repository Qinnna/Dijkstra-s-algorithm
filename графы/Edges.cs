using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace графы
{
    public class Edge
    {
        public double Weight { get; set; }
        private Vertex _v1;
        private Vertex _v2;
        public List<Vertex> Vertices => new List<Vertex>() { _v1, _v2 };

        public Edge(Vertex v1, Vertex v2, double weight)
        {
            _v1 = v1;
            _v2 = v2;
            Weight = weight;
        }
        public bool ConnectedTo(Vertex v) => (v == _v1 || v == _v2);
    }
}
