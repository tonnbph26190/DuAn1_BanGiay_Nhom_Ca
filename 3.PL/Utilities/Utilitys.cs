using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3.PL.Utilities
{
    public class Utilitys
    {
        public static string ZenMaTuDong(string fullName)
        {
            string temp = fullName.Trim().ToLower();
            string[] arrValues = temp.Split(' ');
            string final = GetVietHoaChuCaiDau(arrValues[arrValues.Length - 1]).Trim();
            for (int i = 0; i < arrValues.Length - 1; i++)
            {
                final += GetChuCaiDau(arrValues[i]);
            }
            return LoaiBoDauTiengViet(final);
        }
        public static string GetNumber(int length)
        {
            Random random = new Random();
            string allchar = "0123456789";
            string ketqua = "";

            for (int i = 0; i < length; i++)
            {
                ketqua += allchar[(random.Next(length))];
            }
            return ketqua;
        }

        public static string VietHoaFullName(string fullName)
        {
            string temp = fullName.Trim().ToLower();
            string[] arrValues = temp.Split(' ');
            string final = "";

            for (int i = 0; i < arrValues.Length; i++)
            {
                final += GetVietHoaChuCaiDau(arrValues[i]);
            }
            return final;
        }

        private static string GetChuCaiDau(string value)
        {
            if (string.IsNullOrEmpty(value)) return "";
            return Convert.ToString(value[0]);
        }
        public static bool checkSDT(string input)
        {
            if (Regex.IsMatch(input, @"((09|03|07|08|05)+([0-9]{8})\b)"))
            {
                return true;
            }
            return false;
        }

        private static string GetVietHoaChuCaiDau(string value)
        {
            if (string.IsNullOrEmpty(value)) return "";
            return Convert.ToString(value[0]).ToUpper() + value.Substring(1) + " ";
        }

        //Loại bỏ toàn bộ dấu trong tiếng việt
        public static string LoaiBoDauTiengViet(string str)
        {
            string strFormD = str.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strFormD.Length; i++)
            {
                System.Globalization.UnicodeCategory uc =
                    System.Globalization.CharUnicodeInfo.GetUnicodeCategory(strFormD[i]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(strFormD[i]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            return (sb.ToString().Normalize(NormalizationForm.FormD));
        }
    }
}
