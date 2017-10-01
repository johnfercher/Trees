using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plot.Commons
{
    public class NodeRegression
    {
        int id { get; set; }
        public DataPoint division { get; set; }
        public NodeRegression left { get; set; }
        public NodeRegression right { get; set; } 

        public NodeRegression()
        {
            id = 0;
            division = new DataPoint();
            left = new NodeRegression();
            right = new NodeRegression();
        }
    }
}
