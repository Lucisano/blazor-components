using System;

namespace BlazorComponents.Extensions
{
    public static class GenericExtensions
    {
        public static bool IsDate(this object obj)
        {
            string strDate = obj.ToString();
            try
            {
                DateTime dt = DateTime.Parse(strDate);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static DateTime ToDate(this object obj)
        {
            try
            {
                string strDate = obj.ToString();
                return DateTime.Parse(strDate);
            }
            catch
            {
                return DateTime.Now;
            }
        }
    }
}
