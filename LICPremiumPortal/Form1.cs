using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LICPremiumPortal
{
    public partial class Form1 : Form
    {
        public static string username="";
        public static int userid;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton2.Checked == true && radioButton1.Checked == false && textBox1.Text!="" && textBox2.Text!="" )
                {

                    String str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'F:\DDU STUFF\SEM 6\OOSE\LICPremiumPortal\LICPremiumPortal\LICPremiumPortal\LICPremiumPortalDB.mdf'; Integrated Security = True";

                    String query = "Select * from Credentials where Username='" + textBox1.Text + "' and Password='" + textBox2.Text + "'";
                    string qtemp = "Select Id from UserDetails where Username='" + textBox1.Text + "'";

                    SqlConnection con = new SqlConnection(str);

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlCommand cmdtemp = new SqlCommand(qtemp, con);

                    con.Open();


                    SqlDataReader rdrtemp = cmdtemp.ExecuteReader();

                    if (rdrtemp.Read())
                    {
                        Form1.userid = Convert.ToInt32(rdrtemp["Id"]);
                    }
                    rdrtemp.Close();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        //MessageBox.Show("Welcome "+rdr["Username"].ToString());
                        username = rdr["Username"].ToString();
                        this.Hide();
                        
                        CustomerPortal cp = new CustomerPortal();
                        cp.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Invalid Credentials! Try Again.");
                    }
                }
                else if( radioButton2.Checked==false && radioButton1.Checked==true )
                {
                    if( textBox1.Text == "Chairman" && textBox2.Text == "main1234")
                    {
                        Form1.userid = 0000;
                        Form1.username = "Chairman";
                        this.Hide();
                        ManagePlans mp = new ManagePlans();
                        mp.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Invalid Admin Credentials! If you are a regular customer" +
                            " then please select 'CUSTOMER' in the login form! ");
                    }
                }
            }
            catch(Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
        // Create new account clicked
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           this.Hide();
            Signup s = new Signup();
            s.ShowDialog();
        }
        
    }
}
