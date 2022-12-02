using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace графы
{
    public class Loader
    {
        private string _filename;
        public Loader(string filename)
        {
            _filename = filename;
        }

        public double[,] Load()
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(_filename);
                double[,] result = null;
                int row = 0;
                while (!sr.EndOfStream)
                {
                    var data = sr.ReadLine();
                    var vals = data.Split(new[] { ';', ' ', '\n', '\r' });
                    if (result == null)
                        result = new double[vals.Length, vals.Length];
                    if (data !=null)
                    {
                        vals = data.Split(new[] { ';', ' ', '\n', '\r' });
                        var col = 0;
                        foreach (var val in vals)
                        {
                            result[row, col++] = double.Parse(val);
                        }
                        row++;
                    }
                }
                return result;
            }
            finally
            {
                sr?.Close();
            }
        }
    }
}
