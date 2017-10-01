using Plot.Interfaces;
using OxyPlot;
using System.Drawing;
using System.Windows.Forms;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;

namespace Plot.Services
{
    class RegressionTree : IRegressionTree
    {
        public RegressionTree()
        {

        }

        List<DataPoint> IRegressionTree.DoRegression(List<DataPoint> data)
        {
            List<DataPoint> regression = new List<DataPoint>();

            for (double i = 0.0; i < 10.0; i += 0.5)
            {
                regression.Add(GetMinErrorFromZByPoint(data, i, i+0.5));
            }
           
            return regression;
        }

        DataPoint GetMinErrorFromZByPoint(List<DataPoint> points, double xInitial, double xFinal)
        {
            List<DataPoint> rangePoints = new List<DataPoint>();

            foreach (var point in points)
            {
                if (point.X >= xInitial && point.X <= xFinal)
                {
                    rangePoints.Add(point);
                }
            }

            int indexMin = 0;
            double minError = 999999999.0;

            for (int i = 0; i < rangePoints.Count; i++)
            {
                double actualError = 0.0;

                for (int j = 0; j < rangePoints.Count; j++)
                {
                    if (i != j)
                    {
                        actualError += Math.Pow((Math.Abs(rangePoints[i].Y - rangePoints[j].Y)), 2);
                    }
                } 
                
                if(actualError < minError)
                {
                    minError = actualError;
                    indexMin = i;
                } 
            }


            return rangePoints[indexMin];
        }
    }
}
