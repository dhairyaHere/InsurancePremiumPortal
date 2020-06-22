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
    public partial class DeletePlan : Form
    {
        public DeletePlan()
        {
            InitializeComponent();
            groupBox2.Visible = false;
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            label2.Text = " Plan ID ";
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            label2.Text = " Plan Name ";
        }

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
                label7.Text = foundplan.planId.ToString();
                label8.Text = foundplan.planName;
                label11.Text = foundplan.planCategory;
                label12.Text = foundplan.minimumTermSpan.ToString();
                label13.Text = foundplan.minimumAmount.ToString();
                label14.Text = foundplan.planDescription;
            }
        }
        // Delete button clicked
        private void Button3_Click(object sender, EventArgs e)
        {
            
            Plans.DeletePlan(Convert.ToInt32(label7.Text));
            this.Close();
        }
        // Back Button
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
