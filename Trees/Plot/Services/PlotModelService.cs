using System;
using OxyPlot;
using OxyPlot.Series;
using Plot.Interfaces;
using System.Collections.Generic;

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

        public void AddDots(List<DataPoint> dots, OxyColor color)
        {
            foreach (var dot in dots)
            {
                var lineSeries = new LineSeries();
                for (double i = 0.0; i < Math.PI * 3.0; i += 0.2)
                {
                    lineSeries.Points.Add(new DataPoint((Math.Cos(i) + dot.X) * 0.01, (Math.Sin(i) + dot.Y) * 0.01));
                }
                lineSeries.Color = color;
                plotModel.Series.Add(lineSeries);
            }
        }

        public PlotModel GetPlotModel()
        {
            return plotModel;
        }
    }
}
