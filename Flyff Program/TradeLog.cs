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
    public partial class TradeLog : Form
    {
        SqlConnection con = new SqlConnection();
        public TradeLog()
        {
            InitializeComponent();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Flyff_Program.Properties.Settings.SQLConnection"].ConnectionString;
        }


        private void TradeLog_Load(object sender, EventArgs e)
        {
            label2.Text = "Character Name : "+GlobalVariable.im_szName.ToString()+"";
            tradelog(GlobalVariable.idPlayer.ToString());
        }

        public void tradelog(string idPlayer)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT tblTradeDetailLog.TradeID, tblTradeDetailLog.TradeGold, tblTradeLog.TradeDt FROM LOGGING_01_DBF.dbo.tblTradeDetailLog INNER JOIN LOGGING_01_DBF.dbo.tblTradeLog ON tblTradeDetailLog.TradeID = tblTradeLog.TradeID WHERE idPlayer = @idPlayer";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@idPlayer", idPlayer);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            TradeIDView.DataSource = dt;
            TradeIDView.BackgroundColor = Color.White;
            TradeIDView.Columns[0].HeaderText = "Trade ID";
            TradeIDView.Columns[1].HeaderText = "Trade Gold";
            TradeIDView.Columns[2].HeaderText = "Trade Date";
            con.Close();
        }

        public void tradedetail()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ItemIndex,ItemCnt,AbilityOpt,ItemResist,ResistAbilityOpt,RandomOpt FROM LOGGING_01_DBF.dbo.tblTradeItemLog WHERE TradeID = @tradeid";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@tradeid", GlobalVariable.TradeId.ToString());
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            TradeDetailView.DataSource = dt;
            TradeDetailView.BackgroundColor = Color.White;
            TradeDetailView.Columns[0].HeaderText = "Item ID";
            TradeDetailView.Columns[1].HeaderText = "Count";
            TradeDetailView.Columns[2].HeaderText = "Ability";
            TradeDetailView.Columns[3].HeaderText = "Resist";
            TradeDetailView.Columns[4].HeaderText = "Resist Ability";
            TradeDetailView.Columns[5].HeaderText = "Random Opt";
            con.Close();
        }

        private void TradeIDView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            con.Close();
            if (e.RowIndex >= 0)
            {
                string m_idPlayer = null;
                DataGridViewRow row = this.TradeIDView.Rows[e.RowIndex];
                GlobalVariable.TradeId = row.Cells[0].Value.ToString();
                con.Close();
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT idPlayer FROM LOGGING_01_DBF.dbo.tblTradeDetailLog WHERE TradeID != @tradeid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@tradeid", GlobalVariable.TradeId);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    m_idPlayer = rd["idPlayer"].ToString();
                    con.Close();
                    con.Open();
                    SqlCommand com = con.CreateCommand();
                    com.CommandType = CommandType.Text;
                    com.CommandText = "SELECT m_szName FROM CHARACTER_01_DBF.dbo.CHARACTER_TBL WHERE m_idPlayer = @idplayer";
                    com.Parameters.Clear();
                    com.Parameters.AddWithValue("@idplayer", m_idPlayer);
                    SqlDataReader ra = com.ExecuteReader();
                    if (ra.Read())
                    {
                        label3.Text = "TRADE WITH : "+ ra["m_szName"] +"";
                    }
                    con.Close();
                }
                TradeIDView.Enabled = true;
                tradedetail();
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
