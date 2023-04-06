using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AdminSSO.Utils
{
    public static class Utility
    {
        const string keyAes = "b14ca5898a4e4133bbce2ea2315a1916";
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
            else if (countRows >= 10 && countRows < 100)
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

        public static string EncryptAes(string text)
        {
            try
            {
                if (string.IsNullOrEmpty(keyAes))
                    throw new ArgumentException("Key must have valid value.", nameof(keyAes));
                if (string.IsNullOrEmpty(text))
                    throw new ArgumentException("The text must have valid value.", nameof(text));

                var buffer = Encoding.UTF8.GetBytes(text);
                var hash = new SHA512CryptoServiceProvider();
                var aesKey = new byte[24];
                Buffer.BlockCopy(hash.ComputeHash(Encoding.UTF8.GetBytes(keyAes)), 0, aesKey, 0, 24);

                using (var aes = Aes.Create())
                {
                    if (aes == null)
                        throw new ArgumentException("Parameter must not be null.", nameof(aes));

                    aes.Key = aesKey;

                    using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                    using (var resultStream = new MemoryStream())
                    {
                        using (var aesStream = new CryptoStream(resultStream, encryptor, CryptoStreamMode.Write))
                        using (var plainStream = new MemoryStream(buffer))
                        {
                            plainStream.CopyTo(aesStream);
                        }

                        var result = resultStream.ToArray();
                        var combined = new byte[aes.IV.Length + result.Length];
                        Array.ConstrainedCopy(aes.IV, 0, combined, 0, aes.IV.Length);
                        Array.ConstrainedCopy(result, 0, combined, aes.IV.Length, result.Length);

                        //return Convert.ToBase64String(combined);
                        var res = WebEncoders.Base64UrlEncode(combined);
                        return res;
                    }
                }
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

        public static string DecryptAes(string encryptedText)
        {
            try
            {
                if (string.IsNullOrEmpty(keyAes))
                    throw new ArgumentException("Key must have valid value.", nameof(keyAes));
                if (string.IsNullOrEmpty(encryptedText))
                    throw new ArgumentException("The encrypted text must have valid value.", nameof(encryptedText));

                //var combined = Convert.FromBase64String(encryptedText);
                var combined = WebEncoders.Base64UrlDecode(encryptedText);

                var buffer = new byte[combined.Length];
                var hash = new SHA512CryptoServiceProvider();
                var aesKey = new byte[24];
                Buffer.BlockCopy(hash.ComputeHash(Encoding.UTF8.GetBytes(keyAes)), 0, aesKey, 0, 24);

                using (var aes = Aes.Create())
                {
                    if (aes == null)
                        throw new ArgumentException("Parameter must not be null.", nameof(aes));

                    aes.Key = aesKey;

                    var iv = new byte[aes.IV.Length];
                    var ciphertext = new byte[buffer.Length - iv.Length];

                    Array.ConstrainedCopy(combined, 0, iv, 0, iv.Length);
                    Array.ConstrainedCopy(combined, iv.Length, ciphertext, 0, ciphertext.Length);

                    aes.IV = iv;

                    using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                    using (var resultStream = new MemoryStream())
                    {
                        using (var aesStream = new CryptoStream(resultStream, decryptor, CryptoStreamMode.Write))
                        using (var plainStream = new MemoryStream(ciphertext))
                        {
                            plainStream.CopyTo(aesStream);
                        }

                        return Encoding.UTF8.GetString(resultStream.ToArray());
                    }
                }
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }
    }
}
