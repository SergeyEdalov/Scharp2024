using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class CalculatorArgs : EventArgs
    {
        public double answer = 0;
    }
    class Calculator
    {
        public event EventHandler<CalculatorArgs> Result;
        public double result { get; private set; }
        Stack<double> results = new Stack<double>();

        private void Calculation()
        {
            Result.Invoke(this, new CalculatorArgs { answer = result });
        }
        public void Add(double value)
        {
            results.Push(result);
            result += value;
            Calculation();
        }
        public void Sub(double value)
        {
            results.Push(result);
            result -= value;
            Calculation();
        }
        public void Mult(double value)
        {
            results.Push(result);
            result *= value;
            Calculation();
        }
        public void Div(double value)
        {
            results.Push(result);
            result /= value;
            Calculation();
        }

        public void Cancel()
        {
            if (results.Count > 0)
            {
                result = results.Pop();
                Calculation();
            }
        }

        //public void ShowResult()
        //{
        //    result = results.Peek();
        //    Calculation();
        //}
    }
}
