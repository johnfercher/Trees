using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plot.Commons
{
    class UtilityValue
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double BetterValue { get; set; }
        public DivisionType type { get; set; }
        public DivisionRegion region { get; set; }

        public UtilityValue()
        {
            X = 0.0;
            Y = 0.0;
            BetterValue = 0.0;
            type = DivisionType.Unknown;
            region = DivisionRegion.Unknown;
        }
    }
}
