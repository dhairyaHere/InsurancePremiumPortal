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
    public partial class SearchPlan : Form
    {
        public SearchPlan()
        {
            InitializeComponent();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            label2.Text = "Plan ID";
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            label2.Text = "Plan Name";
        }
        //Find button clicked
        private void Button1_Click(object sender, EventArgs e)
        {
            Plans foundplan = new Plans();
            if( radioButton1.Checked == true )
            {   
                foundplan = Plans.FindPlanById(Convert.ToInt32(textBox1.Text));
            }
            else if( radioButton2.Checked == true )
            {  
                foundplan = Plans.FindPlanByName(textBox1.Text);
            }
            //if(foundplan != null)
            //    MessageBox.Show(" Found Plan = "+foundplan.planName);
            if (foundplan != null)
                dataGridView1.DataSource = new List<Plans>() { foundplan };
        }
        //Back Button
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
