using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionParser
{
    public interface INode
    {
        decimal Eval(Dictionary<string, object> values);
    }

    public class Node : INode
    {
        public string Value { get; set; }
        public INode LeftChild { get; set; }
        public INode RightChild { get; set; }

        public TokenType NodeType { get; set; }
        public override string ToString()
        {
            if (LeftChild != null && RightChild != null)
            {
                return $"({LeftChild.ToString()} {Value} {RightChild.ToString()})";
            }
            else
            {
                return Value;
            }
        }
        public decimal Eval(Dictionary<string, object> values)
        {
            switch (Value)
            {
                case "*":
                    return LeftChild.Eval(values) * RightChild.Eval(values);
                case "+":
                    return LeftChild.Eval(values) + RightChild.Eval(values);
                case "-":
                    return LeftChild.Eval(values) - RightChild.Eval(values);
                case "/":
                    return LeftChild.Eval(values) / RightChild.Eval(values);
                case "%":
                    return LeftChild.Eval(values) % RightChild.Eval(values);


            }

            if (LeftChild == null && RightChild == null)
            {
                if (NodeType == TokenType.LITERAL)
                {
                    return decimal.Parse(Value);
                }
                return Convert.ToDecimal(values[Value]);
            }

            throw new InvalidOperationException();
        }
    }

    public class IFNode : INode
    {

        public decimal Eval(Dictionary<string, object> values)
        {
            Node condition = (Node)(Condition);
            var leftValue = condition.LeftChild.Eval(values);
            var rightValue = condition.RightChild.Eval(values);
            switch (condition.Value)
            {
                //Equality
                case "=":
                    if (leftValue == rightValue)
                    {
                        return TrueChild.Eval(values);
                    }
                    else
                    {
                        return FalseChild.Eval(values);
                    }

                case "!=":
                    if (leftValue != rightValue)
                    {
                        return TrueChild.Eval(values);
                    }
                    else
                    {
                        return FalseChild.Eval(values);
                    }

                //Relational
                case ">=":
                    if (leftValue >= rightValue)
                    {
                        return TrueChild.Eval(values);
                    }
                    else
                    {
                        return FalseChild.Eval(values);
                    }

                case "<=":
                    if (leftValue <= rightValue)
                    {
                        return TrueChild.Eval(values);
                    }
                    else
                    {
                        return FalseChild.Eval(values);
                    }

                case ">":
                    if (leftValue > rightValue)
                    {
                        return TrueChild.Eval(values);
                    }
                    else
                    {
                        return FalseChild.Eval(values);
                    }

                case "<":
                    if (leftValue < rightValue)
                    {
                        return TrueChild.Eval(values);
                    }
                    else
                    {
                        return FalseChild.Eval(values);
                    }
            }

            return FalseChild.Eval(values);
        }

        public INode Condition;
        public INode TrueChild;
        public INode FalseChild;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("IF(");
            sb.Append(Condition.ToString());
            sb.Append(",");

            sb.Append(TrueChild.ToString());
            sb.Append(",");

            sb.Append(FalseChild.ToString());
            sb.Append(")");
            return sb.ToString();
        }
    }


    public class MAXNode : INode
    {
        public INode[] Nodes;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (INode n in Nodes)
            {
                sb.Append($"," + n.ToString());
            }
            sb = sb.Remove(0, 1);
            return $"MAX({sb.ToString()})";
        }
        public decimal Eval(Dictionary<string, object> values)
        {
            decimal max = 0;
            foreach (INode n in Nodes)
            {
                var val = n.Eval(values);
                if (val > max)
                {
                    max = val;
                }
            }
            return max;
        }
    }
    public class AVGNode : INode
    {
        public INode[] Nodes;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (INode n in Nodes)
            {
                sb.Append($"," + n.ToString());
            }
            sb = sb.Remove(0, 1);
            return $"AVG({sb.ToString()})";

        }

        public decimal Eval(Dictionary<string, object> values)
        {
            decimal sum = 0;
            foreach (INode n in Nodes)
            {
                sum = sum + n.Eval(values);
            }
            return (sum / Nodes.Length);
        }
    }

}
