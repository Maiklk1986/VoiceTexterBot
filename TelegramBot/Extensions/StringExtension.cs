using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Extensions
{
    internal static class StringExtension
    {

        /// <summary>
        /// Преобразуем строку, чтобы она начиналась с заглавной буквы
        /// </summary>

        public static string UpperCaseFirst(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;

            } 
            return char.ToUpper(str[0]) + str.Substring(1);
        }
    }
}
