using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plot.Interfaces
{
    interface IClassificationTree
    {
        List<DataPoint> DoClassification(List<DataPoint> classOne, List<DataPoint> classTwo);
    }
}
