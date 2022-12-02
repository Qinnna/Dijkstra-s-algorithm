using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace графы
{
    public class GraphPainter
    {
        private Graph _graph;
        private int vertexSize = 30;
        private int dist = 120;
        public GraphPainter(Graph graph)
        {
            _graph = graph;
        }
        public void Paint(Graphics g)
        {
           g.SmoothingMode = SmoothingMode.AntiAlias;
           PaintEdges(g, _graph.e, Color.Green);
           PaintVertices(g);
        }
        public void PaintSolution(Graphics g, int v1, int v2)
        {
            var sol = _graph.ShortestPath(v1, v2);
            PaintEdges(g, _graph.e, Color.Green);            
            PaintEdges(g, sol, Color.DarkRed);
            PaintVertices(g);
        }
        private void PaintVertices(Graphics g)
        {
             g.ResetTransform();
             var r = Rectangle.Ceiling(g.VisibleClipBounds);
             g.TranslateTransform(r.Width / 2, r.Height / 2);
             PointF curPoint = new PointF();
             var radius = dist / (2 * Math.Sin(Math.PI / _graph.VertexCount)); //Радиус описанной окружности вокруг правильного многоугольника со стороной равной расстоянию между вершинами 
             var alpha = (2 * Math.PI) / _graph.VertexCount; //Угол на который поворачиваем вершины
             curPoint.X = (float)radius;
             curPoint.Y = 0;
             PointF temp = curPoint;
             Font font = new Font("Arial", vertexSize/2, FontStyle.Bold);
             for (int i = 0; i < _graph.VertexCount; i++)
             {
                g.FillEllipse(
                     Brushes.LightCyan,
                     curPoint.X - vertexSize,
                     curPoint.Y - vertexSize,
                     vertexSize * 2,
                     vertexSize * 2
                     );
                g.DrawEllipse(
                     new Pen(Color.DarkCyan, 2),
                     curPoint.X - vertexSize,
                     curPoint.Y - vertexSize,
                     vertexSize * 2,
                     vertexSize * 2
                     );
                 g.DrawString((_graph.v[i].Number + 1).ToString(), font, Brushes.Black, curPoint.X - 3*vertexSize/8, curPoint.Y -3*vertexSize/8);
                 temp = curPoint;
                 curPoint.X = (float)(temp.X * Math.Cos(alpha) - temp.Y * Math.Sin(alpha));
                 curPoint.Y = (float)(temp.X * Math.Sin(alpha) + temp.Y * Math.Cos(alpha));
             }
        }

        private void PaintEdges(Graphics g, List<Edge> e, Color color)
        {
            g.ResetTransform();
            var r = Rectangle.Ceiling(g.VisibleClipBounds);
            g.TranslateTransform(r.Width / 2, r.Height / 2);
            PointF StartPoint = new PointF();
            PointF p1 = new PointF();
            PointF p2 = new Point();
            var radius = dist / (2 * Math.Sin(Math.PI / _graph.VertexCount)); //Радиус описанной окружности вокруг правильного многоугольника со стороной равной расстоянию между вершинами 
            var alpha = (2 * Math.PI) / _graph.VertexCount; //Угол на который поворачиваем вершины
            StartPoint.X = (float)radius;
            StartPoint.Y = 0;
            Font font = new Font("Times New Roman", vertexSize / 2, FontStyle.Italic);
            if (e is null) return;
            foreach (var edge in e)
            {
                p1.X = (float) (StartPoint.X * Math.Cos(alpha * edge.Vertices[0].Number));
                p1.Y = (float)(StartPoint.X * Math.Sin(alpha * edge.Vertices[0].Number));
                p2.X = (float)(StartPoint.X * Math.Cos(alpha * edge.Vertices[1].Number));
                p2.Y = (float)(StartPoint.X * Math.Sin(alpha * edge.Vertices[1].Number));
                g.DrawLine(new Pen(color, 2), p1, p2);
                g.DrawString(edge.Weight.ToString(), font, Brushes.DarkViolet, (p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
            }
        }
    }
}
