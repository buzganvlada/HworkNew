using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperationsUsingDelegates
{
        public delegate int MathOperation(int firstNum, int secondNum);

    public class Operation
    {
        public int Add(int firstNum, int secondNum)
        {
            return firstNum + secondNum;
        }
        public int Subtract(int firstNum, int secondNum)
        {
            return secondNum - firstNum;
        }
        public int Multiply(int firstNum, int secondNum)
        {
            return firstNum * secondNum;
        }
        public int Divide(int firstNum, int secondNum)
        {
            return firstNum / secondNum;    
        }
    }
}
