using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExpressionBuilder
{
    public static class Utility
    {
        public static List<string> GetTokensList(string input)
        {
            string pattern = @"[\+\-\*\/\(\)]|\[[\w\d_]+\]|[0-9]|((IF|TEST)\(.+,.+,.+\))";
            var matches = Regex.Matches(input, pattern);

            var output = new List<String>();

            foreach (var m in matches)
                output.Add(m.ToString());

            return output;
        }

        public static List<string> GetFunctionList(string input)
        {
            string pattern = @"IF|MAX|MIN|[0-9]+[.][0-9]+|\(|\)|\,|\w+|>=|<=|==|!=|[><\+\-\*\/]|[0-9]+";
            var matches = Regex.Matches(input, pattern);

            var output = new List<String>();

            foreach (var m in matches)
                output.Add(m.ToString());

            return output;
        }

        public static List<string> GetFieldsList(string input)
        {
            string pattern = @"\[[\w_\d]+\]";
            var matches = Regex.Matches(input, pattern);

            var output = new List<String>();

            foreach (var m in matches)
            {
                var field = m.ToString();
                output.Add(field.Substring(1, field.Length - 2));
            }
                
            return output;
        }
    }
}
