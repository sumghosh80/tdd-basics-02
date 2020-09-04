using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        private Calculator Calc = new Calculator();
        //[Fact]
        //public void DummyTest()
        //{
        //    return;
        //}

        [Fact]
        //Invalid keys other than the given key
        public void IgnoredKeyTest()
        {
            Calc.SendKeyPress('1');
            Calc.SendKeyPress('+');
            Calc.SendKeyPress('2');
            Calc.SendKeyPress('!');
            Assert.Equal("3", Calc.SendKeyPress('='));
        }

        [Fact]

        //Divide by Zero 
        public void DivideByZeroTest()
        {
            Calc.SendKeyPress('1');
            Calc.SendKeyPress('/');
            Calc.SendKeyPress('0');
            Assert.Equal("-E-", Calc.SendKeyPress('='));
        }

        [Fact]
        // Multiple decimal point
        public void MultipleDecimalPointTest()
        {
            Calc.SendKeyPress('0');
            Calc.SendKeyPress('0');
            Calc.SendKeyPress('.');
            Calc.SendKeyPress('.');
            Calc.SendKeyPress('0');
            Calc.SendKeyPress('0');

            Assert.Equal("0.001", Calc.SendKeyPress('1'));
        }

        [Fact]

        //Addition Operation
        public void AdditionTest()
        {
            Calc.SendKeyPress('1');
            Calc.SendKeyPress('+');
            Calc.SendKeyPress('3');
            Calc.SendKeyPress('D');
            //Calc.SendKeyPress('0');
            Assert.Equal("4", Calc.SendKeyPress('='));
        }

        [Fact]
        //Subtration Operation
        public void SubtrationTest()
        {
            Calc.SendKeyPress('5');
            Calc.SendKeyPress('0');
            Calc.SendKeyPress('-');
            Calc.SendKeyPress('2');
            Calc.SendKeyPress('0');
            Assert.Equal("30", Calc.SendKeyPress('='));
        }

        [Fact]

        //Multiplication Operation
        public void MultiplicationTest()
        {
            Calc.SendKeyPress('1');
            Calc.SendKeyPress('0');
            Calc.SendKeyPress('+');
            Calc.SendKeyPress('2');
            Calc.SendKeyPress('X');
            Calc.SendKeyPress('5');
            Assert.Equal("60", Calc.SendKeyPress('='));
        }

        [Fact]
        // Division Operation
        public void DivisionTest()
        {
            Calc.SendKeyPress('1');
            Calc.SendKeyPress('0');
            Calc.SendKeyPress('-');
            Calc.SendKeyPress('2');
            Calc.SendKeyPress('/');
            Calc.SendKeyPress('4');
            Assert.Equal("2", Calc.SendKeyPress('='));
        }

        [Fact]
        // Toggle the sign (s)
        public void ToggleSignTest()
        {
            Calc.SendKeyPress('1');
            Calc.SendKeyPress('2');
            Calc.SendKeyPress('+');
            Calc.SendKeyPress('2');
            Calc.SendKeyPress('s');
            Calc.SendKeyPress('s');
            Calc.SendKeyPress('s');
            Assert.Equal("10", Calc.SendKeyPress('='));
        }

        [Fact]

        // reset (c)
        public void ResetTest()
        {
            Calc.SendKeyPress('5');
            Calc.SendKeyPress('+');
            Calc.SendKeyPress('6');
            Calc.SendKeyPress('+');

            Assert.Equal("0", Calc.SendKeyPress('c'));
        }

        [Fact]
        public void OperatorBeforeEqualtoTest()
        {
            Calc.SendKeyPress('1');
            Calc.SendKeyPress('+');
            Calc.SendKeyPress('2');
            Calc.SendKeyPress('+');
            Calc.SendKeyPress('3');
            Calc.SendKeyPress('/');
            Assert.Equal("1", Calc.SendKeyPress('='));
        }
    }
}
