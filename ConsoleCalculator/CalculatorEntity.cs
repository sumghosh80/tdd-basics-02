using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    /// <summary>
    /// Common variables for error and reset.
    /// </summary>
    internal class CalculatorEntity
    {
        internal const string resetChar = "0";

        internal string errorChar { get; set; }
        internal char lastOperation { get; set; }
        internal double result { get; set; }
        internal char lastCalcOperation { get; set; }
        internal double lastCalcNumber { get; set; }



        public CalculatorEntity()
        {
            errorChar = null;
            lastOperation = '\0';
            result = 0;
        }
    }


}
