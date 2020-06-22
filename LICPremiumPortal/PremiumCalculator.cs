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
    public partial class PremiumCalculator : Form
    {
        public static Plans calc;
        public static int age;
        public static double sum;
        public static int term;
        public PremiumCalculator()
        {
            InitializeComponent();
            groupBox2.Visible = false;
        }
        // BACK BUTTON CLICKED
        private void Button1_Click(object sender, EventArgs e)
        {
            calc = null;
            this.Close();
        }
        // Calculate Premium buuton Clicked
        private void Button4_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(textBox2.Text) <  Convert.ToDouble(label13.Text))
            {
                MessageBox.Show(" The minimum amount of Sum Assured for this plan must be "+label13.Text);
            }
            else
            {
                PremiumCalculator.age = Convert.ToInt32(numericUpDown1.Value) ;
                PremiumCalculator.sum = Convert.ToDouble(textBox2.Text) ;
                PremiumCalculator.term = Convert.ToInt32(numericUpDown2.Value);

                DisplayQuotation dis = new DisplayQuotation();
                dis.ShowDialog();
            }
        }

        private void PremiumCalculator_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lICPremiumPortalDBDataSet2.Plans' table. You can move, or remove it, as needed.
            this.plansTableAdapter1.Fill(this.lICPremiumPortalDBDataSet2.Plans);
            // TODO: This line of code loads data into the 'lICPremiumPortalDBDataSet1.Plans' table. You can move, or remove it, as needed.
            this.plansTableAdapter.Fill(this.lICPremiumPortalDBDataSet1.Plans);

        }
        //next button clicked
        private void Button2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            
            calc =  Plans.FindPlanByName(comboBox1.Text);

            label7.Text = calc.planId.ToString();
            label8.Text = calc.planName;
            label12.Text = calc.minimumTermSpan.ToString();
            label13.Text = calc.minimumAmount.ToString();

            numericUpDown2.Value = calc.minimumTermSpan;
            numericUpDown2.Minimum = calc.minimumTermSpan;

            textBox2.Text = calc.minimumAmount.ToString();
            
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
