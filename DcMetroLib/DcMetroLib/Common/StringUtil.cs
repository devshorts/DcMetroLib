using System;

namespace DcMetroLib.Common
{
    internal static class StringUtil
    {
        public static string[] Split(string value, string separator)
        {
            if(value == null)
            {
                return null;
            }

            return value.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
