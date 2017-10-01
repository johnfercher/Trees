using OxyPlot;
using OxyPlot.WindowsForms;

namespace Plot.Interfaces
{
    interface IPlotViewService
    {
        void SetDock(System.Windows.Forms.DockStyle dockStyle);
        void SetLocation(System.Drawing.Point initialLocation);
        void SetSize(System.Drawing.Size windowSize);
        void SetTabIndex(int index);
        void SetPlotModel(PlotModel plotModel);
        PlotView GetPlotView();
    }
}
