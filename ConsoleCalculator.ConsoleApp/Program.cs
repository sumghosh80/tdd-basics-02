using System;

namespace ConsoleCalculator.App
{
    class Program
    {
        static void Main()
        {
            try
            {
                var calc = new Calculator();
                ConsoleKeyInfo key;
                Console.WriteLine("Press Ctrl + C to close the program.");
                Console.TreatControlCAsInput = true;

                while (IsKillSwitch(key = Console.ReadKey(true)) == false)
                {
                    Console.Clear();
                    Console.WriteLine(calc.SendKeyPress(key.KeyChar));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }

        private static bool IsKillSwitch(ConsoleKeyInfo key)
        {
            return key.Key == ConsoleKey.C && key.Modifiers == ConsoleModifiers.Control;
        }
    }
}
