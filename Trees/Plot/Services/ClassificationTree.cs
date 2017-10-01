using Plot.Interfaces;
using System.Collections.Generic;
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
            DataPoint betterHorizontalDivison = new DataPoint();
            DataPoint betterVerticalDivison = new DataPoint();

            initial = findInitial(classOne, classTwo);
            final = findFinal(classOne, classTwo);

            betterHorizontalDivison = findBetterHorizontalDivision(classOne, classTwo);
            // betterVerticalDivison; = findBetterHorizontalDivision(classOne, classTwo

            //  enquanto (pontos restantes em relação aos já removidos forem significativos) {
            //      if (vertical é melhor que horizontal)
            //          adiciona vertical ();
            //      se não
            //          adiciona horizontal();
            //
            //      limpa pontos já processados () "definir se deve limpar os bottom ou top"
            //  }

            classification.Add(betterHorizontalDivison);

            return classification;
        }

        // Obtém a melhor divisão na horizontal considerando os elementos a direita e esquerda
        private DataPoint findBetterHorizontalDivision(List<DataPoint> classOne, List<DataPoint> classTwo)
        {
            double betterUtility = 0.0;
            double betterX = 0.0;

            for (double positionX = initial.X; positionX < final.X; positionX += 0.05)
            {
                int amountOfClassOneBottom = 0;
                int amountOfClassTwoBottom = 0;
                double actualUtilityBottom = 1.0;
                int amountOfClassOneTop = 0;
                int amountOfClassTwoTop = 0;
                double actualUtilityTop = 1.0;

                for (int j = 0; j < classOne.Count; j++)
                {
                    if (classOne[j].X <= positionX)
                    {
                        amountOfClassOneBottom++;
                    }
                }

                for (int j = 0; j < classTwo.Count; j++)
                {
                    if (classTwo[j].X <= positionX)
                    {
                        amountOfClassTwoBottom++;
                    }
                }

                actualUtilityBottom = utilityFunction(amountOfClassOneBottom, amountOfClassTwoBottom);
                if (actualUtilityBottom >= betterUtility)
                {
                    betterUtility = actualUtilityBottom;
                    betterX = positionX;
                }


                for (int j = 0; j < classOne.Count; j++)
                {
                    if (classOne[j].X > positionX)
                    {
                        amountOfClassOneTop++;
                    }
                }

                for (int j = 0; j < classTwo.Count; j++)
                {
                    if (classTwo[j].X > positionX)
                    {
                        amountOfClassTwoTop++;
                    }
                }

                actualUtilityTop = utilityFunction(amountOfClassOneTop, amountOfClassTwoTop);
                if (actualUtilityTop >= betterUtility)
                {
                    betterUtility = actualUtilityTop;
                    betterX = positionX;
                }
            }

            return new DataPoint(betterX, 0);
        }

        // Computação Evolutiva pode ser útil nessa parte
        private double utilityFunction(int amountOfClassOne, int amountOfClassTwo)
        {
            double utility = 1.0;
            double purityOfSplit = 1.0;
            double perfectSplitGain = 1.0;
            double miscGain = 1.0;
            double greaterAmount = 0;

            // Da preferêcia por divisões perfeitas
            if ( (amountOfClassOne == 0 && amountOfClassTwo > 0) || (amountOfClassOne > 0 && amountOfClassTwo == 0))
            {
                perfectSplitGain = 5.0;
            }

            // Da preferência por divisões com mais elementos
            if (amountOfClassOne > amountOfClassTwo)
            {
                greaterAmount = amountOfClassOne;
                purityOfSplit = amountOfClassOne / (amountOfClassTwo == 0 ? 1 : amountOfClassTwo);
            }
            else
            {
                greaterAmount = amountOfClassTwo;
                purityOfSplit = amountOfClassTwo / (amountOfClassOne == 0 ? 1 : amountOfClassOne);
            }

            // Da preferência por mistura com poutos elementos
            if (amountOfClassOne > 0 && amountOfClassTwo > 0 && amountOfClassOne + amountOfClassTwo > 10)
                miscGain = greaterAmount / (amountOfClassOne + amountOfClassTwo + 1.0) * 0.1;

            utility = greaterAmount * purityOfSplit * perfectSplitGain * miscGain;

            return utility;
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
