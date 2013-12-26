using System;

namespace WindowsSDK
{
    public partial class SlidePayWindowsSDK
    {
        private bool string_null_or_empty(string str)
        {
            try
            {
                if (str == null) return true;
                if (String.Compare(str, null) == 0) return true;
                if (String.Compare(str, "") == 0) return true;
                if (String.Compare(str, String.Empty) == 0) return true;
                if (str.Length < 1) return true;
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}