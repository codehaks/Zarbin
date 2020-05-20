using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Portal.Common.Extentions
{
    public static class EnumExtentions
    {
        public static string DisplayName(this Enum item)
        {
            var type = item.GetType();
            var member = type.GetMember(item.ToString());
            DisplayAttribute displayName = (DisplayAttribute)member[0]
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault();

            if (displayName != null)
            {
                return displayName.Name;
            }

            return item.ToString();
        }

        public static string GetValue(this Enum enumItem)
        {
            var value = Convert.ToInt32(enumItem);
            return value.ToString();
        }
    }
}