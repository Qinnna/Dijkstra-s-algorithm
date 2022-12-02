using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace графы
{
    public partial class Form1 : Form
    {
        private Loader l = new Loader("graph2.csv");
        private Graph gr;
        private GraphPainter gp;
        private Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            var d = l.Load();
            gr = new Graph(d);
            gp = new GraphPainter(gr);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            gp.Paint(e.Graphics);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != numericUpDown2.Value)
            {
                gp.PaintSolution(g, (int)(numericUpDown1.Value - 1), (int)(numericUpDown2.Value) - 1);
            }
            else gp.Paint(g);
        }
    }
}
