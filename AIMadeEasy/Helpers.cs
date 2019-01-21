using System;
using System.Collections.Generic;
using System.Text;

namespace CognitiveServices
{
    public static class Helpers
    {
        public static string AddParameter(string name, string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";
            else
                return "&" + name + "=" + value;
        }
        public static string AddParameter(string name, int? value)
        {
            if (value == null)
                return "";
            else
                return "&" + name + "=" + value.ToString();
        }
        public static string AddParameter(string name, bool value)
        {
            return "&" + name + "=" + value.ToString();
        }
    }
}
