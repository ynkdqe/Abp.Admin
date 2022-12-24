using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdminSSO.Utils
{
    public static class Utility
    {
        private static readonly Random random = new Random();

        private static readonly string[] VietnameseSigns = new string[]

        {

        "aAeEoOuUiIdDyY",

        "áàạảãâấầậẩẫăắằặẳẵ",

        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

        "éèẹẻẽêếềệểễ",

        "ÉÈẸẺẼÊẾỀỆỂỄ",

        "óòọỏõôốồộổỗơớờợởỡ",

        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

        "úùụủũưứừựửữ",

        "ÚÙỤỦŨƯỨỪỰỬỮ",

        "íìịỉĩ",

        "ÍÌỊỈĨ",

        "đ",

        "Đ",

        "ýỳỵỷỹ",

        "ÝỲỴỶỸ"

        };
        public static string RemoveSign4VietnameseString(this string str)
        {

            //Tiến hành thay thế , lọc bỏ dấu cho chuỗi

            for (int i = 1; i < VietnameseSigns.Length; i++)
            {

                for (int j = 0; j < VietnameseSigns[i].Length; j++)

                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);

            }

            return str;

        }
        public static string GetUserNameByFullName(string fullName)
        {
            var userName = string.Empty;
            if (!string.IsNullOrEmpty(fullName))
            {
                fullName = RemoveSign4VietnameseString(fullName);
                var arrName = fullName.Split(' ').ToList();
                if (arrName.Any()) userName = arrName.LastOrDefault();
                arrName = arrName.Take(arrName.Count - 1).ToList();
                foreach (var item in arrName)
                {
                    userName += item[0];
                }
            }
            else
            {
                return string.Empty;
            }
            return userName;
        }
        public static string GetUserCodeByTotalRecords(int countRows)
        {
            var result = string.Empty;
            if (countRows == 0)
                result = "00001";
            else if (countRows > 1 && countRows < 10)
                result = "0000" + countRows.ToString();
            else if(countRows >= 10 && countRows < 100)
                result = "000" + countRows.ToString();
            else if (countRows >= 100 && countRows < 1000)
                result = "00" + countRows.ToString();
            else if (countRows >= 1000 && countRows < 10000)
                result = "0" + countRows.ToString();
            else
                result = countRows.ToString();

            return result;
        }
        public static int RandomInt(int min, int max)
        {
            lock (random)
            {
                return random.Next(min, max);
            }
        }
        public static string RandomString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }
    }
}
