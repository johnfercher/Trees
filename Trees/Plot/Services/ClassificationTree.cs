using Plot.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;

namespace Plot.Services
{
    class ClassificationTree : IClassificationTree
    {
        public DataPoint initial { get; private set; }
        public DataPoint final { get; private set; }

        public ClassificationTree()
        {
            initial = new DataPoint();
            final = new DataPoint();
        }

        public List<DataPoint> DoClassification(List<DataPoint> classOne, List<DataPoint> classTwo)
        {
            List<DataPoint> classification = new List<DataPoint>();
            initial = findInitial(classOne, classTwo);
            final = findFinal(classOne, classTwo);

            return classification;
        }

        private DataPoint findBetterHorizontalDivision(List<DataPoint> classOne, List<DataPoint> classTwo)
        {
            DataPoint betterDivision = new DataPoint();

            return betterDivision;
        }

        private DataPoint findFinal(List<DataPoint> classOne, List<DataPoint> classTwo)
        {
            DataPoint _final = classOne[0];

            for (int i = 0; i < classOne.Count; i++)
            {
                if (classOne[i].X > _final.X)
                    _final = new DataPoint(classOne[i].X, _final.Y);
                
                if (classOne[i].Y > _final.Y)
                    _final = new DataPoint(_final.X, classOne[i].Y);     
            }

            for (int i = 0; i < classTwo.Count; i++)
            {
                if (classTwo[i].X > _final.X)
                    _final = new DataPoint(classTwo[i].X, _final.Y);

                if (classTwo[i].Y > _final.Y)
                    _final = new DataPoint(_final.X, classTwo[i].Y);
            }

            return new DataPoint(_final.X + 0.1, _final.Y + 0.1);
        }

        private DataPoint findInitial(List<DataPoint> classOne, List<DataPoint> classTwo)
        {
            DataPoint _initial = classOne[0];

            for (int i = 0; i < classOne.Count; i++)
            {
                if (classOne[i].X < _initial.X)
                    _initial = new DataPoint(classOne[i].X, _initial.Y);

                if (classOne[i].Y < _initial.Y)
                    _initial = new DataPoint(_initial.X, classOne[i].Y);
            }

            for (int i = 0; i < classTwo.Count; i++)
            {
                if (classTwo[i].X < _initial.X)
                    _initial = new DataPoint(classTwo[i].X, _initial.Y);

                if (classTwo[i].Y < _initial.Y)
                    _initial = new DataPoint(_initial.X, classTwo[i].Y);
            }

            return new DataPoint(_initial.X - 0.1, _initial.Y - 0.1);
        }
    }
}
