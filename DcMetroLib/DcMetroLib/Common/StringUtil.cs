using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DcMetroLib.Common
{
    public static class StringUtil
    {
        public static string[] Split(string value, string separator)
        {
            return value.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
