/*using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace графы
{
    public class GraphPainterr
    {
        private Graph _graph;
        private Graphics _g;
        private int vertexSize = 20;
        private int dist = 100; //между центров вершин 
        public GraphPainterr(Graph graph, Graphics graphics)
        {
            _g = graphics;
            _graph = graph;        
        }
        public void Paint(Graphics graphics)
        {
            _g = graphics;
            PaintEdges(_g);
            PaintVertices(_g);
        }
        private void PaintEdges(Graphics g)
        {
            var r = Rectangle.Ceiling(g.VisibleClipBounds);
            g.TranslateTransform(r.Width / 2, r.Height / 2);
            PointF curPoint = new PointF();
            var radius = dist / (2 * Math.Sin(Math.PI / _graph.VertexCount)); //Радиус описанной окружности вокруг правильного многоугольника со стороной равной расстоянию между вершинами 
            var temp_alpha = (2 * Math.PI) / _graph.VertexCount;
            var alpha = (2 * Math.PI) / _graph.VertexCount;
            curPoint.X = (float)radius;
            curPoint.Y = 0;
            PointF temp = curPoint;
            PointF secPoint = new PointF();
            Vertex secVert;
            for (int i = 0; i < _graph.VertexCount; i++)
            {
                foreach (var item in _graph.e)
                {
                    if (item.ConnectedTo(_graph.v[i]))
                    {
                        if (_graph.v[i] != item.Vertices[0])
                            secVert = item.Vertices[0];
                        else secVert = item.Vertices[1];
                        temp_alpha = ((secVert.Number * Math.PI / 180 * 2 * Math.PI) / _graph.VertexCount);
                        secPoint.X = (float)(curPoint.X * Math.Cos(alpha) - curPoint.Y * Math.Sin(alpha));
                        secPoint.Y = (float)(secPoint.X * Math.Sin(alpha) + secPoint.Y * Math.Cos(alpha));
                        g.DrawLine(new Pen(Color.Green), curPoint.X, curPoint.Y, secPoint.X, secPoint.Y);
                    }
                }
                temp = curPoint;
                curPoint.X = (float)(temp.X * Math.Cos(alpha) - temp.Y * Math.Sin(alpha));
                curPoint.Y = (float)(temp.X * Math.Sin(alpha) + temp.Y * Math.Cos(alpha));
            }
        }
        private void PaintVertices(Graphics g)
        {
            var r = Rectangle.Ceiling(g.VisibleClipBounds);
            //g.TranslateTransform(r.Width / 2, r.Height / 2);
            PointF curPoint = new PointF();
            var radius = dist / (2 * Math.Sin(Math.PI / _graph.VertexCount)); //Радиус описанной окружности вокруг правильного многоугольника со стороной равной расстоянию между вершинами 
            var alpha = (2 * Math.PI) / _graph.VertexCount; //Угол на который поворачиваем вершины
            curPoint.X = (float)radius;
            curPoint.Y = 0;
            PointF temp = curPoint;
            Font font = new Font("Arial", 20, FontStyle.Regular);
            for (int i = 0; i < _graph.VertexCount; i++)
            {
                g.DrawEllipse(
                    new Pen(Color.BlueViolet, 2),
                    curPoint.X - vertexSize,
                    curPoint.Y - vertexSize,
                    vertexSize * 2,
                    vertexSize * 2
                    );
               
                g.DrawString(i.ToString(), font, Brushes.Green, curPoint.X - vertexSize, curPoint.Y - vertexSize);
                temp = curPoint;
                curPoint.X = (float)(temp.X * Math.Cos(alpha) - temp.Y * Math.Sin(alpha));
                curPoint.Y = (float)(temp.X * Math.Sin(alpha) + temp.Y * Math.Cos(alpha));
            }
            
        }
    }
}*/
