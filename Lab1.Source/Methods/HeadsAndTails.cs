using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Source.Methods
{
    internal class HeadsAndTails
    {
        /// <summary>
        /// Method for calculating the number of sequences of coin toss results
        /// </summary>
        /// <param name="tossesNum">Number of tosses</param>
        /// <param name="tailsNum">The minimum number of times the "tail" fell out</param>
        /// <returns></returns>
        public static long CalculateNumOfTailsCombinations(int tossesNum, int tailsNum)
        {
            if(tossesNum == 0) return 0;
            if(tailsNum == 0) return (long)Math.Pow(2, tossesNum);

            long allCombinationsNum = (long)Math.Pow(2, tossesNum);
            long exceptionalSolutionsNum = 0;

            for(int i = 0; i < tailsNum; i++)
            {
                exceptionalSolutionsNum += C(tossesNum, i);
            }

            return allCombinationsNum - exceptionalSolutionsNum;
        }

        private static long C(int n, int k)
        {
            if (k > n) return 0;
            if (k == 0 || k == n) return 1;

            return Factorial(n) / (Factorial(k) * Factorial(n-k));
        }

        private static long Factorial(int n)
        {
            if(n == 0) return 1;

            long result = 1;

            for(int i = n; i > 0; i--)
            {
                result *= i;
            }
            return result;
        }
    }
}
