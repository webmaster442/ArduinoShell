//-----------------------------------------------------------------------------
// (c) 2020 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

namespace ArduinoShell.Utils
{
    internal static class StringUtils
    {
        public static string[] Tokenize(this string input)
        {
            return input.Split(' ');
        }

        public static bool TryParseInt(this string input, out int result)
        {
            return int.TryParse(input, out result);
        }

        public static bool TryParseShort(this string input, out short result)
        {
            return short.TryParse(input, out result);
        }

        public static bool TryParseByte(this string input, out byte result)
        {
            return byte.TryParse(input, out result);
        }
    }
}
