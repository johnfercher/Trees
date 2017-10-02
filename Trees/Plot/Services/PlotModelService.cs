using System;
using OxyPlot;
using OxyPlot.Series;
using Plot.Interfaces;
using System.Collections.Generic;
using System.Threading;
using Plot.Commons;

namespace Plot.Services
{
    class PlotModelService : IPlotModelService
    {
        private PlotModel plotModel;
        private DataPoint top;
        private DataPoint bottom;

        public PlotModelService()
        {
            plotModel = new PlotModel();
            top = new DataPoint();
            bottom = new DataPoint();
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
            Thread.Sleep(1000);
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
            lineSeries.Points.Add(new DataPoint(x, top.Y));
            lineSeries.Points.Add(new DataPoint(x, bottom.Y));
            plotModel.Series.Add(lineSeries);
        }

        public void AddVerticalDivider(double y, OxyColor color)
        {
            var lineSeries = new LineSeries();
            lineSeries.Color = color;
            lineSeries.Points.Add(new DataPoint(top.X, y));
            lineSeries.Points.Add(new DataPoint(bottom.X, y));
            plotModel.Series.Add(lineSeries);
        }

        public void AddUtilityValues(List<UtilityValue> utilitys, OxyColor color)
        {
            foreach (var utility in utilitys)
            {
                if (utility.type == DivisionType.Horizontal)
                    AddHorizontalDivider(utility.X, color);
                else
                    AddVerticalDivider(utility.Y, color);
            }
                
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

        public void AddSquare(DataPoint initial, DataPoint final, OxyColor color)
        {
            Thread.Sleep(100);
            top = initial;
            bottom = final;

            var lineSeries = new LineSeries();

            lineSeries.Points.Add(initial);
            lineSeries.Points.Add(new DataPoint(final.X, initial.Y));
            lineSeries.Points.Add(final);
            lineSeries.Points.Add(new DataPoint(initial.X, final.Y));
            lineSeries.Points.Add(initial);

            lineSeries.Color = color;
            plotModel.Series.Add(lineSeries);
        }
    }
}
