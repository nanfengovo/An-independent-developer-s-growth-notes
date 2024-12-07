using Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Utility
{
    /// <summary>
    /// 枚举帮助类
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// 获取枚举描述值
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            Type enumType = value.GetType();
            // 获取枚举常数名称。
            string name = Enum.GetName(enumType, value);
            if (name != null)
            {
                // 获取枚举字段。
                FieldInfo fieldInfo = enumType.GetField(name);
                if (fieldInfo != null)
                {
                    // 获取描述的属性。
                    DescriptionAttribute attr = Attribute.GetCustomAttribute(fieldInfo,
                        typeof(DescriptionAttribute), false) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }


        /// <summary>
        /// 根据枚举值获取名称
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetName<T>(int value)
        {
            string name = Enum.Parse(typeof(T), Enum.GetName(typeof(T), value)).ToString();
            return name;
        }

        /// <summary>
        /// 获取枚举所有值,把枚举转换成list
        /// </summary>
        /// <typeparam name="T">枚举类</typeparam>
        /// <param name="type">枚举类</param>
        /// <param name="isTrue">true:描述等于value  false:字符等于value</param>
        /// <returns></returns>
        public static List<LayuiSelect> GetListAllEnumType<T>(this Type type, bool isTrue = true) where T : struct
        {
            if (!type.IsEnum)
                return null;

            var enumValues = Enum.GetValues(type);
            var list = new List<LayuiSelect>();
            foreach (Enum value in enumValues)
            {
                list.Add(new LayuiSelect
                {
                    //Id = value.GetHashCode().ToString(),
                    value = isTrue == false ? value.GetDescription() : value.ToString(),
                    label = isTrue == false ? value.ToString() : value.GetDescription(),
                });
            }
            return list;
        }

        /// <summary>
        /// 根据描述获取枚举下标
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="type">类型</param>
        /// <param name="descriptionValue">描述值</param>
        /// <returns></returns>
        public static int GetValueByDescription<T>(this Type type, string descriptionValue) where T : struct
        {
            var enumValue = 0;
            foreach (var value in Enum.GetValues(type))
            {
                var attribute = typeof(T).GetField(value.ToString()).GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);

                if (attribute != null && ((DescriptionAttribute)attribute[0]).Description == descriptionValue)
                {
                    enumValue = Convert.ToInt32(value);
                }
            }
            return enumValue;
        }
    }
}
