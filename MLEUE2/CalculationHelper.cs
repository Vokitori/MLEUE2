using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLEUE2
{
    class CalculationHelper
    {
        public static double LOG_10_TO_LOG_2 = Math.Log10(2);

        private CalculationHelper()
        {

        }
        public void HelloWorld()
        {

        }

        public static double Entropy(int positive, int negative)
        {
            int sum = positive + negative;
            if (sum == 0 || positive == 0 || negative == 0)
                return 0;
            double positiveProbability = 1.0 * positive / sum;
            double negativeProbability = 1.0 * negative / sum;
            double entropy = 0;

            entropy = -positiveProbability * Math.Log10(positiveProbability) / LOG_10_TO_LOG_2;
            entropy += -negativeProbability * Math.Log10(negativeProbability) / LOG_10_TO_LOG_2;

            return entropy;
        }

        public static double Gain(double dataSetEntropy, int existsPostitive, int existsNegative,
            int notExistingPositive, int notExistingNegative)
        {
            double sum = existsPostitive + existsNegative + notExistingPositive + notExistingNegative;
            double gain = 0;
            gain = dataSetEntropy - ((existsPostitive + existsNegative) / sum) * Entropy(existsPostitive, existsNegative);
            gain += -((notExistingPositive + notExistingNegative) / sum) * Entropy(notExistingPositive, notExistingNegative);
            return gain;
        }

        public static double GainUsingTotal(double dataSetEntropy, int existsPositive, int existsNegative,
            int positiveTotal, int negativeTotal)
        {
            return Gain(dataSetEntropy, existsPositive, existsNegative, positiveTotal - existsPositive, negativeTotal - existsNegative);
        }
    }
}
