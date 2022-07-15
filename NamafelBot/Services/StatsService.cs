using System.Diagnostics;
using System.Globalization;

namespace NamafelBot.Services
{
    public class StatsService
    {
        private readonly DateTime _startTime = DateTime.Now;
        private readonly Stopwatch _uptime = Stopwatch.StartNew();

        public string Uptime => string.Format("{0} {1} {2} {3}",
            GetTimeUnit(_uptime.Elapsed.Days, "day"),
            GetTimeUnit(_uptime.Elapsed.Hours, "hour"),
            GetTimeUnit(_uptime.Elapsed.Minutes, "minute"),
            GetTimeUnit(_uptime.Elapsed.Seconds, "second"));
        public string StartDate => _startTime.ToString("ddd dd/MM/yyyy HH:mm:ss z", CultureInfo.GetCultureInfo("en-GB"));

        private static string GetTimeUnit(int value, string message)
        {
            // Don't show unit
            if (value == 0)
            {
                return "";
            }

            // Pluralise
            if (value > 1)
            {
                message += "s";
            }

            return $"{value} {message}";
        }
    }
}
