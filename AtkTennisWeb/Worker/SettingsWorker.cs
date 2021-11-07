using Helpers;
using Helpers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;


namespace AtkTennisWeb.Worker
{
    public static class SettingsWorker
    {
        //public static System.Timers.Timer getSettingsTimer = new System.Timers.Timer();

        //public static bool getProgress = false;

        //public static void StartTimers()
        //{
        //    getSettingsTimer.Elapsed += new ElapsedEventHandler(getMySettings);
        //    getSettingsTimer.Interval = 10000;
        //    getSettingsTimer.Enabled = true;
        //}

        //private static void getMySettings(object source, ElapsedEventArgs e)
        //{
        //    if (!getProgress)
        //    {
        //        getProgress = true;

        //        try
        //        {
        //            MutualsConstantsDto appLogList = new MutualsConstantsDto();

        //            appLogList = Serializers.DeserializeJson<MutualsConstantsDto>(Request.Get(Mutuals.AppUrl + "Public/GetMySettings"));

        //            if (appLogList != null)
        //                Mutuals.CompName = appLogList.CompanyName;

        //            if (appLogList == null)
        //            {
        //                Mutuals.M1 = false;
        //                Mutuals.M2 = false;
        //                Mutuals.M3 = false;
        //                Mutuals.M4 = false;
        //                Mutuals.M5 = false;
        //                Mutuals.M6 = false;
        //            }
        //            else
        //            {


        //                if (appLogList.M1 != null)
        //                    Mutuals.M1 = appLogList.M1;
        //                else
        //                    Mutuals.M1 = false;

        //                if (appLogList.M2 != null)
        //                    Mutuals.M2 = appLogList.M2;
        //                else
        //                    Mutuals.M2 = false;

        //                if (appLogList.M3 != null)
        //                    Mutuals.M3 = appLogList.M3;
        //                else
        //                    Mutuals.M3 = false;

        //                if (appLogList.M4 != null)
        //                    Mutuals.M4 = appLogList.M4;
        //                else
        //                    Mutuals.M4 = false;

        //                if (appLogList.M5 != null)
        //                    Mutuals.M5 = appLogList.M5;
        //                else
        //                    Mutuals.M5 = false;

        //                if (appLogList.M6 != null)
        //                    Mutuals.M6 = appLogList.M6;
        //                else
        //                    Mutuals.M6 = false;
        //            }

        //            foreach (var item in appLogList.UserSettingsList)
        //            {
        //                if (Mutuals.UserSettings.ContainsKey(item.RoleId))
        //                    Mutuals.UserSettings[item.RoleId] = item;
        //                else
        //                    Mutuals.UserSettings.Add(item.RoleId, item);
        //            }

        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }

        //    getProgress = false;
        //}

        //public static void getSettings()
        //{
        //    try
        //    {
        //        MutualsConstantsDto appLogList = new MutualsConstantsDto();

        //        appLogList = Serializers.DeserializeJson<MutualsConstantsDto>(Request.Get(Mutuals.AppUrl + "Public/GetMySettings"));

        //        if (appLogList != null)
        //            Mutuals.CompName = appLogList.CompanyName;

        //        if (appLogList == null)
        //        {
        //            Mutuals.M1 = false;
        //            Mutuals.M2 = false;
        //            Mutuals.M3 = false;
        //            Mutuals.M4 = false;
        //            Mutuals.M5 = false;
        //            Mutuals.M6 = false;
        //        }
        //        else
        //        {
        //            if (appLogList.M1 != null)
        //                Mutuals.M1 = appLogList.M1;
        //            else
        //                Mutuals.M1 = false;

        //            if (appLogList.M2 != null)
        //                Mutuals.M2 = appLogList.M2;
        //            else
        //                Mutuals.M2 = false;

        //            if (appLogList.M3 != null)
        //                Mutuals.M3 = appLogList.M3;
        //            else
        //                Mutuals.M3 = false;

        //            if (appLogList.M4 != null)
        //                Mutuals.M4 = appLogList.M4;
        //            else
        //                Mutuals.M4 = false;

        //            if (appLogList.M5 != null)
        //                Mutuals.M5 = appLogList.M5;
        //            else
        //                Mutuals.M5 = false;

        //            if (appLogList.M6 != null)
        //                Mutuals.M6 = appLogList.M6;
        //            else
        //                Mutuals.M6 = false;
        //        }

        //        foreach (var item in appLogList.UserSettingsList)
        //        {
        //            Mutuals.UserSettings.Add(item.RoleId, item);
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}


    }
}
