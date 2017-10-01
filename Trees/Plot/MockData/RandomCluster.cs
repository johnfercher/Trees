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

            var amountOfDots = rnd.Next(10, 20);
            var xAdd = rnd.Next(1, 5);
            var yAdd = rnd.Next(1, 5);

            for (int i = 0; i < amountOfDots; i++)
            {
                dots.Add(new DataPoint((rnd.NextDouble() * 2) + xAdd, (rnd.NextDouble() * 2) + yAdd));
            }

            return dots;
        }
    }
}
