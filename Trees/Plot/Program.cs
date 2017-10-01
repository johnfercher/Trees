using OxyPlot;
using OxyPlot.Series;
using Plot.Interfaces;
using Plot.Services;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Core.Plotter
{
    static class Program
    {
        private static Container container;

        [STAThread]
        static void Main()
        { 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bootstrap();

            var plotViewService = container.GetInstance<IPlotViewService>();
            var plotModelService = container.GetInstance<IPlotModelService>();

            var dots = new List<DataPoint>();
            Random rnd = new Random();
            for (double i = 0; i < 10; i += 0.05)
            {
                // if(rnd.Next(1,3) % 2 == 0)
                    dots.Add(new DataPoint( i + (rnd.Next(-15, 15) / 100.0), Math.Sin(i) + (rnd.Next(-15, 15)/100.0) ));
            }

            plotModelService.AddFunction(new FunctionSeries(Math.Sin, 0, 10, 0.1, "sin(x)"));
            plotModelService.AddDots(dots, OxyColors.Red);
            plotModelService.AddTitle("Teste");

            plotViewService.SetPlotModel(plotModelService.GetPlotModel());

            Application.Run(new Plotter(plotViewService.GetPlotView()));
        }

        static void Bootstrap()
        {
            container = new Container();

            container.Register<IPlotViewService, PlotViewService>();
            container.Register<IPlotModelService, PlotModelService>();
            container.Register<Plotter>();
        }
    }
}
