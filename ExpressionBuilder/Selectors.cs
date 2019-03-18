using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionBuilder
{
    public static class Selectors
    {
        public static Dictionary<string, string> Operators = new Dictionary<string, string>()
        {
            {"+", "Adds the value of one numeric expression to another, or concatenates two strings."},
            {"-", "Finds the difference between two numbers."},
            {"*", "Multiplies the value of two expressions."},
            {"/", "Divides the first operand by the second." }
        };

        public static Dictionary<string, string> Functions = new Dictionary<string, string>()
        {
            {"IF", "IF(Expression, TruePart, FalsePart)\n\rReturns either TruePart or FalsePart, depending on the evaluation of the Boolean Expression."},
            {"AVG", "AVG(Value1, Value2)\n\rReturns the average value of the specified values."},
            {"MIN", "MIN(Value1, Value2)\n\rReturns the minimum value from the specified values." },
            {"MAX", "MAX(Value1, Value2)\n\rReturns the maximum value from the specified values."}
        };
    }
}
