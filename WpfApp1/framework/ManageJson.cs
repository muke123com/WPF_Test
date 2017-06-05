using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace WpfApp1
{
    class ManageJson
    {
        /// <summary>
        /// json字符串转为json
        /// </summary>
        /// <param name="fileText"></param>
        /// <returns></returns>
        public static JObject GetJson(String fileText)
        {
            var fileJson = JsonConvert.DeserializeObject<JObject>(fileText);
            return fileJson;
        }

        /// <summary>
        /// json转为json字符串
        /// </summary>
        /// <param name="fileJson"></param>
        /// <returns></returns>
        public static String GetString(JObject fileJson)
        {
            String fileText = JsonConvert.SerializeObject(fileJson);
            return fileText;
        }
    }
}
