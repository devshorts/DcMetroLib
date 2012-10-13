using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DcMetroLib.Data
{
    public enum LineCodeType
    {
        Red,
        Blue,
        Yellow,
        Orange,
        Green,
        All
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
