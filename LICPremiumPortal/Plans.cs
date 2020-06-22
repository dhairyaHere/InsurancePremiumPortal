using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LICPremiumPortal
{
    public class Plans
    {
        public int planId { get; set; }
        public string planName { get; set; }
        public string planDescription { get; set; }
        public string planCategory { get; set; }
        public int minimumTermSpan { get; set; }
        public double minimumAmount { get; set; }

        public static List<Plans> showExistingPlans()
        {
            List<Plans> allPlans = new List<Plans>();
            try
            {
                String str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'F:\DDU STUFF\SEM 6\OOSE\LICPremiumPortal\LICPremiumPortal\LICPremiumPortal\LICPremiumPortalDB.mdf'; Integrated Security = True";                 
                String query = "Select * from Plans";
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                
                Plans plan;
                
                while (rdr.Read())
                {
                    plan = new Plans();
                    plan.planId = Convert.ToInt32(rdr["planId"]);
                    plan.planName = rdr["Plan_Name"].ToString();
                    plan.planDescription = rdr["Plan_Description"].ToString();
                    plan.planCategory = rdr["Plan_Category"].ToString();
                    plan.minimumTermSpan = Convert.ToInt32(rdr["Plan_TermSpan"]);
                    plan.minimumAmount = Convert.ToDouble(rdr["Plan_MinimumAmount"]);

                    allPlans.Add(plan);
                }


            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
            return allPlans;
        }
        public static void AddNewPlan(Plans plan)
        {
           try
            {

                String str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'F:\DDU STUFF\SEM 6\OOSE\LICPremiumPortal\LICPremiumPortal\LICPremiumPortal\LICPremiumPortalDB.mdf'; Integrated Security = True";
                String query = "Insert into Plans( Plan_Name , Plan_Description , Plan_Category , Plan_TermSpan , Plan_MinimumAmount ) values ('" + plan.planName + "','" + plan.planDescription + "','" + plan.planCategory + "'," + plan.minimumTermSpan + "," + plan.minimumAmount + ")";
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                
                int rows = cmd.ExecuteNonQuery();

                if (rows == 0 )
                {
                    MessageBox.Show("Error inserting data into database !");
                }
                else
                {
                    MessageBox.Show(" New Plan added successfully to the list :)");
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }

        }

        public static Plans FindPlanById(int planId)
        {
            Plans plan = null;
            try
            {
                String str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'F:\DDU STUFF\SEM 6\OOSE\LICPremiumPortal\LICPremiumPortal\LICPremiumPortal\LICPremiumPortalDB.mdf'; Integrated Security = True";
                String query = "Select * from Plans where planId=" + planId +"";
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    plan = new Plans();
                    plan.planId = planId;
                    plan.planName = rdr["Plan_Name"].ToString();
                    plan.planDescription = rdr["Plan_Description"].ToString();
                    plan.planCategory = rdr["Plan_Category"].ToString();
                    plan.minimumAmount = Convert.ToDouble(rdr["Plan_MinimumAmount"]);
                    plan.minimumTermSpan = Convert.ToInt32(rdr["Plan_TermSpan"]);

                    //MessageBox.Show(" found : "+ rdr["Plan_Name"].ToString());
                }
                else
                {
                    MessageBox.Show("No such Plan Found with such ID :(");
                }

            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
            

            return plan;
        }
        public static Plans FindPlanByName(string planName)
        {
            Plans plan=null;
            try
            {
                String str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'F:\DDU STUFF\SEM 6\OOSE\LICPremiumPortal\LICPremiumPortal\LICPremiumPortal\LICPremiumPortalDB.mdf'; Integrated Security = True";
                String query = "Select * from Plans where plan_Name='" + planName + "'";
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    plan = new Plans();
                    plan.planId = Convert.ToInt32(rdr["planId"]);
                    plan.planName = rdr["Plan_Name"].ToString();
                    plan.planDescription = rdr["Plan_Description"].ToString();
                    plan.planCategory = rdr["Plan_Category"].ToString();
                    plan.minimumAmount = Convert.ToDouble(rdr["Plan_MinimumAmount"]);
                    plan.minimumTermSpan = Convert.ToInt32(rdr["Plan_TermSpan"]);

                    //MessageBox.Show(" found : " + rdr["Plan_Name"].ToString());
                }
                else
                {
                    MessageBox.Show("No such Plan Found with this Name :(");
                }

            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }


            return plan;
        }
        public static void RevisePlanStatistics( Plans plan )
        {
            try
            {
               
                String str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'F:\DDU STUFF\SEM 6\OOSE\LICPremiumPortal\LICPremiumPortal\LICPremiumPortal\LICPremiumPortalDB.mdf'; Integrated Security = True";
                String query = "Update Plans set Plan_Name ='" + plan.planName + "', Plan_Description='" + plan.planDescription + "', Plan_Category='" + plan.planCategory + "', Plan_TermSpan=" + plan.minimumTermSpan + ", Plan_MinimumAmount=" + plan.minimumAmount + " where planId ="+plan.planId; 
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                {
                    MessageBox.Show("There was some error in updating the plan details !");
                }
                else
                {
                    MessageBox.Show(" Plan "+plan.planName +" updated successfully :)");
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }

        public static void DeletePlan(int planid)
        {
            try
            {

                String str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'F:\DDU STUFF\SEM 6\OOSE\LICPremiumPortal\LICPremiumPortal\LICPremiumPortal\LICPremiumPortalDB.mdf'; Integrated Security = True";
                String query = "Delete from Plans where planId =" + planid;
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                {
                    MessageBox.Show("Deletion Failed. Try Again !");
                }
                else
                {
                    MessageBox.Show(" Plan deleted from the records :)");
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }
    }
}
