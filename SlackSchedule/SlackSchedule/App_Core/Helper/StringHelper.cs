using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlackSchedule.Helper
{
    public static class StringHelper
    {
        public static String Format2(this String str, params object[] args)
        {
            return String.Format(str, args);
        }
    }

}