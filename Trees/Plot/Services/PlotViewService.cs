using Plot.Interfaces;
using OxyPlot;
using System.Drawing;
using System.Windows.Forms;
using OxyPlot.WindowsForms;

namespace Plot.Services
{
    class PlotViewService : IPlotViewService
    {
        private PlotView plotView;
        private PlotModel plotModel;

        public PlotViewService()
        {
            plotView = new PlotView();
            plotModel = new PlotModel();

            plotView.Dock = DockStyle.Bottom;
            plotView.Location = new Point(0, 0);
            plotView.Size = new Size(700, 500);
            plotView.TabIndex = 0;
            plotView.Model = plotModel;
        }

        public void SetDock(DockStyle dockStyle)
        {
            plotView.Dock = dockStyle;
        }

        public void SetLocation(Point initialLocation)
        {
            plotView.Location = initialLocation;
        }

        public void SetSize(Size windowSize)
        {
            plotView.Size = windowSize;
        }

        public void SetTabIndex(int index)
        {
            plotView.TabIndex = index;
        }

        public PlotView GetPlotView()
        {
            return plotView;
        }

        public void SetPlotModel(PlotModel plotModel)
        {
            plotView.Model = plotModel;
        }
    }
}
