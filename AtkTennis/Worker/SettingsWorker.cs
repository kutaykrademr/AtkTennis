using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using AtkTennis.ViewModels.AppSettingsModels;

namespace AtkTennis.Worker
{
    public static class SettingsWorker
    {
        public static System.Timers.Timer getSettingsTimer = new System.Timers.Timer();

        public static bool getProgress = false;

        public static void StartTimers()
        {
            getSettingsTimer.Elapsed += new ElapsedEventHandler(getMySettings);
            getSettingsTimer.Interval = 10000;
            getSettingsTimer.Enabled = true;
        }

        private static void getMySettings(object source, ElapsedEventArgs e)
        {
            if (!getProgress)
            {
                getProgress = true;

                try
                {
                    MySettings appLogList = new MySettings();

                    appLogList = Serializers.DeserializeJson<MySettings>(Request.Get(Mutuals.AdminUrl + "Product/GetMySettings?MyIp=" + Mutuals.MyIp));

                    Mutuals.CompName = appLogList.CompanyName;

                    if (appLogList == null)
                    {
                        Mutuals.M1 = false;
                        Mutuals.M2 = false;
                        Mutuals.M3 = false;
                        Mutuals.M4 = false;
                        Mutuals.M5 = false;
                        Mutuals.M6 = false;
                    }
                    else
                    {


                        if (appLogList.M1 != null)
                            Mutuals.M1 = appLogList.M1;
                        else
                            Mutuals.M1 = false;

                        if (appLogList.M2 != null)
                            Mutuals.M2 = appLogList.M2;
                        else
                            Mutuals.M2 = false;

                        if (appLogList.M3 != null)
                            Mutuals.M3 = appLogList.M3;
                        else
                            Mutuals.M3 = false;

                        if (appLogList.M4 != null)
                            Mutuals.M4 = appLogList.M4;
                        else
                            Mutuals.M4 = false;

                        if (appLogList.M5 != null)
                            Mutuals.M5 = appLogList.M5;
                        else
                            Mutuals.M5 = false;

                        if (appLogList.M6 != null)
                            Mutuals.M6 = appLogList.M6;
                        else
                            Mutuals.M6 = false;
                    }


                }
                catch (Exception)
                {
                   
                }
            }

            getProgress = false;
        }

        public static void getSettings()
        {
            try
            {
                MySettings appLogList = new MySettings();

                appLogList = Serializers.DeserializeJson<MySettings>(Request.Get(Mutuals.AdminUrl + "Product/GetMySettings?MyIp=" + Mutuals.MyIp));

                Mutuals.CompName = appLogList.CompanyName;

                if (appLogList == null)
                {
                    Mutuals.M1 = false;
                    Mutuals.M2 = false;
                    Mutuals.M3 = false;
                    Mutuals.M4 = false;
                    Mutuals.M5 = false;
                    Mutuals.M6 = false;
                }
                else
                {


                    if (appLogList.M1 != null)
                        Mutuals.M1 = appLogList.M1;
                    else
                        Mutuals.M1 = false;

                    if (appLogList.M2 != null)
                        Mutuals.M2 = appLogList.M2;
                    else
                        Mutuals.M2 = false;

                    if (appLogList.M3 != null)
                        Mutuals.M3 = appLogList.M3;
                    else
                        Mutuals.M3 = false;

                    if (appLogList.M4 != null)
                        Mutuals.M4 = appLogList.M4;
                    else
                        Mutuals.M4 = false;

                    if (appLogList.M5 != null)
                        Mutuals.M5 = appLogList.M5;
                    else
                        Mutuals.M5 = false;

                    if (appLogList.M6 != null)
                        Mutuals.M6 = appLogList.M6;
                    else
                        Mutuals.M6 = false;
                }


            }
            catch (Exception)
            {

            }
        }
    }
}
