using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;

namespace Common
{
    public class utils
    {

        #region 类copy
        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="destination">目标</param>
        /// <param name="source">来源</param>
        /// <returns>成功复制的值个数</returns>
        public static int Copy(object destination, object source)
        {
            if (destination == null || source == null)
            {
                return 0;
            }
            return Copy(destination, source, source.GetType());
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="destination">目标</param>
        /// <param name="source">来源</param>
        /// <param name="type">复制的属性字段模板</param>
        /// <returns>成功复制的值个数</returns>
        public static int Copy(object destination, object source, Type type)
        {
            return Copy(destination, source, type, null);
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="destination">目标</param>
        /// <param name="source">来源</param>
        /// <param name="type">复制的属性字段模板</param>
        /// <param name="excludeName">排除下列名称的属性不要复制</param>
        /// <returns>成功复制的值个数</returns>
        public static int Copy(object destination, object source, Type type, IEnumerable<string> excludeName)
        {
            if (destination == null || source == null)
            {
                return 0;
            }
            if (excludeName == null)
            {
                excludeName = new List<string>();
            }
            int i = 0;
            Type desType = destination.GetType();
            foreach (FieldInfo mi in type.GetFields())
            {
                if (excludeName.Contains(mi.Name))
                {
                    continue;
                }
                try
                {
                    FieldInfo des = desType.GetField(mi.Name);
                    if (des != null && des.FieldType == mi.FieldType)
                    {
                        des.SetValue(destination, mi.GetValue(source));
                        i++;
                    }

                }
                catch
                {
                }
            }

            foreach (PropertyInfo pi in type.GetProperties())
            {
                if (excludeName.Contains(pi.Name))
                {
                    continue;
                }
                try
                {
                    PropertyInfo des = desType.GetProperty(pi.Name);
                    if (des != null && des.PropertyType == pi.PropertyType && des.CanWrite && pi.CanRead)
                    {
                        des.SetValue(destination, pi.GetValue(source, null), null);
                        i++;
                    }

                }
                catch
                {
                    //throw ex;
                }
            }
            return i;
        }
        #endregion

        #region json序列化
        public static string SerializeList<T>(List<T> list)
        {
            JavaScriptSerializer serial = new JavaScriptSerializer();
            return serial.Serialize(list);
        }

        public static string SerializeObject<T>(T t)
        {
            JavaScriptSerializer serial = new JavaScriptSerializer();
            return serial.Serialize(t);
        }

        public static string SerializeListWithTime<T>(List<T> list)
        {
            JavaScriptSerializer serial = new JavaScriptSerializer();
            string str = serial.Serialize(list);
            str = Regex.Replace(str, @"\\/Date\((\d+)\)\\/", match =>
            {
                DateTime dt = new DateTime(1970, 1, 1);
                dt = dt.AddMilliseconds(long.Parse(match.Groups[1].Value));
                dt = dt.ToLocalTime();
                return dt.ToString("yyyy-MM-dd HH:mm:ss");
            });
            return str;
        }

        public static string SerializeObjectWithTime<T>(T t)
        {
            JavaScriptSerializer serial = new JavaScriptSerializer();
            string str = serial.Serialize(t);
            str = Regex.Replace(str, @"\\/Date\((\d+)\)\\/", match =>
            {
                DateTime dt = new DateTime(1970, 1, 1);
                dt = dt.AddMilliseconds(long.Parse(match.Groups[1].Value));
                dt = dt.ToLocalTime();
                return dt.ToString("yyyy-MM-dd HH:mm:ss");
            });
            return str;
        }
        #endregion

        #region 类注入
        public static T AutoWiredClass<T>(HttpRequest h, T t)
        {
            Type type = t.GetType();
            foreach (PropertyInfo pi in type.GetProperties())
            {
                try
                {
                    if (h[pi.Name] != null && pi.CanWrite)
                    {
                        pi.SetValue(t, ConvertObject(h[pi.Name], pi.PropertyType), null);
                    }
                }
                catch
                {
                    //throw ex;
                }
            }
            return t;
        }
        #endregion

        #region object类型转化为指定的类型
        /// <summary>
        /// 类型转换,将Object类型转换为指定的类型
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static object ConvertObject(object value, Type type)
        {
            object returnValue = value;


            switch (System.Type.GetTypeCode(type))
            {
                case System.TypeCode.Object:
                    {
                        if (value == DBNull.Value) { returnValue = null; } else { returnValue = value; }
                        break;
                    }
                case System.TypeCode.Boolean:
                    {
                        if (null == value || value.ToString().Equals("0"))
                        {
                            returnValue = false;
                        }
                        else if (value.ToString().Equals("1"))
                        {
                            returnValue = true;
                        }
                        break;
                    }
                case System.TypeCode.SByte:
                    {
                        if (value == DBNull.Value) { returnValue = 0; } else { returnValue = SByte.Parse(value.ToString()); }
                        break;
                    }
                case System.TypeCode.Byte:
                    {
                        if (value == DBNull.Value) { returnValue = 0; } else { returnValue = Byte.Parse(value.ToString()); }
                        break;
                    }
                case System.TypeCode.Char:
                    {
                        // TODO
                        break;
                    }
                case System.TypeCode.DateTime:
                    {
                        if (value == DBNull.Value) { returnValue = null; } else { returnValue = DateTime.Parse(value.ToString()); }
                        break;
                    }
                case System.TypeCode.Single:
                    {
                        if (value == DBNull.Value) { returnValue = 0; } else { returnValue = Single.Parse(value.ToString()); }
                        break;
                    }
                case System.TypeCode.Decimal:
                    {
                        if (value == DBNull.Value) { returnValue = 0; } else { returnValue = Decimal.Parse(value.ToString()); }
                        break;
                    }
                case System.TypeCode.Double:
                    {
                        if (value == DBNull.Value) { returnValue = 0; } else { returnValue = Double.Parse(value.ToString()); }
                        break;
                    }
                case System.TypeCode.Int16:
                    {
                        if (value == DBNull.Value) { returnValue = 0; } else { returnValue = Int16.Parse(value.ToString()); }
                        break;
                    }
                case System.TypeCode.UInt16:
                    {
                        if (value == DBNull.Value) { returnValue = 0; } else { returnValue = UInt16.Parse(value.ToString()); }
                        break;
                    }
                case System.TypeCode.Int32:
                    {
                        if (value == DBNull.Value) { returnValue = 0; } else { returnValue = Int32.Parse(value.ToString()); }
                        break;
                    }
                case System.TypeCode.UInt32:
                    {
                        if (value == DBNull.Value) { returnValue = 0; } else { returnValue = UInt32.Parse(value.ToString()); }
                        break;
                    }
                case System.TypeCode.Int64:
                    {
                        if (value == DBNull.Value) { returnValue = 0; } else { returnValue = Int64.Parse(value.ToString()); }
                        break;
                    }
                case System.TypeCode.UInt64:
                    {
                        if (value == DBNull.Value) { returnValue = 0; } else { returnValue = UInt64.Parse(value.ToString()); }
                        break;
                    }
                case System.TypeCode.String:
                    {
                        if (value == DBNull.Value) { returnValue = null; } else { returnValue = value.ToString(); }
                        break;
                    }
                default:
                    {
                        break;
                    }

            }
            return returnValue;
        }

        #endregion


    }
}
