using OxyPlot;
using OxyPlot.Series;
using Plot.Interfaces;
using Plot.Services;
using SimpleInjector;
using System;
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

            

            var lineSeries = new LineSeries();
            Random rnd = new Random();
            for (double i = 0; i < 10; i += 0.1)
            {
                lineSeries.Points.Add(new DataPoint(i, Math.Sin(i)+(rnd.Next(1, 13)/100.0)));
            }

            plotModelService.AddLine(lineSeries);
            plotModelService.AddFunction(new FunctionSeries(Math.Sin, 0, 10, 0.1, "sin(x)"));
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
