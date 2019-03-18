using System;
using System.Collections.Generic;

namespace ExpressionParser
{
    public class Parser
    {
        public static INode GetTree(string[] tokenizedArray)
        {
            Stack<string> operatorStack = new Stack<string>();
            Stack<INode> operandStack = new Stack<INode>();

            INode root = null;

            short bracketsCount = 0;

            for (int i = 0; i < tokenizedArray.Length; i++)
            {
                root = null;
                var currItem = tokenizedArray[i].Trim();
                TokenType tokenType = GetTokenType(currItem);

                switch (tokenType)
                {
                    case TokenType.MAX:
                        {
                            MAXNode mxNode = new MAXNode();
                            operandStack.Push(mxNode);
                            operatorStack.Push("MAX");
                            i++;
                            break;
                        }
                    case TokenType.AVG:
                        {
                            AVGNode avgNode = new AVGNode();
                            operandStack.Push(avgNode);
                            operatorStack.Push("AVG");
                            i++;
                            break;
                        }
                    case TokenType.IF:
                        {
                            IFNode ifNode = new IFNode();
                            operandStack.Push(ifNode);
                            operatorStack.Push("IF");
                            i++;
                            break;
                        }
                    case TokenType.ARG_SEPARATOR:
                        {
                            var oprtr = operatorStack.Peek();

                            if (oprtr != "MAX" && oprtr != "AVG" && oprtr != "IF")
                            {
                                var rNode = operandStack.Pop();
                                var lNode = operandStack.Pop();
                                oprtr = operatorStack.Pop();
                                root = CreateNode(oprtr, TokenType.OPERATOR, lNode, rNode);
                                operandStack.Push(root);
                            }


                            break;
                        }
                    case TokenType.OPERAND:
                    case TokenType.LITERAL:
                        {
                            var currNode = CreateNode(currItem, tokenType);
                            operandStack.Push(currNode);
                        }
                        break;
                    case TokenType.OPERATOR:

                        if (currItem == "(")
                        {
                            bracketsCount++;
                            operatorStack.Push(currItem);
                            break;
                        }
                        else
                        {
                            if (currItem == ")")
                            {
                                while (true)
                                {
                                    var oprtr = operatorStack.Pop();

                                    if (oprtr == "(")
                                    {
                                        bracketsCount--;
                                        break;
                                    }
                                    else if (oprtr == "MAX")
                                    {
                                        var poppedOperand = operandStack.Pop();
                                        Stack<INode> arguments = new Stack<INode>();
                                        while (!(poppedOperand is MAXNode))
                                        {
                                            arguments.Push(poppedOperand);
                                            poppedOperand = operandStack.Pop();
                                        }

                                        ((MAXNode)poppedOperand).Nodes = arguments.ToArray();
                                        operandStack.Push(poppedOperand);

                                        break;
                                    }
                                    else if (oprtr == "AVG")
                                    {
                                        var poppedOperand = operandStack.Pop();
                                        Stack<INode> arguments = new Stack<INode>();
                                        while (!(poppedOperand is AVGNode))
                                        {
                                            arguments.Push(poppedOperand);
                                            poppedOperand = operandStack.Pop();
                                        }

                                        ((AVGNode)poppedOperand).Nodes = arguments.ToArray();
                                        operandStack.Push(poppedOperand);

                                        break;
                                    }
                                    else if (oprtr == "IF")
                                    {
                                        var poppedOperand = operandStack.Pop();
                                        Stack<INode> arguments = new Stack<INode>(3);
                                        while (!(poppedOperand is IFNode))
                                        {
                                            arguments.Push(poppedOperand);
                                            poppedOperand = operandStack.Pop();
                                        }

                                        var ifNode = ((IFNode)poppedOperand);

                                        ifNode.Condition = arguments.Pop();
                                        ifNode.TrueChild = arguments.Pop();
                                        ifNode.FalseChild = arguments.Pop();

                                        operandStack.Push(poppedOperand);

                                        break;
                                    }

                                    var rNode = operandStack.Pop();
                                    var lNode = operandStack.Pop();
                                    root = CreateNode(oprtr, TokenType.OPERATOR, lNode, rNode);
                                    operandStack.Push(root);
                                }
                                break;
                            }

                            if (operatorStack.Count > 0)
                            {
                                var topOfStack = operatorStack.Peek();
                                var precedenceCurrItem = GetPrecedence(currItem);
                                var precedenceTopOfStack = GetPrecedence(topOfStack);

                                while (precedenceCurrItem <= precedenceTopOfStack)
                                {
                                    var oprtr = operatorStack.Pop();

                                    var rNode = operandStack.Pop();
                                    var lNode = operandStack.Pop();
                                    root = CreateNode(oprtr, TokenType.OPERATOR, lNode, rNode);
                                    operandStack.Push(root);

                                    if (operatorStack.Count == 0)
                                    {
                                        break;
                                    }

                                    topOfStack = operatorStack.Peek();
                                    precedenceTopOfStack = GetPrecedence(topOfStack);
                                }
                            }

                            operatorStack.Push(currItem);

                        }
                        break;
                }
            }

            while (operatorStack.Count > 0 && operandStack.Count > 0)
            {
                var oprtr = operatorStack.Pop();
                var rNode = operandStack.Pop();
                INode lNode = null;
                if (operandStack.Count > 0)
                {
                    lNode = operandStack.Pop();
                }
                else
                {
                    throw new InvalidOperationException($"Could not find second operand for operator '{oprtr}'");
                }

                var localroot = CreateNode(oprtr, TokenType.OPERATOR, lNode, rNode);
                operandStack.Push(localroot);
            }

            if (operatorStack.Count > 0 || operandStack.Count > 1)
            {
                throw new InvalidOperationException($"All operators/operands has not been processed.");

            }
            
            root = operandStack.Pop();

            return root;
        }

        private static Node CreateNode(string value, TokenType nodeType, INode left = null, INode right = null)
        {
            return new Node()
            {
                Value = value,
                NodeType = nodeType,
                LeftChild = left,
                RightChild = right
            };
        }
        public static TokenType GetTokenType(string item)
        {
            switch (item)
            {
                case "*":
                case "+":
                case "-":
                case "/":
                case "%":
                case "^":
                case "(":
                case ")":
                case ">=":
                case "<=":
                case "=":
                case ">":
                case "<":
                case "!=":
                case "<>":
                    return TokenType.OPERATOR;
                case "MAX":
                    return TokenType.MAX;
                case "AVG":
                    return TokenType.AVG;
                case "IF":
                    return TokenType.IF;
                case ",":
                    return TokenType.ARG_SEPARATOR;
            }
            if (item.IsNumeric())
            {
                return TokenType.LITERAL;
            }

            return TokenType.OPERAND;
        }

        //public static FunctionTokenType GetFunctionTokenType(string item)
        //{
        //    switch (item)
        //    {
        //        case "IF": return FunctionTokenType.IF;
        //        case "MAX": return FunctionTokenType.MAX;
        //        case ",": return FunctionTokenType.ARG_SEPARATOR;

        //    }
        //    return FunctionTokenType.NULL;
        //}

        private static short GetPrecedence(string item)
        {
            item = item.Trim();
            switch (item)
            {
                //Ref: https://www.programiz.com/csharp-programming/operator-precedence-associativity

                //Equality
                case "=": return 0;
                case "!=": return 0;

                //Relational
                case ">=": return 1;
                case "<=": return 1;
                case ">": return 1;
                case "<": return 1;

                //Additive
                case "+": return 2;
                case "-": return 2;

                //Multiplicative
                case "%": return 3;
                case "/": return 3;
                case "*": return 3;

                //Brackets                
                case "(": return -99;

            }
            return -1;
        }

        private static string[] RemoveOuterMostBracket(string[] array)
        {
            if (array != null && array.Length >= 2)
            {
                var firstIndex = 0;
                var lastIndex = array.Length - 1;

                if (array[firstIndex] == "(" && array[lastIndex] == ")")
                {
                    return array.SubArray(firstIndex + 1, array.Length - 2);
                }
            }
            return array;
        }
    }
}
