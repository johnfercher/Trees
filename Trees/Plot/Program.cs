using OxyPlot;
using OxyPlot.Series;
using Plot.Interfaces;
using Plot.MockData;
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
            var mockData = container.GetInstance<IMockData>();
            var regressionTree = container.GetInstance<IRegressionTree>();

            plotModelService.AddFunction(new FunctionSeries(Math.Sin, 0, 10, 0.1, "sin(x)"));

            var dots = mockData.GetDataPoints();
            plotModelService.AddDots(dots, OxyColors.Red);

            var regressionDots = regressionTree.DoRegression(dots);
            plotModelService.AddDots(regressionDots, OxyColors.Blue);

            plotModelService.AddTitle("Teste");

            plotViewService.SetPlotModel(plotModelService.GetPlotModel());

            Application.Run(new Plotter(plotViewService.GetPlotView()));
        }

        static void Bootstrap()
        {
            container = new Container();

            container.Register<IPlotViewService, PlotViewService>();
            container.Register<IPlotModelService, PlotModelService>();
            container.Register<IMockData, SinWithNoise>();
            container.Register<IRegressionTree, RegressionTree>();

            container.Register<Plotter>();
        }
    }
}
