using System;

namespace BOG.Framework
{
    /// <summary>
    /// MathEx: some extensions to the basic System.Math library of methods.
    /// </summary>
    public static class MathEx
    {
        /// <summary>
        /// Standard Deviation
        /// </summary>
        /// <param name="data">array of numbers used to perform the calculation</param>
        /// <returns>the std dev as a double</returns>
        public static double StandardDeviation(double[] data)
        {
            double ret = 0;
            double DataAverage = 0;
            double TotalVariance = 0;
            int Max = 0;

            try
            {
                Max = data.Length;
                		
                if (Max == 0) { return ret; }

                DataAverage = Average(data);

                for (int i = 0; i < Max; i++)
                {
                    TotalVariance += Math.Pow(data[i] - DataAverage, 2);
                }

                ret = Math.Sqrt (SafeDivide (TotalVariance,Max));

            }
            catch (Exception) { throw; }
            return ret;
        }

        /// <summary>
        /// Calculates a mean average for a set of numbers.
        /// </summary>
        /// <param name="data">array of numbers to average</param>
        /// <returns>the average as a double</returns>
        public static double Average(double[] data)
        {
            double ret = 0;
            double DataTotal = 0;

            try
            {

              for(int i=0;i<data.Length;i++)
              {
                DataTotal += data[i]; 
              }
              ret = SafeDivide(DataTotal, data.Length);
            }
            catch (Exception) { throw; }
            return ret;
        }

        /// <summary>
        /// An alternative to the divide-by-zero exception.  Returns 0 if the divisor is 0.
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static double SafeDivide(double value1, double value2)
        {
            double ret = 0;

            try
            {

                if ((value1 == 0) || ( value2 == 0))
                {
                    return ret;
                }

                ret =  value1 / value2;
            }
            catch { } 
            return ret;
        }
    }
}

