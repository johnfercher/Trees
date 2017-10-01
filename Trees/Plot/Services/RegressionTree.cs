using Plot.Interfaces;
using OxyPlot;
using System.Drawing;
using System.Windows.Forms;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using Plot.Commons;

namespace Plot.Services
{
    class RegressionTree : IRegressionTree
    {
        public List<DataPoint> splits { get; set; }
        public int minNumber { get; set; }

        public void SetMinNumberToSplit(int _minNumber)
        {
            minNumber = _minNumber;
        }

        List<DataPoint> IRegressionTree.DoRegression(List<DataPoint> data)
        {
            minNumber = 5;
            List<DataPoint> regression = new List<DataPoint>();
            double xInit = 0.0;

            for (double i = 0.05; i < 10.0; i += 0.05)
            {
                if(HasMinOfNumberOfPointToSplit(data, xInit, i))
                {
                    regression.Add(GetMinErrorFromZByPoint(data, xInit, i));
                    xInit = i;
                    i += 0.05;
                }
            }            
           
            return regression;
        }

        bool HasMinOfNumberOfPointToSplit(List<DataPoint> points, double xInitial, double xFinal)
        {
            bool hasMin = false;
            int number = 0;

            foreach (var point in points)
            {
                if (point.X >= xInitial && point.X <= xFinal)
                {
                    number++;
                }
            }

            if (number >= minNumber)
                hasMin = true;

            return hasMin;
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
