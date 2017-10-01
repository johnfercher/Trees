using OxyPlot;
using Plot.Interfaces;
using System;
using System.Collections.Generic;

namespace Plot.MockData
{
    class RandomCluster : IMockData
    {
        List<DataPoint> IMockData.GetDataPoints()
        {
            var dots = new List<DataPoint>();
            Random rnd = new Random();

            var amountOfDots = rnd.Next(100, 200);
            var xAdd = rnd.Next(2, 4);
            var yAdd = rnd.Next(2, 4);

            for (int i = 0; i < amountOfDots; i++)
            {
                dots.Add(new DataPoint((rnd.NextDouble() * 2) + xAdd, (rnd.NextDouble() * 2) + yAdd));
            }

            return dots;
        }
    }
}
