using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLEUE2 {
    class CalculationHelper {

        private CalculationHelper() {

        }
        public void HelloWorld() {

        }

        public static double Entropy(int positive, int negative) {
            int sum = positive + negative;
            double positiveProbability = 1.0 * positive / sum;
            double negativeProbability = 1.0 * negative / sum;
            double log10to2 = Math.Log10(2);
            double entropy;

            entropy = -positiveProbability * Math.Log10(positiveProbability) / log10to2;
            entropy += -negativeProbability * Math.Log10(negativeProbability) / log10to2;

            return entropy;
        }

        public static double Gain(double dataSetEntropy, int existsPostitive, int existsNegative,
            int notExistingPositive, int notExistingNegative) {
            double sum = existsPostitive + existsNegative + notExistingPositive + notExistingNegative;
            double gain = 0;
            gain = dataSetEntropy - (existsPostitive + existsNegative / sum) * Entropy(existsPostitive, existsNegative);
            gain += -(notExistingPositive + notExistingNegative / sum) * Entropy(notExistingPositive, notExistingNegative);
            return gain;
        }

        public static double GainUsingTotal(double dataSetEntropy, int existsPositive, int existsNegative,
            int positiveTotal, int negativeTotal) {
            return Gain(dataSetEntropy, existsPositive, existsNegative, positiveTotal - existsPositive, negativeTotal - existsNegative);
        }
    }
}
