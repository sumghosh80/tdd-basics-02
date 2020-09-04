using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    interface ICalculator
    {
        void calculation();
        string SendKeyPress(char key);
    }
}
