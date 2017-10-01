using OxyPlot;
using Plot.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plot.Interfaces
{
    interface IClassificationTree
    {
        List<UtilityValue> DoClassification(List<DataPoint> classOne, List<DataPoint> classTwo);
    }
}
