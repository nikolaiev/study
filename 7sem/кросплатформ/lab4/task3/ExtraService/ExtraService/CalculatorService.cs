using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraService
{
    public class CalculatorService : ICalculator
    {
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            return result;
        }
        public double Subtract(double n1, double n2)
        {
            double result = n1 - n2;
            return result;
        }
        public double Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            return result;
        }
        public double Divide(double n1, double n2)
        {
            double result = n1 / n2;
            return result;
        }
        public string Task(int val)
        {
           
            string result = Convert.ToString(val, 2);
            val = 0;
            foreach (char x in result)
            {
                if (x.Equals('1'))
                {
                    val++;
                }

            }
            result += " " + val;

            return result;
        }
    }
}
