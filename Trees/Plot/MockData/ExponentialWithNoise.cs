using OxyPlot;
using Plot.Interfaces;
using System;
using System.Collections.Generic;

namespace Plot.MockData
{
    class ExponentialWithNoise : IMockData
    {
        List<DataPoint> IMockData.GetDataPoints()
        {
            var dots = new List<DataPoint>();
            Random rnd = new Random();
            for (double i = 0; i < 10.0; i += 0.01)
            {
                dots.Add(new DataPoint(i + (rnd.Next(-15, 15) / 100.0), Math.Pow(i, 2) + (rnd.Next(-15, 15) / 100.0)));
            }

            return dots;
        }
    }
}
