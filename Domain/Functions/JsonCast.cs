using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilesApi.Domain.Functions
{
    public static class JsonCast
    {
        public static string ToJson(object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
        public static T FromJson<T>(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }
        public static string getStringFromProperty(object obj, string property)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj.GetType().GetProperty(property).GetValue(obj, null));
        }

        public static Dictionary<string,string> GetDictionaryFromBody(HttpRequest request)
        {
            using (var reader = new StreamReader(request.Body))
            {
                var body = reader.ReadToEndAsync();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(body.Result);
                return result;
               
                
            }
           
        }
    }
}