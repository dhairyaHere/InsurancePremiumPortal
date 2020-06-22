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
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uname = textBox1.Text;
            string pass = textBox2.Text;
            string fname = textBox7.Text;
            string contact = textBox4.Text;
            string email = textBox5.Text;
            string dob = dateTimePicker1.Text;
            
            try
            {
                String query2;
                String str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'F:\DDU STUFF\SEM 6\OOSE\LICPremiumPortal\LICPremiumPortal\LICPremiumPortal\LICPremiumPortalDB.mdf'; Integrated Security = True";
                String query = "Insert into UserDetails( Username , Fullname , Contact_No , DOB , Email ) values ('"+ uname +"','"+ fname + "','" + contact + "','" + dob + "','" + email +"')";
                SqlConnection con = new SqlConnection(str);
                int rows2=0;
                SqlCommand cmd = new SqlCommand(query, con);
                
                SqlCommand cmd2;
                con.Open();
                if (pass == textBox3.Text)
                {
                    query2 = "Insert into Credentials( Username , Password ) values ('" + uname + "','" + pass + "')";
                    MessageBox.Show("You are successfully registered !");
                    cmd2 = new SqlCommand(query2, con);
                    rows2 = cmd2.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Passwords do not match ! Try Again :(");
                }
              
                int rows = cmd.ExecuteNonQuery();
                
                if (rows == 0 || rows2 == 0)
                {
                    MessageBox.Show("Error inserting data into database !");
                }
            }
            catch(Exception m)
            {
                MessageBox.Show(m.ToString());
            }

        }

    }
}
