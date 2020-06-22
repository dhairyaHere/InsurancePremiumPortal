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
    public partial class ModifyPlan : Form
    {
        public ModifyPlan()
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
        //Find button Clicked
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
            //if(foundplan != null)
            //    MessageBox.Show(" Found Plan = "+foundplan.planName);
            if (foundplan != null)
            {
                groupBox2.Visible = true;
                label7.Text = foundplan.planId.ToString();
                label8.Text = foundplan.planName;
                comboBox1.Text = foundplan.planCategory;
                numericUpDown1.Value = foundplan.minimumTermSpan;
                textBox2.Text = foundplan.minimumAmount.ToString();
                richTextBox1.Text = foundplan.planDescription;
            }
                
        }
        // Click on update button
        private void Button3_Click(object sender, EventArgs e)
        {
            Plans updated = new Plans();

            updated.planId = Convert.ToInt32(label7.Text);
            updated.planName = label8.Text;
            updated.planCategory = comboBox1.SelectedItem.ToString();
            updated.minimumTermSpan = Convert.ToInt32(numericUpDown1.Value) ;
            updated.minimumAmount = Convert.ToDouble(textBox2.Text);
            updated.planDescription = richTextBox1.Text;

            Plans.RevisePlanStatistics(updated);
            this.Close();
        }
        //back button
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

