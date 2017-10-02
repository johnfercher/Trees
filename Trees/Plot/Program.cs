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

            Application.Run(new Plotter());
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
