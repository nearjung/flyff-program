using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Flyff_Program
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}

namespace ResourceFlyff
{
    public static class Resource
    {
        [STAThread]
        public static string GenderName(string Job)
        {
            string Sex;
            if (Job == "0")
                Sex = "Male";
            else
                Sex = "Female";
            return Sex;
        }

        public static string Between(this string value,string a, string b)
        {
            int posA = value.IndexOf(a);
            int posB = value.LastIndexOf(b);
            if(posA == -1)
            {
                return "";
            }
            if(posB == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if(adjustedPosA >= posB)
            {
                return "";
            }
            return value.Substring(adjustedPosA, posB - adjustedPosA);
        }


        public static string JobName(string nJob)
        {
            string[] JobName = { "Vagrant", "Mercenary", "Acrobat", "Assist", "Magician", "Puppeteer", "Knight", "Blade", "Jester"
            ,"Ranger", "Ringmaster", "Billposter", "Psykeeper", "Elementor", "Gatekeeper", "Doppler", "Knight Master", "Blade Master", "Jester Master"
            ,"Ranger Master", "Ringmaster Master", "Billposter Master", "Psykeeper Master", "Elementor Master","Knight Hero", "Blade Hero", "Jester Hero"
            ,"Ranger Hero", "Ringmaster Hero", "Billposter Hero", "Psykeeper Hero", "Elementor Hero", "Templar", "Slayer", "Harlequin", "Crackshooter", "Seraph"
            ,"Force Master", "Mentalist", "Arcanist"};
            return JobName[Convert.ToInt32(nJob)];
        }
    }
}



static class GlobalVariable
{
    /////////////////////
    /// CHARACTER_TBL ///
    /////////////////////
    public static string iaccount;
    public static string idPlayer;
    public static string iserverindex;
    public static string im_szName;
    public static string iplayerslot;
    public static string idwWorldID;
    public static string im_dwIndex;
    public static string im_vScale_x;
    public static string im_dwMotion;
    public static string im_vPos_x;
    public static string im_vPos_y;
    public static string im_vPos_z;
    public static string im_fAngle;
    public static string im_szCharacterKey;
    public static string im_nHitPoint;
    public static string im_nManaPoint;
    public static string im_nFatiguePoint;
    public static string im_nFuel;
    public static string im_dwSkinSet;
    public static string im_dwHairMesh;
    public static string im_dwHairColor;
    public static string im_dwHeadMesh;
    public static string im_dwSex;
    public static string im_dwRideItemIdx;
    public static string im_dwGold;
    public static string im_nJob;
    public static string im_pActMover;
    public static string im_nStr;
    public static string im_nSta;
    public static string im_nDex;
    public static string im_nInt;
    public static string im_nLevel;
    public static string im_nMaximumLevel;
    public static string im_nExp1;
    public static string im_nExp2;
    public static string im_aJobSkill;
    public static string im_aLicenseSkill;
    public static string im_aJobLv;
    public static string im_dwExpertLv;
    public static string im_idMarkingWorld;
    public static string im_vMarkingPos_x;
    public static string im_vMarkingPos_y;
    public static string im_vMarkingPos_z;
    public static string im_nRemainGP;
    public static string im_nRemainLP;
    public static string im_nFlightLv;
    public static string im_nFxp;
    public static string im_nTxp;
    public static string im_lpQuestCntArray;
    public static string im_chAuthority;
    public static string im_dwMode;
    public static string im_idparty;
    public static string im_idCompany;
    public static string im_idMuerderer;
    public static string im_nFame;
    public static string im_nDeathExp;
    public static string im_nDeathLevel;
    public static string im_dwFlyTime;
    public static string im_nMessengerState;
    public static string iblockby;
    public static string iTotalPlayTime;
    public static string iisblock;
    public static string iEnd_Time;
    public static string iBlockTime;
    public static string iCreateTime;
    public static string im_tmAccFuel;
    public static string im_tGuildMember;
    public static string im_dwSkillPoint;
    public static string im_aCompleteQuest;
    public static string im_dwReturnWorldID;
    public static string im_vReturnPos_x;
    public static string im_vReturnPos_y;
    public static string im_vReturnPos_z;
    public static string iMultiServer;
    public static string im_SkillPoint;
    public static string im_SkillLv;
    public static string im_SkillExp;
    public static string idwEventFlag;
    public static string idwEventTime;
    public static string idwEventElapsed;
    public static string iPKValue;
    public static string iPKPropensity;
    public static string iPKExp;
    public static string iAngelExp;
    public static string iAngelLevel;
    public static string iFinalLevelDt;
    public static string im_dwPetId;
    public static string im_nExpLog;
    public static string im_nAngelExpLog;
    public static string im_nCoupon;
    public static string im_nHonor;
    public static string im_nLayer;
    public static string im_nCampusPoint;
    public static string iidCampus;
    public static string im_aCheckedQuest;
    //////////////////////////////////////////////////////////////////
    public static string TradeId;
}