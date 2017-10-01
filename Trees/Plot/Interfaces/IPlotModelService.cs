using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plot.Interfaces
{
    interface IPlotModelService
    {
        void AddFunction(FunctionSeries functionSeries);
        void AddTitle(string title);
        void AddLine(LineSeries lineSeries);
        void AddDots(List<DataPoint> dots, OxyColor color);
        PlotModel GetPlotModel();
    }
}
