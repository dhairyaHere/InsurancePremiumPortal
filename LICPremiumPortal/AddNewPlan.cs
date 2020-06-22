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
    public partial class AddNewPlan : Form
    {
        
        public AddNewPlan()
        {
            InitializeComponent();
        }

        // Add Button Clicked
        private void Button1_Click(object sender, EventArgs e)
        {
            Plans plan = new Plans();
            plan.planName = textBox1.Text;
            plan.planCategory = comboBox1.SelectedItem.ToString();
            plan.minimumTermSpan = Convert.ToInt32(numericUpDown1.Value);
            plan.minimumAmount = Convert.ToDouble(textBox4.Text);
            plan.planDescription = richTextBox1.Text;

            Plans.AddNewPlan(plan);

            this.Close();
        }
        // back button
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
