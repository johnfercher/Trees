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
                      
            var dots1 = mockData.GetDataPoints();
            plotModelService.AddDots(dots1, OxyColors.Red);

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

            container.Register<Plotter>();
        }
    }
}
