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
                if ((dt.Month != System.DateTime.Now.Month) || (dt.Day < 1 && dt.Day > 31) || dt.Year != System.DateTime.Now.Year)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public static DateTime ToDate(this object obj)
        {
            if (obj.IsDate())
            {
                string strDate = obj.ToString();
                try
                {
                    DateTime dt = DateTime.Parse(strDate);
                }
                catch
                {
                }
            }
            return DateTime.Now;
        }
    }
}
