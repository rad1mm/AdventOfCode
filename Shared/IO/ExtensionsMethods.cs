using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.IO
{
    public static class ExtensionsMethods
    {
        public static T ChangeType<T>(this object obj)
        {
            return (T)Convert.ChangeType(obj, typeof(T));
        }
    }
}
