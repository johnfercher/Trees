using Plot.Interfaces;
using OxyPlot;
using System.Drawing;
using System.Windows.Forms;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;

namespace Plot.Services
{
    class RegressionTree : IRegressionTree
    {
        public RegressionTree()
        {

        }

        List<DataPoint> IRegressionTree.DoRegression(List<DataPoint> data)
        {
            List<DataPoint> regression = new List<DataPoint>();
            regression = data;
            return data;
        }
    }
}
