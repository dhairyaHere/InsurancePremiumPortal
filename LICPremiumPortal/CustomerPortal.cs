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
    public partial class CustomerPortal : Form
    {
        public CustomerPortal()
        {
            InitializeComponent();
            label1.Text = " Welcome "+Form1.username+" !";
            dataGridView1.DataSource = Plans.showExistingPlans();
            comboBox1.Text = "All Available";

            if( Form1.username == "Chairman" )
            {
                button2.Visible = true;
            }
            else
            {
                button2.Visible = false;
            }

        }

        // Search Button clicked
        private void Button5_Click(object sender, EventArgs e)
        {
            SearchPlan srch = new SearchPlan();
            srch.ShowDialog();
        }
        // Buy New Plan clicked
        private void Button6_Click(object sender, EventArgs e)
        {
            BuyNewPlan bp = new BuyNewPlan();
            bp.ShowDialog();
        }
        //Show results button clicked
        private void Button4_Click(object sender, EventArgs e)
        {
            //do
            //{
            //    foreach (DataGridViewRow row in dataGridView1.Rows)
            //    {
            //        try
            //        {
            //            dataGridView1.Rows.Remove(row);
            //        }
            //        catch (Exception) { }
            //    }
            //} while (dataGridView1.Rows.Count > 1);

            //dataGridView1.Rows.Clear();
            //dataGridView1.Refresh();

            if ( comboBox1.Text == "All available" )
            {
                List<Plans> show;
                
                
                dataGridView1.DataSource = null;
                show = Plans.showExistingPlans();

                if (show != null)
                {
                    dataGridView1.DataSource = show;
                    //dataGridView1.DataSource = null;
                    //dataGridView1.AllowUserToOrderColumns = true;
                    //dataGridView1.ColumnCount = 6;

                    //dataGridView1.Columns[0].Name = "Plan Id";
                    //dataGridView1.Columns[1].Name = "Plan Name";
                    //dataGridView1.Columns[2].Name = "Plan Type";
                    //dataGridView1.Columns[3].Name = "Plan Description";
                    //dataGridView1.Columns[4].Name = "Minimum Policy Term";
                    //dataGridView1.Columns[5].Name = "Minimum Policy Amount";

                    //string[] rows;
                    //for (int i = 0; i < show.Count; i++)
                    //{
                    //    DataGridViewRow r = new DataGridViewRow();
                    //    rows = new string[] {
                    //                            show[i].planId.ToString() ,
                    //                            show[i].planName ,
                    //                            show[i].planCategory,
                    //                            show[i].planDescription,
                    //                            show[i].minimumTermSpan.ToString(),
                    //                            show[i].minimumAmount.ToString()
                    //                        };
                    //    r.SetValues(rows);
                    //    dataGridView1.Rows.Add(r);
                    //}
                    //show.Clear();
                }
            }
            else if( comboBox1.Text == "My Ongoing" )
            {
                
                List<PolicyHolders> ongoing = null;
                ongoing = PolicyHolders.showOngoingPolicies();

                if (ongoing != null)
                {
                    var l = (from obj in ongoing select new {obj.policyNo,obj.planId.planId,obj.planId.planName ,
                                                obj.planId.planCategory, obj.policyTerm , obj.frequency , obj.optedAmount}).ToList();
                    dataGridView1.DataSource = l;

                    //dataGridView1.AllowUserToOrderColumns = true;
                    //dataGridView1.ColumnCount = 7;

                    //dataGridView1.Columns[0].Name = "Client Policy No";
                    //dataGridView1.Columns[1].Name = "Plan Id";
                    //dataGridView1.Columns[2].Name = "Plan Name";
                    //dataGridView1.Columns[3].Name = "Plan Type";
                    //dataGridView1.Columns[4].Name = "Policy Term";
                    //dataGridView1.Columns[5].Name = "Premium Payment Freq.";
                    //dataGridView1.Columns[6].Name = "Total Policy Amount";
                    //string[] rows;
                    //for(int i=0; i<ongoing.Count; i++)
                    //{
                    //    DataGridViewRow r = new DataGridViewRow();
                    //    rows = new string[] {   ongoing[i].policyNo.ToString() ,
                    //                            ongoing[i].planId.planId.ToString() ,
                    //                            ongoing[i].planId.planName,
                    //                            ongoing[i].planId.planCategory,
                    //                            ongoing[i].policyTerm.ToString(),
                    //                            ongoing[i].frequency,
                    //                            ongoing[i].optedAmount.ToString()
                    //                        };
                    //    r.SetValues(rows);
                    //    dataGridView1.Rows.Add(r);
                    //}
                    //ongoing.Clear();

                }
                else
                    MessageBox.Show(" You do not have any ongoing policies! ");
            }
            
        }
        //premium calculator buuton clicked
        private void Button1_Click(object sender, EventArgs e)
        {
            PremiumCalculator pc = new PremiumCalculator();
            pc.ShowDialog();
        }
        //logout button clicked
        private void Button3_Click(object sender, EventArgs e)
        {
            Form1.userid = 0;
            Form1.username = "";
            //this.Close();
            Form1.ActiveForm.Dispose();
            Form1 login = new Form1();
            login.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManagePlans trans = new ManagePlans();
            trans.ShowDialog();
        }
    }
}
