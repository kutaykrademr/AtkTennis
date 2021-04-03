using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennis
{
    public class Serializers
    {
        public static string SerializeJson(object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch
            {
                return null;
            }
        }

        public static T DeserializeJson<T>(string obj)
        {
            try
            {
                var jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;

                return JsonConvert.DeserializeObject<T>(obj, jsonSerializerSettings);
            }
            catch
            {
                return default(T);
            }
        }
    }
}
