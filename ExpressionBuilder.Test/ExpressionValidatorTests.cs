using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ExpressionBuilder.Test
{
    public class ExpressionValidatorTests
    {
        [Test]
        [TestCase("[a] + [b]")]
        [TestCase("[a_1] + [b_1]")]
        [TestCase("[a] + [b] * [c]")]
        [TestCase("([a] + [b]) * ([c] - [d])")]
        [TestCase("([a] + [b]) * ([c] - [d])")]
        [TestCase("([a] + [b] / 3) * ([c] - [d]) - [f] / ([g] + ([h] / [i]) * 6)")]
        [TestCase("[a] + MAX([b],[c],[d]) - 5 * [e] / (MAX([f],[g]) + 3)")]
        [TestCase("[a] + MAX([b],[c],MAX([d],[e],[f])) - 0")]
        [TestCase("[a] + IF([b] + [c] > [d],[b] + [c],[b] - [d]) - [f]")]
        [TestCase("MAX([A],[B],0.09,29)")]
        public void TestValidExpression(string expresssion)
        {
            Assert.IsTrue(ExpressionBuilder.Validate(expresssion));
        }

        [Test]
        [TestCase("+ [a] + [b]")]
        [TestCase("[a] + [b] -")]
        [TestCase("[a] + + [b]")]
        [TestCase("[a] * / * [b] -")]
        [TestCase("MA([a],[b],[c]) + [d]")]
        [TestCase("MAX([a][b][c]) - [d]")]
        [TestCase("[a] + IFF([b] > 2,[b] + [c],[b] - [c]) - [d]")]
        public void TestInvalidExpression(string expression)
        {
            Assert.IsFalse(ExpressionBuilder.Validate(expression));
        }

        [Test]
        [TestCase("[a] + [b] * [c]", "abc")]
        [TestCase("[a_1] + [b_2] * [c]", "a_1b_2c")]
        [TestCase("[a] + [b] * 2", "ab")]
        [TestCase("([ASK] + [BID]) / 2", "ASKBID")]
        public void TestGetFieldNames(string expression, string output)
        {
            Assert.AreEqual(output, string.Join("", ExpressionBuilder.GetFieldsList(expression)));
        }

        [Test]
        [TestCase("[a] + [b]", true)]
        [TestCase("2 + 3", false)]
        public void TestIsExpressionString(string expression, bool output)
        {
            Assert.AreEqual(output, ExpressionBuilder.IsExpressionString(expression));
        }

        [Test]
        [TestCase("([ASK] + [BID]) / 2", 4)]
        [TestCase("MAX([ASK],[BID])", 5)]
        [TestCase("MAX([ASK],[BID],[BETA])", 5)]
        [TestCase("IF([ASK]>2,[ASK],[BID])", 5)]
        [TestCase("[ASK] + 2", 7)]
        [TestCase("[ASK] + MAX([BID],[BETA])", 8)]
        [TestCase("[ASK] + MAX([BID],[BETA], 7)", 12)]
        [TestCase("MAX([ASK],[BID],0.09,29)", 29)]
        //[TestCase("MIN([ASK],[BID],0.09,29)", 0.09)]
        public void TestEvaluate(string expression, double output)
        {
            var fieldsValuesDictionary = new Dictionary<string,object>()
            {
                { "ASK", 5 },
                { "BID", 3 },
                { "BETA", 2 }
            };

            Assert.AreEqual(output, ExpressionBuilder.Evaluate(expression, fieldsValuesDictionary));
        }
    }
}
