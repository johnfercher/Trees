using System;
using OxyPlot;
using OxyPlot.Series;
using Plot.Interfaces;
using System.Collections.Generic;
using System.Threading;

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
            Thread.Sleep(100);
            foreach (var dot in dots)
            {
                var lineSeries = new LineSeries();
                for (double i = 0.0; i < Math.PI * 3.0; i += 0.2)
                {
                    lineSeries.Points.Add(new DataPoint((Math.Cos(i) * 0.01) + dot.X, (Math.Sin(i) * 0.01) + dot.Y));
                }
                lineSeries.Color = color;
                plotModel.Series.Add(lineSeries);
            }
        }

        public void AddHorizontalDivider(double x, OxyColor color)
        {
            var lineSeries = new LineSeries();
            lineSeries.Color = color;
            lineSeries.Points.Add(new DataPoint(x, -2.0));
            lineSeries.Points.Add(new DataPoint(x, 2.0));
            plotModel.Series.Add(lineSeries);
        }

        public PlotModel GetPlotModel()
        {
            return plotModel;
        }

        public void AddBinaryLine(List<DataPoint> dots, OxyColor color)
        {
            Thread.Sleep(100);
            var lineSeries = new LineSeries();

            lineSeries.Points.Add(dots[0]);
            for (int i = 0; i < dots.Count - 1; i++)
            {
                lineSeries.Points.Add(new DataPoint((dots[i].X + dots[i + 1].X) / 2.0, dots[i].Y));
                lineSeries.Points.Add(new DataPoint((dots[i].X + dots[i + 1].X) / 2.0, dots[i + 1].Y));
            }
            lineSeries.Points.Add(dots[dots.Count - 1]);

            lineSeries.Color = color;
            plotModel.Series.Add(lineSeries);
        }
    }
}
