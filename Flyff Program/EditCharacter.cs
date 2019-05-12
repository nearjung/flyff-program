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
    public partial class EditCharacter : Form
    {
        SqlConnection con = new SqlConnection();
        public EditCharacter()
        {
            InitializeComponent();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Flyff_Program.Properties.Settings.SQLConnection"].ConnectionString;
        }

        private void EditCharacter_Load(object sender, EventArgs e)
        {
            display_Character(null);
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
                if (GlobalVariable.iaccount.ToString().Equals(rd["account"].ToString()))
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


        public void display_Character(string szName)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM CHARACTER_01_DBF.dbo.CHARACTER_TBL WHERE isblock = @block AND m_szName LIKE @szName OR account LIKE @account";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@block", "F");
            cmd.Parameters.AddWithValue("@szName", "%" + szName + "%");
            cmd.Parameters.AddWithValue("@account", "%" + szName + "%");
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }


        private void searchbox_txt_Enter(object sender, EventArgs e)
        {
            if (searchbox_txt.Text == "Character Name / Account name")
            {
                searchbox_txt.Clear();
                searchbox_txt.ForeColor = Color.Black;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                con.Close();
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE CHARACTER_01_DBF.dbo.CHARACTER_TBL SET" +
                "serverindex = @serverindex," +
                "account = @account," +
                "m_szName = @m_szName," +
                "playerslot = @playerslot," +
                "dwWorldID = @dwWorldID," +
                "m_dwIndex = @m_dwIndex," +
                "m_vScale_x = @m_vScale_x," +
                "m_dwMotion = @m_dwMotion," +
                "m_vPos_x = @m_vPos_x," +
                "m_vPos_y = @m_vPos_y," +
                "m_vPos_z = @m_vPos_z," +
                "m_fAngle = @m_fAngle," +
                "m_szCharacterKey = @m_szCharacterKey," +
                "m_nHitPoint = @m_nHitPoint," +
                "m_nManaPoint = @m_nManaPoint," +
                "m_nFatiguePoint = @m_nFatiguePoint," +
                "m_nFuel = @m_nFuel," +
                "m_dwSkinSet = @m_dwSkinSet," +
                "m_dwHairMesh = @m_dwHairMesh," +
                "m_dwHairColor = @m_dwHairColor," +
                "m_dwHeadMesh = @m_dwHeadMesh," +
                "m_dwSex = @m_dwSex," +
                "m_dwRideItemIdx = @m_dwRideItemIdx," +
                "m_dwGold = @m_dwGold," +
                "m_nJob = @m_nJob" +
                /*"m_pActMover = @m_pActMover," +
                "m_nStr = @m_nStr," +
                "m_nSta = @m_nSta," +
                "m_nDex = @m_nDex," +
                "m_nInt = @m_nInt," +
                "m_nLevel = @m_nLevel," +
                "m_nMaximumLevel = @m_nMaximumLevel," +
                "m_nExp1 = @m_nExp1," +
                "m_nExp2 = @m_nExp2," +
                "m_aJobSkill = @m_aJobSkill," +
                "m_aLicenseSkill = @m_aLicenseSkill," +
                "m_aJobLv = @m_aJobLv," +
                "m_dwExpertLv = @m_dwExpertLv," +
                "m_idMarkingWorld = @m_idMarkingWorld," +
                "m_vMarkingPos_x = @m_vMarkingPos_x," +
                "m_vMarkingPos_y = @m_vMarkingPos_y," +
                "m_vMarkingPos_z = @m_vMarkingPos_z," +
                "m_nRemainGP = @m_nRemainGP," +
                "m_nRemainLP = @m_nRemainLP," +
                "m_nFlightLv = @m_nFlightLv," +
                "m_nFxp = @m_nFxp," +
                "m_nTxp = @m_nTxp," +
                "m_lpQuestCntArray = @m_lpQuestCntArray," +
                "m_chAuthority = @m_chAuthority," +
                "m_dwMode = @m_dwMode," +
                "m_idparty = @m_idparty," +
                "m_idCompany = @m_idCompany," +
                "m_idMuerderer = @m_idMuerderer," +
                "m_nFame = @m_nFame," +
                "m_nDeathExp = @m_nDeathExp," +
                "m_nDeathLevel = @m_nDeathLevel," +
                "m_dwFlyTime = @m_dwFlyTime," +
                "m_nMessengerState = @m_nMessengerState," +
                "blockby = @blockby," +
                "TotalPlayTime = @TotalPlayTime," +
                "isblock = @isblock," +
                "End_Time = @End_Time" +*/
                " WHERE m_idPlayer = @idPlayer";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@serverindex", GlobalVariable.iserverindex.ToString());
                cmd.Parameters.AddWithValue("@account", GlobalVariable.iaccount.ToString());
            cmd.Parameters.AddWithValue("@m_szName", GlobalVariable.im_szName.ToString());
            cmd.Parameters.AddWithValue("@playerslot", GlobalVariable.iplayerslot.ToString());
            cmd.Parameters.AddWithValue("@dwWorldID", GlobalVariable.idwWorldID.ToString());
            cmd.Parameters.AddWithValue("@m_dwIndex", GlobalVariable.im_dwIndex.ToString());
            cmd.Parameters.AddWithValue("@m_vScale_x", GlobalVariable.im_vScale_x.ToString());
            cmd.Parameters.AddWithValue("@m_dwMotion", GlobalVariable.im_dwMotion.ToString());
            cmd.Parameters.AddWithValue("@m_vPos_x", GlobalVariable.im_vPos_x.ToString());
            cmd.Parameters.AddWithValue("@m_vPos_y", GlobalVariable.im_vPos_y.ToString());
            cmd.Parameters.AddWithValue("@m_vPos_z", GlobalVariable.im_vPos_z.ToString());
            cmd.Parameters.AddWithValue("@m_fAngle", GlobalVariable.im_fAngle.ToString());
            cmd.Parameters.AddWithValue("@m_szCharacterKey", GlobalVariable.im_szCharacterKey.ToString());
            cmd.Parameters.AddWithValue("@m_nHitPoint", GlobalVariable.im_nHitPoint.ToString());
            cmd.Parameters.AddWithValue("@m_nManaPoint", GlobalVariable.im_nManaPoint.ToString());
            cmd.Parameters.AddWithValue("@m_nFatiguePoint", GlobalVariable.im_nFatiguePoint.ToString());
            cmd.Parameters.AddWithValue("@m_nFuel", GlobalVariable.im_nFuel.ToString());
            cmd.Parameters.AddWithValue("@m_dwSkinSet", GlobalVariable.im_dwSkinSet.ToString());
            cmd.Parameters.AddWithValue("@m_dwHairMesh", GlobalVariable.im_dwHairMesh.ToString());
            cmd.Parameters.AddWithValue("@m_dwHairColor", GlobalVariable.im_dwHairColor.ToString());
            cmd.Parameters.AddWithValue("@m_dwHeadMesh", GlobalVariable.im_dwHeadMesh.ToString());
            cmd.Parameters.AddWithValue("@m_dwSex", GlobalVariable.im_dwSex.ToString());
            cmd.Parameters.AddWithValue("@m_dwRideItemIdx", GlobalVariable.im_dwRideItemIdx.ToString());
            cmd.Parameters.AddWithValue("@m_dwGold", GlobalVariable.im_dwGold.ToString());
            cmd.Parameters.AddWithValue("@m_nJob", GlobalVariable.im_nJob.ToString());
            cmd.Parameters.AddWithValue("@idPlayer", GlobalVariable.idPlayer.ToString());
            cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Character Update Success !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                display_Character(null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
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
                cmd.CommandText = "SELECT * FROM CHARACTER_01_DBF.dbo.CHARACTER_TBL WHERE m_idPlayer = @idPlayer";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idPlayer", row.Cells[0].Value.ToString());
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    GlobalVariable.idPlayer = row.Cells[0].Value.ToString();
                    GlobalVariable.iserverindex = row.Cells[1].Value.ToString();
                    GlobalVariable.iaccount = row.Cells[2].Value.ToString();
                    GlobalVariable.im_szName = row.Cells[3].Value.ToString();
                    GlobalVariable.iplayerslot = row.Cells[4].Value.ToString();
                    GlobalVariable.idwWorldID = row.Cells[5].Value.ToString();
                    GlobalVariable.im_dwIndex = row.Cells[6].Value.ToString();
                    GlobalVariable.im_vScale_x = row.Cells[7].Value.ToString();
                    GlobalVariable.im_dwMotion = row.Cells[8].Value.ToString();
                    GlobalVariable.im_vPos_x = row.Cells[9].Value.ToString();
                    GlobalVariable.im_vPos_y = row.Cells[10].Value.ToString();
                    GlobalVariable.im_vPos_z = row.Cells[11].Value.ToString();
                    GlobalVariable.im_fAngle = row.Cells[12].Value.ToString();
                    GlobalVariable.im_szCharacterKey = row.Cells[13].Value.ToString();
                    GlobalVariable.im_nHitPoint = row.Cells[14].Value.ToString();
                    GlobalVariable.im_nManaPoint = row.Cells[15].Value.ToString();
                    GlobalVariable.im_nFatiguePoint = row.Cells[16].Value.ToString();
                    GlobalVariable.im_nFuel = row.Cells[17].Value.ToString();
                    GlobalVariable.im_dwSkinSet = row.Cells[18].Value.ToString();
                    GlobalVariable.im_dwHairMesh = row.Cells[19].Value.ToString();
                    GlobalVariable.im_dwHairColor = row.Cells[20].Value.ToString();
                    GlobalVariable.im_dwHeadMesh = row.Cells[21].Value.ToString();
                    GlobalVariable.im_dwSex = row.Cells[22].Value.ToString();
                    GlobalVariable.im_dwRideItemIdx = row.Cells[23].Value.ToString();
                    GlobalVariable.im_dwGold = row.Cells[24].Value.ToString();
                    GlobalVariable.im_nJob = row.Cells[25].Value.ToString();
                    GlobalVariable.im_pActMover = row.Cells[26].Value.ToString();
                    GlobalVariable.im_nStr = row.Cells[27].Value.ToString();
                    GlobalVariable.im_nSta = row.Cells[28].Value.ToString();
                    GlobalVariable.im_nDex = row.Cells[29].Value.ToString();
                    GlobalVariable.im_nInt = row.Cells[30].Value.ToString();
                    GlobalVariable.im_nLevel = row.Cells[31].Value.ToString();
                    GlobalVariable.im_nMaximumLevel = row.Cells[32].Value.ToString();
                    GlobalVariable.im_nExp1 = row.Cells[33].Value.ToString();
                    GlobalVariable.im_nExp2 = row.Cells[34].Value.ToString();
                    GlobalVariable.im_aJobSkill = row.Cells[35].Value.ToString();
                    GlobalVariable.im_aLicenseSkill = row.Cells[36].Value.ToString();
                    GlobalVariable.im_aJobLv = row.Cells[37].Value.ToString();
                    GlobalVariable.im_dwExpertLv = row.Cells[38].Value.ToString();
                    GlobalVariable.im_idMarkingWorld = row.Cells[39].Value.ToString();
                    GlobalVariable.im_vMarkingPos_x = row.Cells[40].Value.ToString();
                    GlobalVariable.im_vMarkingPos_y = row.Cells[41].Value.ToString();
                    GlobalVariable.im_vMarkingPos_z = row.Cells[42].Value.ToString();
                    GlobalVariable.im_nRemainGP = row.Cells[43].Value.ToString();
                    GlobalVariable.im_nRemainLP = row.Cells[44].Value.ToString();
                    GlobalVariable.im_nFlightLv = row.Cells[45].Value.ToString();
                    GlobalVariable.im_nFxp = row.Cells[46].Value.ToString();
                    GlobalVariable.im_nTxp = row.Cells[47].Value.ToString();
                    GlobalVariable.im_lpQuestCntArray = row.Cells[48].Value.ToString();
                    GlobalVariable.im_chAuthority = row.Cells[49].Value.ToString();
                    GlobalVariable.im_dwMode = row.Cells[50].Value.ToString();
                    GlobalVariable.im_idparty = row.Cells[51].Value.ToString();
                    GlobalVariable.im_idCompany = row.Cells[52].Value.ToString();
                    GlobalVariable.im_idMuerderer = row.Cells[53].Value.ToString();
                    GlobalVariable.im_nFame = row.Cells[54].Value.ToString();
                    GlobalVariable.im_nDeathExp = row.Cells[55].Value.ToString();
                    GlobalVariable.im_nDeathLevel = row.Cells[56].Value.ToString();
                    GlobalVariable.im_dwFlyTime = row.Cells[57].Value.ToString();
                    GlobalVariable.im_nMessengerState = row.Cells[58].Value.ToString();
                    GlobalVariable.iblockby = row.Cells[59].Value.ToString();
                    GlobalVariable.iTotalPlayTime = row.Cells[60].Value.ToString();
                    GlobalVariable.iisblock = row.Cells[61].Value.ToString();
                    GlobalVariable.iEnd_Time = row.Cells[62].Value.ToString();
                    GlobalVariable.iBlockTime = row.Cells[63].Value.ToString();
                    GlobalVariable.iCreateTime = row.Cells[64].Value.ToString();
                    GlobalVariable.im_tmAccFuel = row.Cells[65].Value.ToString();
                    GlobalVariable.im_tGuildMember = row.Cells[66].Value.ToString();
                    GlobalVariable.im_dwSkillPoint = row.Cells[67].Value.ToString();
                    GlobalVariable.im_aCompleteQuest = row.Cells[68].Value.ToString();
                    GlobalVariable.im_dwReturnWorldID = row.Cells[69].Value.ToString();
                    GlobalVariable.im_vReturnPos_x = row.Cells[70].Value.ToString();
                    GlobalVariable.im_vReturnPos_y = row.Cells[71].Value.ToString();
                    GlobalVariable.im_vReturnPos_z = row.Cells[72].Value.ToString();
                    GlobalVariable.iMultiServer = row.Cells[73].Value.ToString();
                    GlobalVariable.im_SkillPoint = row.Cells[74].Value.ToString();
                    GlobalVariable.im_SkillLv = row.Cells[75].Value.ToString();
                    GlobalVariable.im_SkillExp = row.Cells[76].Value.ToString();
                    GlobalVariable.idwEventFlag = row.Cells[77].Value.ToString();
                    GlobalVariable.idwEventTime = row.Cells[78].Value.ToString();
                    GlobalVariable.idwEventElapsed = row.Cells[79].Value.ToString();
                    GlobalVariable.iPKValue = row.Cells[80].Value.ToString();
                    GlobalVariable.iPKPropensity = row.Cells[81].Value.ToString();
                    GlobalVariable.iPKExp = row.Cells[82].Value.ToString();
                    GlobalVariable.iAngelExp = row.Cells[83].Value.ToString();
                    GlobalVariable.iAngelLevel = row.Cells[84].Value.ToString();
                    GlobalVariable.iFinalLevelDt = row.Cells[85].Value.ToString();
                    GlobalVariable.im_dwPetId = row.Cells[86].Value.ToString();
                    GlobalVariable.im_nExpLog = row.Cells[87].Value.ToString();
                    GlobalVariable.im_nAngelExpLog = row.Cells[88].Value.ToString();
                    GlobalVariable.im_nCoupon = row.Cells[89].Value.ToString();
                    GlobalVariable.im_nHonor = row.Cells[90].Value.ToString();
                    GlobalVariable.im_nLayer = row.Cells[91].Value.ToString();
                    GlobalVariable.im_nCampusPoint = row.Cells[92].Value.ToString();
                    GlobalVariable.iidCampus = row.Cells[93].Value.ToString();
                    GlobalVariable.im_aCheckedQuest = row.Cells[94].Value.ToString();
                }
                con.Close();
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            con.Close();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM CHARACTER_01_DBF.dbo.CHARACTER_TBL WHERE m_idPlayer = @idPlayer";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idPlayer", row.Cells[0].Value.ToString());
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    GlobalVariable.idPlayer = row.Cells[0].Value.ToString();
                    GlobalVariable.iaccount = row.Cells[2].Value.ToString();
                }
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void search_btn_Click(object sender, EventArgs e)
        {
            display_Character(searchbox_txt.Text);
        }
    }
}
