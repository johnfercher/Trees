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
        void AddBinaryLine(List<DataPoint> dots, OxyColor color);
        void AddDots(List<DataPoint> dots, OxyColor color);
        void AddHorizontalDivider(double x, OxyColor color);
        void AddVerticalDivider(double y, OxyColor color);
        void AddSquare(DataPoint initial, DataPoint final, OxyColor color);

        PlotModel GetPlotModel();
    }
}
