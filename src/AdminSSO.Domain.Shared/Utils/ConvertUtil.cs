using System;
using System.Collections.Generic;
using System.Text;


namespace AdminSSO.Utils
{
    public static class ConvertUtil
    {
        public static int ConvertToInt32(object value)
        {
            var result = 0;
            int.TryParse(value.ToString(), out result);
            return result;
        }
        public static long ConvertToLong(object value)
        {
            var result = 0L;
            long.TryParse(value.ToString(), out result);
            return result;
        }
        public static string ConvertToCode(int? input, int length = 4)
        {
            return input.HasValue ? input.Value.ToString("D" + length.ToString()) : string.Empty;
        }
        public static string ConvertToPhone84(string phone, bool convention = false)
        {
            if (phone.StartsWith("0"))
            {
                phone = phone.Remove(0, 1);
                if (convention)
                    phone = "+84" + phone;
                else
                    phone = "84" + phone;
            }
            return phone;
        }
    }
}
