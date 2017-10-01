using OxyPlot;
using OxyPlot.WindowsForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Core.Plotter
{
    public partial class Plotter : Form
    {
        private PlotView plotView;

        public Plotter(PlotView _plotView)
        {
            plotView = _plotView;
            Controls.Add(plotView);
            this.Size = new Size(800, 550);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}