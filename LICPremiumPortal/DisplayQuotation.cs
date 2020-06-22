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
    public partial class DisplayQuotation : Form
    {
        public DisplayQuotation()
        {
            InitializeComponent();
            label4.Text ="( "+(PremiumCalculator.calc.planId.ToString()) + " )";
            label7.Text = PremiumCalculator.calc.planName;

            double half , total , quart, full, month;

            total = PolicyHolders.calculatePremium(PremiumCalculator.age, PremiumCalculator.sum, PremiumCalculator.term);

            full = total;
            half = total / 2;
            quart = total / 3;
            month = total / 12;
            label15.Text = full.ToString("#.##");
            label16.Text = half.ToString("#.##");
            label17.Text = quart.ToString("#.##");
            label18.Text = month.ToString("#.##");

        }
        //Back Button CLicked
        private void Button1_Click(object sender, EventArgs e)
        {
            PremiumCalculator.calc = null;
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
