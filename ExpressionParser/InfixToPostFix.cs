﻿namespace ExpressionParser
{
    using System;
    using System.Collections.Generic;

    /* c# implementation to convert infix expression to postfix*/
    // Note that here we use Stack class for Stack operations 

    public class Test
    {
        // A utility function to return precedence of a given operator 
        // Higher returned value means higher precedence 
        internal static int Prec(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                    return 1;

                case '*':
                case '/':
                    return 2;

                case '^':
                    return 3;
            }
            return -1;
        }

        // The main method that converts given infix expression 
        // to postfix expression. 
        public static string infixToPostfix(string exp)
        {
            // initializing empty String for result 
            string result = "";

            // initializing empty stack 
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < exp.Length; ++i)
            {
                char c = exp[i];

                // If the scanned character is an operand, add it to output. 
                if (char.IsLetterOrDigit(c))
                {
                    result += c;
                }

                // If the scanned character is an '(', push it to the stack. 
                else if (c == '(')
                {
                    stack.Push(c);
                }

                // If the scanned character is an ')', pop and output from the stack 
                // until an '(' is encountered. 
                else if (c == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        result += stack.Pop();
                    }

                    if (stack.Count > 0 && stack.Peek() != '(')
                    {
                        return "Invalid Expression"; // invalid expression 
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                else // an operator is encountered 
                {
                    while (stack.Count > 0 && Prec(c) <= Prec(stack.Peek()))
                    {
                        result += stack.Pop();
                    }
                    stack.Push(c);
                }

            }

            // pop all the operators from the stack 
            while (stack.Count > 0)
            {
                result += stack.Pop();
            }

            return result;
        }

        // Driver method 
        public static void Main(string[] args)
        {
            string exp = "a+b*(c^d-e)^(f+g*h)-i";
            Console.WriteLine(infixToPostfix(exp));
        }
    }

    // This code is contributed by Shrikant13 

}
