using Plot.Interfaces;
using System.Collections.Generic;
using OxyPlot;
using Plot.Commons;

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

        public List<UtilityValue> DoClassification(List<DataPoint> classOne, List<DataPoint> classTwo)
        {
            List<UtilityValue> classification = new List<UtilityValue>();
            var horizontalUtility = new UtilityValue();
            var verticalUtility = new UtilityValue();

            // Define o quadro de busca
            initial = findInitial(classOne, classTwo);
            final = findFinal(classOne, classTwo);

            horizontalUtility = findBetterHorizontalDivision(classOne, classTwo);
            verticalUtility = findBetterVerticalDivision(classOne, classTwo);

            //  enquanto (pontos restantes em relação aos já removidos forem significativos) {
                    if (horizontalUtility.BetterValue > verticalUtility.BetterValue)
                        classification.Add(horizontalUtility);
                    else
                        classification.Add(verticalUtility);
            //
            //      limpa pontos já processados () "definir se deve limpar os bottom ou top"
            //  }



            return classification;
        }

        // Obtém a melhor divisão na horizontal considerando os elementos a direita e esquerda
        private UtilityValue findBetterHorizontalDivision(List<DataPoint> classOne, List<DataPoint> classTwo)
        {
            UtilityValue horizontalUtility = new UtilityValue();
            horizontalUtility.type = DivisionType.Horizontal;
            
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
                if (actualUtilityBottom >= horizontalUtility.BetterValue)
                {
                    horizontalUtility.BetterValue = actualUtilityBottom;
                    horizontalUtility.X = positionX;
                    horizontalUtility.region = DivisionRegion.InitialFromOrigin;
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
                if (actualUtilityTop >= horizontalUtility.BetterValue)
                {
                    horizontalUtility.BetterValue = actualUtilityTop;
                    horizontalUtility.X = positionX;
                    horizontalUtility.region = DivisionRegion.FinalFromOrigin;
                }
            }

            return horizontalUtility;
        }

        // Obtém a melhor divisão na vertical considerando os elementos de cima e baixo
        private UtilityValue findBetterVerticalDivision(List<DataPoint> classOne, List<DataPoint> classTwo)
        {
            UtilityValue horizontalUtility = new UtilityValue();
            horizontalUtility.type = DivisionType.Vertical;

            for (double positionY = initial.Y; positionY < final.X; positionY += 0.05)
            {
                int amountOfClassOneBottom = 0;
                int amountOfClassTwoBottom = 0;
                double actualUtilityBottom = 1.0;
                int amountOfClassOneTop = 0;
                int amountOfClassTwoTop = 0;
                double actualUtilityTop = 1.0;

                for (int j = 0; j < classOne.Count; j++)
                {
                    if (classOne[j].Y <= positionY)
                    {
                        amountOfClassOneBottom++;
                    }
                }

                for (int j = 0; j < classTwo.Count; j++)
                {
                    if (classTwo[j].Y <= positionY)
                    {
                        amountOfClassTwoBottom++;
                    }
                }

                actualUtilityBottom = utilityFunction(amountOfClassOneBottom, amountOfClassTwoBottom);
                if (actualUtilityBottom >= horizontalUtility.BetterValue)
                {
                    horizontalUtility.BetterValue = actualUtilityBottom;
                    horizontalUtility.Y = positionY;
                    horizontalUtility.region = DivisionRegion.InitialFromOrigin;
                }


                for (int j = 0; j < classOne.Count; j++)
                {
                    if (classOne[j].X > positionY)
                    {
                        amountOfClassOneTop++;
                    }
                }

                for (int j = 0; j < classTwo.Count; j++)
                {
                    if (classTwo[j].X > positionY)
                    {
                        amountOfClassTwoTop++;
                    }
                }

                actualUtilityTop = utilityFunction(amountOfClassOneTop, amountOfClassTwoTop);
                if (actualUtilityTop >= horizontalUtility.BetterValue)
                {
                    horizontalUtility.BetterValue = actualUtilityTop;
                    horizontalUtility.Y = positionY;
                    horizontalUtility.region = DivisionRegion.FinalFromOrigin;
                }
            }

            return horizontalUtility;
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
