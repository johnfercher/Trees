using OxyPlot;
using OxyPlot.WindowsForms;
using Plot.Interfaces;
using Plot.MockData;
using Plot.Services;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Core.Plotter
{
    public partial class Plotter : Form
    {
        private PlotViewService plotViewService;
        private PlotModelService plotModelService;
        private RandomCluster mockData;
        private RegressionTree regressionTree;
        private ClassificationTree classificationTree;

        public Plotter()
        {
            plotViewService = new PlotViewService();
            plotModelService = new PlotModelService();
            mockData = new RandomCluster();
            regressionTree = new RegressionTree();
            classificationTree = new ClassificationTree();

            var dots1x = mockData.GetDataPoints();
            var dots2x = mockData.GetDataPoints();

            var divisionsx = classificationTree.DoClassification(dots1x, dots2x);

            plotModelService.AddSquare(classificationTree.initial, classificationTree.final, OxyColors.Black);
            plotModelService.AddUtilityValues(divisionsx, OxyColors.Green);

            plotModelService.AddDots(classificationTree.classOne, OxyColors.Red);
            plotModelService.AddDots(classificationTree.classTwo, OxyColors.Blue);

            plotModelService.AddTitle("Tentativas = " + classificationTree.loops);

            plotViewService.SetPlotModel(plotModelService.GetPlotModel());

            Controls.Add(plotViewService.GetPlotView());
            this.Size = new Size(1000, 1000);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}