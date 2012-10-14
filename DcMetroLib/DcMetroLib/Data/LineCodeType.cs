using System;
using System.Collections.Generic;
using System.Linq;
using DcMetroLib.Common;

namespace DcMetroLib.Data
{
    public enum LineCodeType
    {
        Red,
        Blue,
        Yellow,
        Orange,
        Green,
        All,
        None
    }

    public static class LineCodeUtil
    {
        public static LineCodeType FromString(string s)
        {
            switch (s)
            {
                case "RD": return LineCodeType.Red;
                case "BL" : return LineCodeType.Blue;
                case "YL": return LineCodeType.Yellow;
                case "OR": return LineCodeType.Orange;
                case "GR": return LineCodeType.Green;
            }

            return LineCodeType.None;
        }

        public static List<LineCodeType> FromDelimitedString(string source, string delim)
        {
            return StringUtil.Split(source, ";").ToList().ConvertAll(FromString);
        }
    }

    public static class LineCodeExtensions
    {
        public static string ToCode(this LineCodeType lineCode)
        {
            switch(lineCode)
            {
                case LineCodeType.Red: return "RD";
                case LineCodeType.Blue: return "BL";
                case LineCodeType.Yellow: return "YL";
                case LineCodeType.Orange: return "OR";
                case LineCodeType.Green: return "GR";
            }
            return String.Empty;
        }
    }
}
