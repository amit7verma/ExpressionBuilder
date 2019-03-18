using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpressionBuilder.Forms
{
    public partial class ExpressionBuilderForm : Form
    {
        public string Expression { get; private set; }

        private Dictionary<string, List<string>> OpsAndFunctionsValues = new Dictionary<string, List<string>>();

        public ExpressionBuilderForm()
        {
            InitializeComponent();
            FillOpsFuncsListBox();
            this.OpsFuncsListBox.SelectedIndex = 0;
            this.selectorListBox.SelectedIndex = 0;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if(!ExpressionBuilder.Validate(this.editorTextBox.Text)) System.Windows.Forms.MessageBox.Show(@"Invalid Expression");
            this.Expression = this.editorTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FillOpsFuncsListBox()
        {
            this.OpsFuncsListBox.Items.Add("Functions");
            this.OpsFuncsListBox.Items.Add("Operators");
        }
        

        private void FillSelector()
        {
            switch (this.OpsFuncsListBox.SelectedItem.ToString())
            {
                case "Functions":
                    foreach (var key in Selectors.Functions.Keys)
                        this.selectorListBox.Items.Add(key);
                    break;
                case "Operators":
                    //Selectors.Operators.Keys.ForEach(s => this.selectorListBox.Items.Add(s));
                    foreach(var key in Selectors.Operators.Keys)
                        this.selectorListBox.Items.Add(key);
                    break;
            }
        }

        private void FillDescription()
        {
            string desc = string.Empty;
            switch (this.OpsFuncsListBox.SelectedItem.ToString())
            {
                case "Functions":
                    desc = Selectors.Functions[this.selectorListBox.SelectedItem.ToString()];
                    break;
                case "Operators":
                    desc = Selectors.Operators[this.selectorListBox.SelectedItem.ToString()];
                    break;
            }

            this.descriptionTextBox.Text = desc;
        }

        private void On_OpsFuncsSelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectorListBox.Items.Clear();
            FillSelector();
            this.selectorListBox.SelectedIndex = 0;
        }

        private void On_SelectorSelectedIndexChanged(object sender, EventArgs e)
        {
            this.descriptionTextBox.Clear();
            FillDescription();
        }
    }

    //    using (var form = new frmImportContact())
    //{
    //    var result = form.ShowDialog();
    //    if (result == DialogResult.OK)
    //    {
    //        string val = form.ReturnValue1;            //values preserved after close
    //    string dateString = form.ReturnValue2;
    //        //Do something here with these values

    //        //for example
    //        this.txtSomething.Text = val;
    //    }
}
