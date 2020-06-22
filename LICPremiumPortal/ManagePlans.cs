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
    public partial class ManagePlans : Form
    {
 
        public ManagePlans()
        {
            
            InitializeComponent();
            dataGridView1.DataSource = Plans.showExistingPlans();
        }

        private void ManagePlans_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lICPremiumPortalDBDataSet.Plans' table. You can move, or remove it, as needed.
            this.plansTableAdapter.Fill(this.lICPremiumPortalDBDataSet.Plans);

        }

        //Add Plan Button Click 
        private void Button3_Click(object sender, EventArgs e)
        {
            AddNewPlan newplan = new AddNewPlan();
            newplan.ShowDialog();
        }

        //Delete Existing Plan
        private void Button1_Click(object sender, EventArgs e)
        {
            DeletePlan delplan = new DeletePlan();
            delplan.ShowDialog();
              
        }
        //Revise Plan Stats
        private void Button4_Click(object sender, EventArgs e)
        {
            ModifyPlan revplan = new ModifyPlan();
            revplan.ShowDialog();
        }

        //Search Plan button
        private void Button5_Click(object sender, EventArgs e)
        {
            SearchPlan srch = new SearchPlan();
            srch.ShowDialog();
        }

        // Display All Plans
        private void Button2_Click(object sender, EventArgs e)
        {
            List<Plans> show;
            show = Plans.showExistingPlans();
            dataGridView1.DataSource = show;
            
        }
        //customer portal button clicked
        private void Button7_Click(object sender, EventArgs e)
        {
            this.Hide();

            CustomerPortal manager = new CustomerPortal();
            manager.ShowDialog();
        }
        // LOGOUT BUTTON CLICKED
        private void Button8_Click(object sender, EventArgs e)
        {
            Form1.userid = 0;
            Form1.username = "";
            Form1.ActiveForm.Dispose();
            Form1 login = new Form1();
            login.ShowDialog();
        }

    }
}
