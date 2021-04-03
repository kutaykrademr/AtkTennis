using Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp
{
    public static class Mutuals
    {
        public static string DbUrl { get; set; }
        public static string AdminUrl { get; set; }
        public static string MyIp { get; set; }



        public static Monitizer monitizer { get; set; } = new Monitizer();
        public static ConcurrentQueue<ErrorLogsDto> ErrorLogs = new ConcurrentQueue<ErrorLogsDto>();
        public static ConcurrentQueue<ApplicationLogsDto> ApplicationLogs = new ConcurrentQueue<ApplicationLogsDto>();
        public static ConcurrentQueue<UserLogsDto> UserLogs = new ConcurrentQueue<UserLogsDto>();
        public static ConcurrentQueue<QueryLogsDto> QueryLogs = new ConcurrentQueue<QueryLogsDto>();
    }
}
