using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Utility
{
    public static class JsonHelper
    {
        #region 序列化
        /// <summary>
        /// 将对象(包含集合对象)序列化为Json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeObjToJson(this object obj)
        {
            string strRes = String.Empty;
            try
            {
                //var settings = new JsonSerializerSettings { ContractResolver = new LowercaseContractResolver() };
                var settings = new JsonSerializerSettings ();
                strRes = JsonConvert.SerializeObject(obj, settings);
            }
            catch (Exception exception)
            {
                //LogWriter.WriteLog("接口异常", "对象(包含集合对象)序列化为Json出错！" + exception.Message);
            }

            return strRes;
        }
        /// <summary>
        /// 把实体字段转换成小写
        /// </summary>
        //public class LowercaseContractResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
        //{
        //    protected override string ResolvePropertyName(string propertyName)
        //    {
        //        return propertyName.ToLower();
        //    }
        //}

        /// <summary>
        /// 支持Linq格式的xml转换
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static string SerializeXmlToJson(XNode node)
        {
            string strRes = String.Empty;
            try
            {
                strRes = JsonConvert.SerializeXNode(node);
            }
            catch (Exception exception)
            {
                //LogWriter.WriteLog("接口异常", "支持Linq格式的xml转换出错！" + exception.Message);
            }
            return strRes;
        }

        /// <summary>
        /// 将字典类型序列化为json字符串
        /// </summary>
        /// <typeparam name="TKey">字典key</typeparam>
        /// <typeparam name="TValue">字典value</typeparam>
        /// <param name="dict">要序列化的字典数据</param>
        /// <returns>json字符串</returns>
        public static string SerializeDictionaryToJsonString<TKey, TValue>(Dictionary<TKey, TValue> dict)
        {
            if (dict.Count == 0)
                return "";

            string jsonStr = JsonConvert.SerializeObject(dict);
            return jsonStr;
        }

        #endregion

        #region 反序列化
        /// <summary>
        /// 将json反序列化为实体对象(包含DataTable和List集合对象)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static T DeserializeJsonToObj<T>(this string strJson)
        {
            T oRes = default(T);
            try
            {
                oRes = JsonConvert.DeserializeObject<T>(strJson);
            }
            catch (Exception exception)
            {
                //LogWriter.WriteLog("接口异常", " 将json反序列化为实体对象(包含DataTable和List<>集合对象)出错！" + exception.Message);
            }

            return oRes;
        }

        /// <summary>
        /// 将json反序列化为实体对象(包含DataTable和List集合对象)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strJson"></param>
        /// <returns></returns>
        internal static IEnumerable<T> DeserializeJsonToEnumerable<T>(this string strJson)
        {
            try
            {
                return JsonConvert.DeserializeObject<IEnumerable<T>>(strJson);
            }
            catch (Exception exception)
            {
                // LogWriter.WriteLog("接口异常", " 将json反序列化为实体对象(包含DataTable和List<>集合对象)出错！" + exception.Message);
            }
            return null;
        }

        /// <summary>
        /// 将Json数组转换为实体集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lstJson"></param>
        /// <returns></returns>
        public static List<T> JsonLstToObjs<T>(List<string> lstJson)
        {
            List<T> lstRes = new List<T>();
            try
            {
                lstRes.AddRange(lstJson.Select(JsonConvert.DeserializeObject<T>));
            }
            catch (Exception exception)
            {
                //LogWriter.WriteLog("接口异常", "将Json数组转换为实体集合出错！" + exception.Message);
            }
            return lstRes;
        }

        /// <summary>
        /// 将json字符串反序列化为字典类型
        /// </summary>
        /// <typeparam name="TKey">字典key</typeparam>
        /// <typeparam name="TValue">字典value</typeparam>
        /// <param name="jsonStr">json字符串</param>
        /// <returns>字典数据</returns>
        public static Dictionary<TKey, TValue> DeserializeStringToDictionary<TKey, TValue>(string jsonStr)
        {
            if (string.IsNullOrEmpty(jsonStr))
                return new Dictionary<TKey, TValue>();

            Dictionary<TKey, TValue> jsonDict = JsonConvert.DeserializeObject<Dictionary<TKey, TValue>>(jsonStr);

            return jsonDict;

        }
        #endregion
    }
}
