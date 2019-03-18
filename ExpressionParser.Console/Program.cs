using ExpressionBuilder;

namespace ExpressionParser.Console
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] expressions = new string[]
                {
                 "[a] + [b]",
                 "[a] + [b] * [c]",
                 "([a] + [b]) * ([c] - [d])",
                 "([a] + [b]) * ([c] - [d])",
                 "([a] + [b] / 3) * ([c] - [d]) - [f] / ([g] + ([h] / [i]) * 6)",
                 "[a] + MAX([b],[c],[d]) - 5 * [e] / (MAX([f],[g]) + 3)",
                 "[a] + MAX([b],[c],MAX([d],[e],[f])) - 0",
                 "[a] + IF([b] + [c] > [d],[b] + [c],[b] - [d]) - [f]",
                 "111111111111111111111111111111111111",
                 "+ [a] + [b]",
                 "[a] + [b] -",
                 "[a] + + [b]",
                 "[a] * / * [b] -",
                 "MA([a],[b],[c]) + [d]",
                 "MAX([a][b][c]) - [d]",
                 "[a] + IFF([b] > 2,[b] + [c],[b] - [c]) - [d]"
                };

            foreach (string x in expressions)
            {
                try
                {
                    var exp = Utility.GetFunctionList(x).ToArray();
                    var root = Parser.GetTree(exp);
                    System.Console.WriteLine($"{x} ---> {root.ToString()}");
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine($"{x} ---> {ex.Message}");

                }
            }
        }
        static void MainOld(string[] args)
        {
            string[][] expressions = new string[][]
                {
                   // new string[]{"a","+", "b", "*", "c", "+", "MAX", "(", "p", ",", "q", ",", "(", "r", "+", "s", ")", "/", "2", "+", "3", ")", "/", "5" },
                   // new string[]{"a","+", "b", "*", "c", "+", "AVG", "(", "p", ",", "q", ",", "(", "r", "+", "s", ")", "/", "2", "+", "3", ")", "/", "5" },
                   // new string[]{"a","+", "b", "*", "c", "+", "MAX", "(", "p", ",", "AVG", "(", "p", ",", "q", ",", "(", "r", "+", "s", ")", "/", "2", "+", "3", ")", ",", "(", "r", "+", "s", ")", "/", "x", "+", "z", ")", "/", "500" },
                   // new string[]{ "MAX","(", "5", ",", "3","+","1", ",", "9" ,",", "10", ")" },
                   //new string[]{ "IF", "(", "5", ">", "3", ",", "9" ,",", "10", ")" },
                   new string[]{ "IF", "(", "5", ">","(", "3","+", "MAX", "(", "1", ",", "2",")", ")", ",", "9" ,",", "10", ")" }
                };

            foreach (string[] x in expressions)
            {
                var root = Parser.GetTree(x);
                System.Console.WriteLine($"{string.Concat(x)} ---> {root.ToString()}");
            }
        }
    }
}
