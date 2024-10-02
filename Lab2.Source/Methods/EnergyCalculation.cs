using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Source.Methods
{
    public class EnergyCalculation
    {
        /// <summary>
        /// Method for calculation of the minimum value of energy to achieve the goal
        /// </summary>
        /// <param name="platformsNum">Number of platforms</param>
        /// <param name="heights">Array of platforms height values</param>
        /// <returns></returns>
        public static long CalculateMinEnergyValue(ushort platformsNum, ushort[] heights)
        {
            long[] dp = new long[platformsNum];
            dp[0] = 0;
            
            if(platformsNum > 1)
                dp[1] = heights[1] - heights[0];

            for(int i = 2; i < platformsNum; i++)
                dp[i] = Math.Min(
                    dp[i-1] + Math.Abs(heights[i] - heights[i-1]), // neighbours platforms
                    dp[i - 2] + 3 * Math.Abs(heights[i] - heights[i - 2])); // through one platform

            return dp[platformsNum-1];
        }
    }
}
