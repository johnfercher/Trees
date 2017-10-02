using OxyPlot;
using OxyPlot.Series;
using Plot.Interfaces;
using Plot.MockData;
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
            var mockData = container.GetInstance<IMockData>();
            var regressionTree = container.GetInstance<IRegressionTree>();
            var classificationTree = container.GetInstance<ClassificationTree>();

            plotModelService.AddTitle("Teste");

            var dots1 = mockData.GetDataPoints();
            var dots2 = mockData.GetDataPoints();

            var divisions = classificationTree.DoClassification(dots1, dots2);

            plotModelService.AddSquare(classificationTree.initial, classificationTree.final, OxyColors.Black);
            plotModelService.AddUtilityValues(divisions, OxyColors.Green);
            
            plotModelService.AddDots(classificationTree.classOne, OxyColors.Red);
            plotModelService.AddDots(classificationTree.classTwo, OxyColors.Blue);

            // plotModelService.AddDots(dots1, OxyColors.Red);
            // plotModelService.AddDots(dots2, OxyColors.Blue);

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
