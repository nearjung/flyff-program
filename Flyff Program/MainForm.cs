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
using System.Net.NetworkInformation;
using System.IO;
using System.Net.Sockets;

namespace Flyff_Program
{
    public partial class MainForm : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        public MainForm()
        {
            InitializeComponent();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Flyff_Program.Properties.Settings.SQLConnection"].ConnectionString;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            Dictionary<string, string> item = new Dictionary<string, string>();
            item.Add("F", "Normal Member");
            item.Add("P", "GM Member");
            item.Add("S", "Admin Member");
            comboBox1.DataSource = new BindingSource(item, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(account_txt.Text == "" | password_txt.Text == "" | comboBox1.Text == "")
            {
                MessageBox.Show("Please fill information.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string ComboValue = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Value;
                con.Close();
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT * FROM ACCOUNT_DBF.dbo.ACCOUNT_TBL WHERE account = @acc";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@acc", account_txt.Text);
                SqlDataReader hr = com.ExecuteReader();
                if (hr.Read())
                {
                    if (account_txt.Text.Equals(hr["account"].ToString()))
                    {
                        MessageBox.Show("This account is inuse!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        account_txt.Clear();
                        password_txt.Clear();
                    }
                }
                else
                {
                    con.Close();
                    con.Open();
                    SqlCommand com2 = new SqlCommand("EXEC ACCOUNT_DBF.dbo.usp_PanelCreateNewAccount @account, @password, @auth", con);
                    com2.Parameters.Clear();
                    com2.Parameters.AddWithValue("@account", account_txt.Text);
                    com2.Parameters.AddWithValue("@password", password_txt.Text);
                    com2.Parameters.AddWithValue("@auth", ((KeyValuePair<string, string>)comboBox1.SelectedItem).Key);
                    com2.ExecuteNonQuery();
                    MessageBox.Show("Success add account !", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    account_txt.Clear();
                    password_txt.Clear();
                    display_data(null);
                }
                con.Close();
            }
            
        }

        public void display_data(string account)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM ACCOUNT_DBF.dbo.ACCOUNT_TBL WHERE account LIKE @account";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@account", "%" + account + "%");
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }


        public void display_Character(string szName)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT m_idPlayer,account,m_szName,m_nLevel,CreateTime FROM CHARACTER_01_DBF.dbo.CHARACTER_TBL WHERE m_szName LIKE @szName OR account LIKE @account";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@szName", "%" + szName + "%");
            cmd.Parameters.AddWithValue("@account", "%" + szName +"%");
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            PlayerList.DataSource = dt;
            con.Close();
        }



        private void tabPage1_Enter(object sender, EventArgs e)
        {
            display_data(null);
            string FilePath = File.ReadAllText(@"Setting.txt");
            string IPNetwork = ResourceFlyff.Resource.Between(FilePath.ToString(), "IPServer=", "\r\nWorldServerPort");
            string ServerPort = ResourceFlyff.Resource.Between(FilePath.ToString(), "WorldServerPort=", ";");
            TcpClient tcp = new TcpClient();
            try
            {
                tcp.Connect(IPNetwork, Convert.ToInt32(ServerPort));
                label44.Text = "ONLINE";
                label44.ForeColor = Color.Green;
            }
            catch (Exception)
            {
                label44.Text = "OFFLINE";
                label44.ForeColor = Color.Red;
            }
        }

        public int check_account(string account)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM ACCOUNT_DBF.dbo.ACCOUNT_TBL WHERE account = @account";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@account", account);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                if (daccount.Text.Equals(rd["account"].ToString()))
                {
                    return 1;
                }
            }
            else
            {
                return 2;
            }
            con.Close();
            return 0;
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (check_account(daccount.Text) == 1)
            {
                con.Close();
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "EXEC ACCOUNT_DBF.dbo.PanelDeleteAccount @account";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@account", daccount.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                display_data(null);
                MessageBox.Show("Delete Record Complete !", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Invalid Data !", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            con.Close();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM ACCOUNT_DBF.dbo.ACCOUNT_TBL_DETAIL WHERE account = @account";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@account", row.Cells[0].Value.ToString());
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    daccount.Text = row.Cells[0].Value.ToString();
                    dpass_txt.Text = row.Cells[1].Value.ToString();
                    dcharpass_txt.Text = row.Cells[5].Value.ToString();
                    email_txt.Text = rd["email"].ToString();
                    dauth_txt.Text = rd["m_chLoginAuthority"].ToString();
                    dcash_txt.Text = row.Cells[10].Value.ToString();
                }
                con.Close();
            }
        }

        private void PlayerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string GuildID,idPlayer = null;;
            con.Close();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.PlayerList.Rows[e.RowIndex];
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM CHARACTER_01_DBF.dbo.CHARACTER_TBL WHERE m_idPlayer = @idPlayer";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idPlayer", row.Cells[0].Value.ToString());
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    label27.Text = rd["account"].ToString();
                    label28.Text = rd["m_szName"].ToString();
                    label29.Text = rd["m_nHitPoint"].ToString();
                    label30.Text = rd["m_nManaPoint"].ToString();
                    label31.Text = rd["m_nFatiguePoint"].ToString();
                    label32.Text = ResourceFlyff.Resource.GenderName(rd["m_dwSex"].ToString());
                    int Gold = Int32.Parse(rd["m_dwGold"].ToString());
                    label33.Text = Gold.ToString("N0");
                    label34.Text = ResourceFlyff.Resource.JobName(rd["m_nJob"].ToString());
                    label35.Text = rd["m_nStr"].ToString();
                    label36.Text = rd["m_nSta"].ToString();
                    label37.Text = rd["m_nDex"].ToString();
                    label38.Text = rd["m_nInt"].ToString();
                    label39.Text = rd["m_nLevel"].ToString();
                    label42.Text = rd["PKValue"].ToString();
                    GuildID = rd["m_idCompany"].ToString();
                    idPlayer = rd["m_idPlayer"].ToString();
                    GlobalVariable.idPlayer = rd["m_idPlayer"].ToString();
                    GlobalVariable.im_szName = rd["m_szName"].ToString();

                    rd.Close();
                    SqlCommand com = con.CreateCommand();
                    com.CommandType = CommandType.Text;
                    com.CommandText = "SELECT * FROM CHARACTER_01_DBF.dbo.GUILD_TBL WHERE m_idGuild = @guild";
                    com.Parameters.Clear();
                    com.Parameters.AddWithValue("@guild", GuildID);
                    SqlDataReader guild = com.ExecuteReader();

                    if (guild.Read()) {
                        label40.Text = guild["m_szGuild"].ToString();
                    } else
                    {
                        label40.Text = "No Guild";
                    }

                    guild.Close();
                    SqlCommand pnt = con.CreateCommand();
                    pnt.CommandType = CommandType.Text;
                    pnt.CommandText = "SELECT * FROM CHARACTER_01_DBF.dbo.PARTY_TBL WHERE m_idPlayer = @idPlayer";
                    pnt.Parameters.Clear();
                    pnt.Parameters.AddWithValue("@idPlayer", idPlayer);
                    SqlDataReader party = pnt.ExecuteReader();

                    if (party.Read())
                    {
                        label41.Text = party["partyname"].ToString();
                    }
                    else
                    {
                        label41.Text = "No Party";
                    }
                }
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            display_data(search_txt.Text);
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if (check_account(daccount.Text) == 1)
            {
                con.Close();
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "EXEC ACCOUNT_DBF.dbo.PanelUpdateAccount @account,@pass,@dpass,@email,@auth,@cash";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@account", daccount.Text);
                cmd.Parameters.AddWithValue("@pass", dpass_txt.Text);
                cmd.Parameters.AddWithValue("@dpass", dcharpass_txt.Text);
                cmd.Parameters.AddWithValue("@email", email_txt.Text);
                cmd.Parameters.AddWithValue("@auth", dauth_txt.Text);
                cmd.Parameters.AddWithValue("@cash", dcash_txt.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Account Update Success !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                display_data(null);
            }
            else
            {
                MessageBox.Show("Invalid Data !", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void existToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ConfigDataPath().Show();
        }

        private void searchbox_txt_Enter(object sender, EventArgs e)
        {
            if (searchbox_txt.Text == "Character Name / Account name")
            {
                searchbox_txt.Clear();
                searchbox_txt.ForeColor = Color.Black;
            }
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            display_Character(null);
            label27.Text = "";
            label28.Text = "";
            label29.Text = "";
            label30.Text = "";
            label31.Text = "";
            label32.Text = "";
            label33.Text = "";
            label34.Text = "";
            label35.Text = "";
            label36.Text = "";
            label37.Text = "";
            label38.Text = "";
            label39.Text = "";
            label40.Text = "";
            label41.Text = "";
            label42.Text = "";
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            display_Character(searchbox_txt.Text);
        }

        private void editchar_btn_Click(object sender, EventArgs e)
        {
            new EditCharacter().Show();
        }

        private void deletechar_btn_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE CHARACTER_01_DBF.dbo.CHARACTER_TBL SET isblock = @delete WHERE m_idPlayer = @idPlayer";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@delete", "D");
            cmd.Parameters.AddWithValue("@idPlayer", GlobalVariable.idPlayer.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete Character Success !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            display_Character(null);
        }

        private void tradelog_btn_Click(object sender, EventArgs e)
        {
            if (GlobalVariable.im_szName == null)
            {
                MessageBox.Show("Please Select Character !", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                new TradeLog().Show();
            }
        }
    }
}
