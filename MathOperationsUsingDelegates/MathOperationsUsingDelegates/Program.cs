using MathOperationsUsingDelegates;
using System;

public class ExecutingOperations
{
    static void Main(string[] args)
    {
        Operation operations  = new Operation();
        MathOperation add = new MathOperation(operations.Add);
        var resultAdd = add(4, 6);
        Console.WriteLine(resultAdd);

        MathOperation subtract = new MathOperation(operations.Subtract);
        var resultSubtract = subtract(5, 3);
         Console.WriteLine(resultSubtract);

        MathOperation multiply = new MathOperation(operations.Multiply);
        var resultMultiply = multiply(9, 3);
        Console.WriteLine(resultMultiply);

        MathOperation divide = new MathOperation(operations.Divide);
        var resultDivide = divide(14, 2);
        Console.WriteLine(resultDivide);
    }
}