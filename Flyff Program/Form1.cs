using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Flyff_Program
{
    public partial class Login : Form
    {
        Timer t1 = new Timer();
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();

        public Login()
        {
            InitializeComponent();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Flyff_Program.Properties.Settings.SQLConnection"].ConnectionString;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Opacity = 0;
            t1.Interval = 10;
            t1.Tick += new EventHandler(fadeIn);
            t1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void fadeIn(object sender, EventArgs e)
        {
            if (Opacity >= 1)
                t1.Stop();
            else
                Opacity += 0.05;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM ACCOUNT_DBF.dbo.ACCOUNT_TBL WHERE account = @acc AND password = @pw";
            com.Parameters.Clear();
            com.Parameters.AddWithValue("@acc", textBox1.Text);
            com.Parameters.AddWithValue("@pw", textBox2.Text);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                if (textBox1.Text.Equals(dr["account"].ToString()) && textBox2.Text.Equals(dr["password"].ToString()))
                {
                    con.Close();
                    con.Open();
                    SqlCommand com2 = new SqlCommand();
                    com2.Connection = con;
                    com2.CommandText = "SELECT * FROM ACCOUNT_DBF.dbo.ACCOUNT_TBL_DETAIL WHERE account = @acc";
                    com2.Parameters.Clear();
                    com2.Parameters.AddWithValue("@acc", textBox1.Text);
                    SqlDataReader hr = com2.ExecuteReader();
                    if (hr.Read())
                    {
                        if (textBox1.Text.Equals(hr["account"].ToString()) && hr["m_chLoginAuthority"].ToString() == "S")
                        {
                            new MainForm().Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Only Admin can access.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Login Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            } else
            {
                MessageBox.Show("Login Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            con.Close();
        }
    }
}
