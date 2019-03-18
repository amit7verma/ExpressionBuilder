using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpressionBuilder.Forms;
using NUnit.Framework;

namespace ExpressionBuilder.Test
{
    public class ExpressionEditorTest
    {
        [Test]
        public void RunForm()
        {
            using (var form = new ExpressionBuilderForm())
            {
                var result = form.ShowDialog();
                if (result != DialogResult.OK) return;

                var val = form.Expression; //values preserved after close
                Assert.AreEqual("a + b", val);
            }
        }
    }
}
