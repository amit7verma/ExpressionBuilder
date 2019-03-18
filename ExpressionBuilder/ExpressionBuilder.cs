using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionParser;

namespace ExpressionBuilder
{
    public class ExpressionBuilder
    {
        public static bool Validate(string expression)
        {
            var tokens = Utility.GetFunctionList(expression);
            try
            {
                Parser.GetTree(tokens.ToArray());
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public static object Evaluate(string expression, Dictionary<string, object> value)
        {
            var tokens = Utility.GetFunctionList(expression);

            try
            {
                var Tree = Parser.GetTree(tokens.ToArray());
                return Tree.Eval(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //return new NotImplementedException();
        }

        public static List<string> GetFieldsList(string expression)
        {
            if(expression == null)
                return new List<string>();

            return Utility.GetFieldsList(expression);
        }

        public static bool IsExpressionString(string expression)
        {
            if (expression == null)
                return false;

            return Utility.GetFieldsList(expression).Count > 0;
        }
      
    }
}
