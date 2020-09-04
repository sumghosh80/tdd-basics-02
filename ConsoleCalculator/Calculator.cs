using System;
using System.Collections.Generic;
using ConsoleCalculator;
using System.Text;

namespace ConsoleCalculator
{
    public class Calculator : ICalculator
    {
        //0, 1, 2, 3, 4, 5, 6, 7, 8, 9, ., -, +, x, /, s, c, =
        private List<char> ValueList = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', '-', '+', 'x', '/', 's', 'c', '=' };
        private StringBuilder calStr = new StringBuilder();
        CalculatorEntity entity = new CalculatorEntity();

        /// <summary>
        /// Invoked when a key is pressed, checked the key types and do the required operation as per the condition or case. 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string SendKeyPress(char key)
        {
            calStr.Append("").ToString();
            // Add your implementation here.
            if (IsListOfKeys(key))
            {
                if (CalculatorUtility.IsNumber(key))
                {
                    if (calStr.ToString() == "0" && key == '0')
                    {
                        return calStr.ToString();
                    }
                    else if (calStr.ToString() == "0" && key != '0')
                    {
                        calStr.Clear();
                    }
                    //return calStr.Append(key.ToString()).ToString();
                    calStr.Append(key.ToString()).ToString();
                    double.TryParse(calStr.ToString(), out double TotalNum);
                    entity.lastCalcNumber = TotalNum;
                    return calStr.ToString();
                }
                else if (CalculatorUtility.IsDecimalPoint(key))
                {
                    if (calStr.Length > 0 && !calStr.ToString().Contains("."))
                    {
                        return calStr.Append(key.ToString()).ToString();
                    }
                    else
                        return calStr.ToString();
                }
                else if (CalculatorUtility.IsOperator(key))
                {
                    CallConditionalCalc(key);
                }

                else if (IsReset(key))
                {
                    return Reset();
                }
                else if (IsSign(key) && calStr.Length > 0)
                {
                    return ChangeSign();
                }
                return entity.errorChar ?? entity.result.ToString();
            }
            return calStr.ToString();

            //throw new NotImplementedException();
        }

        private void CallConditionalCalc(char key)
        {
            if (entity.lastOperation != '=' && entity.lastOperation != '\0' && string.IsNullOrWhiteSpace(calStr.ToString()))
                entity.lastCalcNumber = entity.result;

            calculation();
            entity.lastOperation = key;
            if (key.Equals('=') && entity.errorChar == null)
            {
                calculation();
                calStr.Append(entity.result.ToString());
            }
            else
                entity.lastCalcOperation = key;
            calStr.Clear();
        }
        /// <summary>
        /// Toggles the sign when s is enterd.
        /// </summary>
        /// <returns></returns>
        private string ChangeSign()
        {
            string tempStr = (double.Parse(calStr.ToString()) * -1).ToString();
            calStr.Clear();
            return calStr.Append(tempStr).ToString();
        }
        private string Reset()
        {
            calStr.Clear();
            entity.result = 0;
            entity.lastCalcNumber = 0;
            entity.lastOperation = '\0';
            entity.lastCalcOperation = '\0';
            return CalculatorEntity.resetChar;
        }

        /// <summary>
        /// checkes if s key is enterd or not for toggling
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private bool IsSign(char key)
        {
            return (Char.ToLower(key).Equals('s')) ? true : false;
        }
        /// <summary>
        /// Checks if reset or not, c key is enterd or not for reset.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private bool IsReset(char key)
        {
            return key.Equals('c') || key.Equals('C');
        }
        /// <summary>
        /// Checks if the entered key is within the defined keys
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public bool IsListOfKeys(char Key)
        {
            return ValueList.Contains(char.ToLower(Key));
        }

        /// <summary>
        /// Do the operation as the key entered. 
        /// </summary>
        public void calculation()
        {

            if (double.TryParse(calStr.ToString(), out double tempStore))
            {
                entity.errorChar = null;
                switch (entity.lastOperation)
                {
                    case '\0':
                        entity.result = tempStore;
                        break;
                    case '+':
                        entity.result += tempStore;
                        break;
                    case '-':
                        entity.result -= tempStore;
                        break;
                    case 'x':
                    case 'X':
                        entity.result *= tempStore;
                        break;
                    case '/':

                        if (tempStore != 0)
                        {
                            entity.result /= tempStore;
                        }
                        else
                            entity.errorChar = "-E-";
                        break;
                    case '=':
                        calStr.Clear();
                        break;
                    default:
                        break;
                }
                
            }
            else if (entity.lastOperation == '=' && string.IsNullOrWhiteSpace(calStr.ToString()))
            {
                switch (entity.lastCalcOperation)
                {
                    case '+':
                        entity.result += entity.lastCalcNumber;
                        break;
                    case '-':
                        entity.result -= entity.lastCalcNumber;
                        break;
                    case 'x':
                    case 'X':
                        entity.result *= entity.lastCalcNumber;
                        break;
                    case '/':
                        entity.result /= entity.lastCalcNumber;
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
