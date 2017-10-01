using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plot.Interfaces
{
    interface IRegressionTree
    {
        List<DataPoint> DoRegression(List<DataPoint> data);
    }
}
