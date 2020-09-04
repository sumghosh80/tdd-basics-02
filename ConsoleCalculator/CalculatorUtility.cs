using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    /// <summary>
    /// Utility class used for common use
    /// </summary>
    public static class CalculatorUtility
    {
        /// <summary>
        /// Checks if decimal point is there or not
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsDecimalPoint(char key)
        {
            return key == '.';
        }
        /// <summary>
        /// Checks if digit or number is there or not
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsNumber(char key)
        {
            return Char.IsDigit(key);
        }
        /// <summary>
        /// Checks if operation is there or not
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsOperator(char key)
        {
            return key == '+' || key == '-' || Char.ToLower(key) == 'x' || key == '/' || key == '=';
        }
    }
}
