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
            var classificationTree = container.GetInstance<ClassificationTree>();

            plotModelService.AddTitle("Teste");

            var dots1 = mockData.GetDataPoints();
            plotModelService.AddDots(dots1, OxyColors.Red);

            var dots2 = mockData.GetDataPoints();
            plotModelService.AddDots(dots2, OxyColors.Blue);

            var divisions = classificationTree.DoClassification(dots1, dots2);

            plotModelService.AddSquare(classificationTree.initial, classificationTree.final, OxyColors.Black);
            plotModelService.AddUtilityValues(divisions, OxyColors.Purple);

            plotViewService.SetPlotModel(plotModelService.GetPlotModel());

            Application.Run(new Plotter(plotViewService.GetPlotView()));
        }

        static void Bootstrap()
        {
            container = new Container();

            container.Register<IPlotViewService, PlotViewService>();
            container.Register<IPlotModelService, PlotModelService>();
            container.Register<IMockData, RandomCluster>();
            container.Register<IRegressionTree, RegressionTree>();
            container.Register<IClassificationTree, ClassificationTree>();

            container.Register<Plotter>();
        }
    }
}
