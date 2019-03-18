using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionBuilder.Test
{
    public class UtilityTest
    {
        [Test]
        [TestCase("[a] + [b] / 2")]
        [TestCase("([a] + [b]) * [c] / ([d] - [e])")]
        public void TestGetToken(string input)
        {
            var tokens = Utility.GetTokensList(input);
            string tokenVal = string.Join("", tokens);

            Assert.AreEqual(input.Replace(" ", ""), tokenVal);
        }

        [Test]
        [TestCase("([a] + [b]) / IF([c] > 2, [a] + 1, [b] + 1) ", "IF")]
        [TestCase("([a] + [b]) / TEST([c] > 2, [a] + 1, [b] + 1) ", "TEST")]
        public void TestGetTokenWithFunction(string input, string function)
        {
            var tokens = Utility.GetTokensList(input);
            string tokenVal = string.Join("", tokens);

            Assert.AreEqual($"([a]+[b])/{function}([c] > 2, [a] + 1, [b] + 1)", tokenVal);
        }

        [Test, TestCase("IF(MAX(a,b)>MAX(s,t),IF(P>Q,R,S),MAX(X,Y,Z))")]
        public void TestGetTokenWithFunction2(string input)
        {
            var tokens = Utility.GetTokensList(input);
            string tokenVal = string.Join("", tokens);

            Assert.AreEqual($"IF(MAX(a,b)>MAX(s,t),IF(P>Q,R,S),MAX(X,Y,Z))", tokenVal);
        }

        [Test]
        [TestCase("IF(MAX(a,b)>MAX(s,t),IF(P>Q,R,S),MAX(X,Y,Z))")]
        [TestCase("IF(MAX(a,b)>=MAX(s,t),IF(P==Q,R,S),MAX(X,Y,Z))")]
        public void TestGetFunction(string input)
        {
            var tokens = Utility.GetFunctionList(input);
            string tokenVal = string.Join("", tokens);

            Assert.AreEqual(input.Replace(" ", ""), tokenVal);
        }
    }
}
