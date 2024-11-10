using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string infix = "x+y*z";
        string postfix = InfixToPostfix(infix);
        string prefix = InfixToPrefix(infix);

        Console.WriteLine("Infix: " + infix);
        Console.WriteLine("Postfix: " + postfix);
        Console.WriteLine("Prefix: " + prefix);
        Console.ReadKey();
    }

    static string InfixToPostfix(string infix)
    {
        string result = "";
        Stack<char> stack = new Stack<char>();
        foreach (char ch in infix)
        {
            if (char.IsLetterOrDigit(ch))
            {
                result += ch;
            }
            else
            {
                while (stack.Count > 0 && Precedence(ch) <= Precedence(stack.Peek()))
                {
                    result += stack.Pop();
                }
                stack.Push(ch);
            }
        }
        while (stack.Count > 0)
        {
            result += stack.Pop();
        }
        return result;
    }

    static string InfixToPrefix(string infix)
    {
        Stack<string> stack = new Stack<string>();
        string result = "";
        for (int i = infix.Length - 1; i >= 0; i--)
        {
            char ch = infix[i];
            if (char.IsLetterOrDigit(ch))
            {
                result = ch + result;
            }
            else
            {
                while (stack.Count > 0 && Precedence(ch) < Precedence(stack.Peek()[0]))
                {
                    result = stack.Pop() + result;
                }
                stack.Push(ch.ToString());
            }
        }
        while (stack.Count > 0)
        {
            result = stack.Pop() + result;
        }
        return result;
    }

    static int Precedence(char op)
    {
        return op == '+' || op == '-' ? 1 : op == '*' || op == '/' ? 2 : 0;
    }
}
