using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chinahoo.Extensions.Session.FreeRedis
{
    public class Utils
    {
        /// <summary>
        /// 转换为64位
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long ToInt64(object str)
        {

            long i = 0;
            try
            {
                if (str!=null)
                {
                    long.TryParse(str.ToString(), out i);
                }
            }
            catch { }
            return i;

        }
        /// <summary>
        /// 将字符串类型数据转换成int类型数据
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>返回0表示字符串非int类型</returns>
        public static int ToInt(object str)
        {
            int i = 0;
            try
            {
                if (str !=null)
                {
                    int.TryParse(str.ToString(), out i);
                }
            }
            catch
            {
            }
            return i;
        }
        /// <summary>
        /// 序列化操作
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="obj">序列化对象</param>
        /// <returns></returns>
        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        /// <summary>
        /// 反序列化操作
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="json">字符传</param>
        /// <returns></returns>
        public static T Deserialize<T>(string json)
        {
            return (T)JsonConvert.DeserializeObject(json, typeof(T));
        }
    }
}
