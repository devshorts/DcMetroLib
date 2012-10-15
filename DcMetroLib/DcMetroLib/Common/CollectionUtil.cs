using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DcMetroLib.Common
{
    internal static class CollectionUtil
    {
        public static Boolean IsNullOrEmpty(IList collection)
        {
            return collection == null || collection.Count == 0;
        }
    }
}
