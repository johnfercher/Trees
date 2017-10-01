using System;
using OxyPlot;
using OxyPlot.Series;
using Plot.Interfaces;

namespace Plot.Services
{
    class PlotModelService : IPlotModelService
    {
        private PlotModel plotModel;

        public PlotModelService()
        {
            plotModel = new PlotModel();
        }

        public void AddFunction(FunctionSeries functionSeries)
        {
            plotModel.Series.Add(functionSeries);
        }

        public void AddLine(LineSeries lineSeries)
        {
            plotModel.Series.Add(lineSeries);
        }

        public void AddTitle(string title)
        {
            plotModel.Title = title;
        }

        public PlotModel GetPlotModel()
        {
            return plotModel;
        }
    }
}
