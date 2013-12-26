using System;

namespace WindowsSDK
{
    public partial class SlidePayWindowsSDK
    {
        private double get_total_ms(DateTime start_time)
        {
            try
            {
                DateTime end_time = DateTime.Now;
                TimeSpan total_time = (end_time - start_time);
                return total_time.TotalMilliseconds;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
