
//using Helpers;
//using Helpers.Dto;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Timers;
//using static AtkTennisApp.Program;

//namespace AtkTennisApp.Worker
//{
//    public static class SettingsWorker
//    {
//        public static System.Timers.Timer getSettingsTimer = new System.Timers.Timer();

//        public static bool getProgress = false;

//        public static void StartTimers()
//        {
//            //getSettingsTimer.Elapsed += new ElapsedEventHandler(getMySettings);
//            //getSettingsTimer.Interval = 10000;
//            //getSettingsTimer.Enabled = true;
//        }

//        private static void getMySettings(object source, ElapsedEventArgs e)
//        {
//            if (!getProgress)
//            {
//                getProgress = true;

//                try
//                {
//                    MutualsConstantsDto appLogList = new MutualsConstantsDto();
//                    var x = set.MyIpAdress;

//                    appLogList = Serializers.DeserializeJson<MutualsConstantsDto>(Request.Get(Mutuals.AdminUrl + "Product/GetMySettings?MyIp=" + x));

//                    if (appLogList != null)
//                        MutualConstants.CompanyName = appLogList.CompanyName;


//                    if (appLogList == null)
//                    {
//                        MutualConstants.M1 = false;
//                        MutualConstants.M2 = false;
//                        MutualConstants.M3 = false;
//                        MutualConstants.M4 = false;
//                        MutualConstants.M5 = false;
//                        MutualConstants.M6 = false;
//                    }

//                    else
//                    {


//                        if (appLogList.M1 != null)
//                            MutualConstants.M1 = appLogList.M1;
//                        else
//                            MutualConstants.M1 = false;

//                        if (appLogList.M2 != null)
//                            MutualConstants.M2 = appLogList.M2;
//                        else
//                            MutualConstants.M2 = false;

//                        if (appLogList.M3 != null)
//                            MutualConstants.M3 = appLogList.M3;
//                        else
//                            MutualConstants.M3 = false;

//                        if (appLogList.M4 != null)
//                            MutualConstants.M4 = appLogList.M4;
//                        else
//                            MutualConstants.M4 = false;

//                        if (appLogList.M5 != null)
//                            MutualConstants.M5 = appLogList.M5;
//                        else
//                            MutualConstants.M5 = false;

//                        if (appLogList.M6 != null)
//                            MutualConstants.M6 = appLogList.M6;
//                        else
//                            MutualConstants.M6 = false;
//                    }


//                }
//                catch (Exception ex)
//                {
//                    Mutuals.monitizer.AddException(ex);
//                }
//            }

//            getProgress = false;
//        }

//        public static void getSettings()
//        {
//            try
//            {
//                MutualsConstantsDto appLogList = new MutualsConstantsDto();

//                appLogList = Serializers.DeserializeJson<MutualsConstantsDto>(Request.Get(Mutuals.AdminUrl + "Product/GetMySettings?MyIp=" + Mutuals.MyIp));

//                if (appLogList != null)
//                    MutualConstants.CompanyName = appLogList.CompanyName;

//                if (appLogList == null)
//                {
//                    MutualConstants.M1 = false;
//                    MutualConstants.M2 = false;
//                    MutualConstants.M3 = false;
//                    MutualConstants.M4 = false;
//                    MutualConstants.M5 = false;
//                    MutualConstants.M6 = false;
//                }
//                else
//                {


//                    if (appLogList.M1 != null)
//                        MutualConstants.M1 = appLogList.M1;
//                    else
//                        MutualConstants.M1 = false;

//                    if (appLogList.M2 != null)
//                        MutualConstants.M2 = appLogList.M2;
//                    else
//                        MutualConstants.M2 = false;

//                    if (appLogList.M3 != null)
//                        MutualConstants.M3 = appLogList.M3;
//                    else
//                        MutualConstants.M3 = false;

//                    if (appLogList.M4 != null)
//                        MutualConstants.M4 = appLogList.M4;
//                    else
//                        MutualConstants.M4 = false;

//                    if (appLogList.M5 != null)
//                        MutualConstants.M5 = appLogList.M5;
//                    else
//                        MutualConstants.M5 = false;

//                    if (appLogList.M6 != null)
//                        MutualConstants.M6 = appLogList.M6;
//                    else
//                        MutualConstants.M6 = false;
//                }


//            }
//            catch (Exception ex)
//            {
//                Mutuals.monitizer.AddException(ex);
//            }
//        }

//        private static void getMySettings2(string companyId)
//        {
//            try
//            {
//                MutualsConstantsDto appLogList = new MutualsConstantsDto();
//                var x = set.MyIpAdress;

//                appLogList = Serializers.DeserializeJson<MutualsConstantsDto>(Request.Get(Mutuals.AdminUrl + "Product/GetMySettings?MyIp=" + companyId));

//                if (appLogList != null)
//                    MutualConstants.CompanyName = appLogList.CompanyName;

//                if (appLogList == null)
//                {
//                    MutualConstants.M1 = false;
//                    MutualConstants.M2 = false;
//                    MutualConstants.M3 = false;
//                    MutualConstants.M4 = false;
//                    MutualConstants.M5 = false;
//                    MutualConstants.M6 = false;
//                }

//                else
//                {
//                    if (appLogList.M1 != null)
//                        MutualConstants.M1 = appLogList.M1;
//                    else
//                        MutualConstants.M1 = false;

//                    if (appLogList.M2 != null)
//                        MutualConstants.M2 = appLogList.M2;
//                    else
//                        MutualConstants.M2 = false;

//                    if (appLogList.M3 != null)
//                        MutualConstants.M3 = appLogList.M3;
//                    else
//                        MutualConstants.M3 = false;

//                    if (appLogList.M4 != null)
//                        MutualConstants.M4 = appLogList.M4;
//                    else
//                        MutualConstants.M4 = false;

//                    if (appLogList.M5 != null)
//                        MutualConstants.M5 = appLogList.M5;
//                    else
//                        MutualConstants.M5 = false;

//                    if (appLogList.M6 != null)
//                        MutualConstants.M6 = appLogList.M6;
//                    else
//                        MutualConstants.M6 = false;
//                }
//            }
//            catch (Exception ex)
//            {
//                Mutuals.monitizer.AddException(ex);
//            }
//        }

//    }
//}
