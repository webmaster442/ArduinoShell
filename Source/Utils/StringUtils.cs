//-----------------------------------------------------------------------------
// (c) 2020 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

using System;

namespace ArduinoShell.Utils
{
    internal static class StringUtils
    {
        public static string[] Tokenize(this string input)
        {
            return input.Split(' ');
        }

        //0b - binary format
        //0x - hexa
        //08 - octal format
        //_ and - number separator
        //standard numbers
        private static bool TryParseString(string str, out long value)
        {
            str = str.Replace('_', '-').Replace("-", "");

            if (str.StartsWith("0b"))
                return TryParseInBase(str.Substring(2), 2, out value);
            else if (str.StartsWith("0x"))
                return TryParseInBase(str.Substring(2), 16, out value);
            else if (str.StartsWith("08"))
                return TryParseInBase(str.Substring(2), 8, out value);
            else
                return long.TryParse(str, out value);
        }

        private static bool TryParseInBase(string input, int baseSystem, out long value)
        {
            try
            {
                value = Convert.ToInt64(input, baseSystem);
                return true;
            }
            catch (Exception ex)
            {
                value = 0;
                return false;
            }
        }

        public static bool TryParseInt(this string input, out int result)
        {
            if (TryParseString(input, out long temp)
                && temp >= int.MinValue
                && temp <= int.MaxValue)
            {
                result = (int)temp;
                return true;
            }

            result = 0;
            return false;
        }

        public static bool TryParseShort(this string input, out short result)
        {
            if (TryParseString(input, out long temp)
                && temp >= short.MinValue
                && temp <= short.MaxValue)
            {
                result = (short)temp;
                return true;
            }

            result = 0;
            return false;
        }

        public static bool TryParseByte(this string input, out byte result)
        {
            if (TryParseString(input, out long temp)
                && temp >= byte.MinValue
                && temp <= byte.MaxValue)
            {
                result = (byte)temp;
                return true;
            }

            result = 0;
            return false;
        }
    }
}
