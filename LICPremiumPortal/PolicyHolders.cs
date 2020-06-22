using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LICPremiumPortal
{
    public class PolicyHolders
    {
        public int policyNo { get; set; }
        public string frequency { get; set; }
        public double optedAmount { get; set; }
        public int policyTerm { get; set; }
        public Plans planId { get; set; }

        public static void GetPlan(PolicyHolders newplan)
        {
            try
            {

                String str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'F:\DDU STUFF\SEM 6\OOSE\LICPremiumPortal\LICPremiumPortal\LICPremiumPortal\LICPremiumPortalDB.mdf'; Integrated Security = True";
                String query = "Insert into Policy_Holders( UserId , PlanId , Frequency , Opted_Amount , Policy_Term ) values (" + Form1.userid + "," + newplan.planId.planId + ",'" + newplan.frequency + "'," + newplan.optedAmount + "," + newplan.policyTerm + ")";
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                int rows = cmd.ExecuteNonQuery();
               
                if (rows == 0)
                {
                    MessageBox.Show("Error inserting data into database !");
                }
                else
                {
                    
                    MessageBox.Show("Please pay the first due premium to activate this plan!");
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.ToString());
            }

        }

        public static List<PolicyHolders> showOngoingPolicies()
        {
            List<PolicyHolders> myPlans = new List<PolicyHolders>();
            try
            {
                String str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'F:\DDU STUFF\SEM 6\OOSE\LICPremiumPortal\LICPremiumPortal\LICPremiumPortal\LICPremiumPortalDB.mdf'; Integrated Security = True";
                String query = "Select * from Policy_Holders as ph ,Plans as pl where ph.PlanId=pl.planId and ph.UserId="+Form1.userid;
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                PolicyHolders plan;

                while (rdr.Read())
                {
                    plan = new PolicyHolders();
                    plan.policyNo = Convert.ToInt32(rdr["PolicyNo"]);

                    plan.planId = new Plans();
                    plan.planId.planId = Convert.ToInt32(rdr["PlanId"]);
                    plan.planId.planName = rdr["Plan_Name"].ToString();
                    plan.planId.planCategory = rdr["Plan_Category"].ToString();

                    plan.frequency = rdr["Frequency"].ToString();
                    plan.optedAmount = Convert.ToDouble(rdr["Opted_Amount"]);
                    plan.policyTerm = Convert.ToInt32(rdr["Policy_Term"]);
                
                    myPlans.Add(plan);

                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
            return myPlans;
        }
        public static double calculatePremium(int age, double sum, int term)
        {
            double total = 0;

            total = (sum + (sum * (age / 100))) / term;

            return total;
        }
    }
}
