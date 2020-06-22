using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LICPremiumPortal
{
    public partial class ConfirmBuying : Form
    {
        public ConfirmBuying()
        {
            InitializeComponent();
            label4.Text = BuyNewPlan.Pid.ToString();
            label1.Text = BuyNewPlan.Pname;
        }
        //Get this plan clicked
        private void Button1_Click(object sender, EventArgs e)
        {
            PolicyHolders pol = new PolicyHolders();
            pol.frequency = comboBox1.SelectedItem.ToString();
            pol.policyTerm = Convert.ToInt32(numericUpDown1.Value);
            pol.optedAmount = Convert.ToDouble(textBox1.Text);
            pol.planId = new Plans();
            pol.planId.planId = Convert.ToInt32(label4.Text);

            PolicyHolders.GetPlan(pol);

            this.Close();
        }
        //back button
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //logout button clicked
        private void Button3_Click(object sender, EventArgs e)
        {
            Form1.userid = 0;
            Form1.username = "";
            Form1.ActiveForm.Dispose();
            Form1 login = new Form1();
            login.ShowDialog();
        }
    }
}
