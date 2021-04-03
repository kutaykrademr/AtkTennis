using Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Timers;

namespace AtkTennisApp
{
    public class Monitizer
    {
        public int startSuccesful = 0;

        public int fatalCounter = 0;

        public int exceptionCounter = 0;

        public List<ErrorLogsDto> exceptions = new List<ErrorLogsDto>();

        public List<ApplicationLogsDto> logs = new List<ApplicationLogsDto>();

        public List<string> console = new List<string>();

        public string appName = "";

        public string ipAddress = "";

        public bool rabbitConnection = false;

        public static Timer appStatusTimer = new Timer();

        public Monitizer()
        {

            appName = Assembly.GetEntryAssembly().GetName().Name;

            var dns = Dns.GetHostAddresses(Dns.GetHostName());
            if (dns.Length > 0)
            {
                ipAddress = dns[dns.Length - 1].ToString();
                if (dns.Length > 1 && ipAddress.Length > 20)
                {
                    ipAddress = dns[0].ToString();
                }
            }
        }

        public void AddException(Exception ex, bool isfatal = false, string IdFieldName = "", int IdField = 0)
        {
            exceptionCounter++;

            if (isfatal)
            {
                fatalCounter++;
            }

            ErrorLogsDto log = new ErrorLogsDto();
            log.Application = appName;
            log.Server = ipAddress;
            log.Date = DateTime.Now;
            log.IdField = IdField;
            log.IdFieldName = IdFieldName;
            log.Message = GetExceptionMessages(ex);
            MethodBase site = ex.TargetSite;
            string methodName = site == null ? "" : site.Name;
            log.Target = methodName;
            string trace = ex.StackTrace == null ? "" : ex.StackTrace;
            log.Trace = trace;
            log.Type = "";

            exceptions.Add(log);

            if (exceptions.Count > 1000)
            {
                exceptions.RemoveAt(0);
            }

            Mutuals.ErrorLogs.Enqueue(log);

            AddConsole(ex.Message);
        }

        public void AddLog(string explanation, string IdFieldName = "", int IdField = 0)
        {
            ApplicationLogsDto log = new ApplicationLogsDto();
            log.Application = appName;
            log.Server = ipAddress;
            log.IdField = IdField;
            log.IdFieldName = IdFieldName;
            log.Explanation = explanation;
            log.Type = "";
            log.Date = DateTime.Now;
            logs.Add(log);

            if (logs.Count > 1000)
            {
                logs.RemoveAt(0);
            }

            Mutuals.ApplicationLogs.Enqueue(log);
        }

        public void AddUserLog(string explanation, string ip, string port, int userid, string type = "")
        {
            UserLogsDto log = new UserLogsDto();
            log.Application = appName;
            log.Date = DateTime.Now;
            log.Explanation = explanation;
            log.Ip = ip;
            log.Port = port;
            log.UserId = userid;
            log.Type = type;
            Mutuals.UserLogs.Enqueue(log);
        }

        public void AddQueryLog(string classname, string query, string parameters, int milisecond, string UserId = "0")
        {
            QueryLogsDto log = new QueryLogsDto();
            log.QueryClass = classname;
            log.QueryName = query;
            log.Parameters = parameters;
            log.ElapsedMilisecond = milisecond;
            log.Date = DateTime.Now;
            log.UserId = Convert.ToInt32(UserId);
            Mutuals.QueryLogs.Enqueue(log);
        }

        public void AddConsole(string text)
        {
            console.Add(DateTime.Now.ToString() + " :: " + text);
            if (console.Count > 1000)
            {
                console.RemoveAt(0);
            }
        }

        public string GetExceptionMessages(Exception e, string msgs = "")
        {
            if (e == null) return string.Empty;
            if (msgs == "") msgs = e.Message;
            if (e.InnerException != null)
                msgs += "\r\nInnerException: " + GetExceptionMessages(e.InnerException);
            return msgs;
        }

        public MonitizerResult GetMonitizerResult()
        {
            MonitizerResult res = new MonitizerResult();

            res.exceptionCounter = exceptionCounter;

            if (exceptions.Count > 10)
            {
                res.exceptions = exceptions.OrderByDescending(x => x.Date).Take(10).ToList();
            }
            else
            {
                res.exceptions = exceptions;
            }

            res.fatalCounter = fatalCounter;

            if (logs.Count > 10)
            {
                res.logs = logs.OrderByDescending(x => x.Date).Take(10).ToList();
            }
            else
            {
                res.logs = logs;
            }
            res.startSuccesful = startSuccesful;
            res.AppName = appName;
            res.IpAddress = ipAddress;
            res.console = console.ToList();
            res.console.Reverse();

            return res;
        }
    }
}
