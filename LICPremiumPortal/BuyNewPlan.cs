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
    public partial class BuyNewPlan : Form
    {
        public static int Pid;
        public static string Pname = "";

        public BuyNewPlan()
        {
            InitializeComponent();
            groupBox2.Visible = false;
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            label1.Text = " Plan ID ";
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            label1.Text = " Plan Name ";
        }
        //find button 
        private void Button1_Click(object sender, EventArgs e)
        {
            Plans foundplan = new Plans();
            if (radioButton1.Checked == true)
            {
                foundplan = Plans.FindPlanById(Convert.ToInt32(textBox1.Text));
            }
            else if (radioButton2.Checked == true)
            {
                foundplan = Plans.FindPlanByName(textBox1.Text);
            }

            if (foundplan != null)
            {
                groupBox2.Visible = true;

                Pid = foundplan.planId;
                Pname = foundplan.planName;

                label7.Text = foundplan.planId.ToString();
                label8.Text = foundplan.planName;
                label11.Text = foundplan.planCategory;
                label12.Text = foundplan.minimumTermSpan.ToString();
                label13.Text = foundplan.minimumAmount.ToString();
                label14.Text = foundplan.planDescription;
            }
        }
        //back button
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Proceed to buy button
        private void Button4_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            ConfirmBuying cb = new ConfirmBuying();
            cb.ShowDialog();
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
