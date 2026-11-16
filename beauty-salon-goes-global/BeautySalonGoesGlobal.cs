using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();
    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        return TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse(appointmentDateDescription), TimeZoneInfo.FindSystemTimeZoneById(timeZoneId(location)));
    }

    private static String timeZoneId(Location location)
    {
        String timeZoneId;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {

            timeZoneId = location switch
            {
                Location.NewYork => "Eastern Standard Time",
                Location.London => "GMT Standard Time",
                Location.Paris => "W. Europe Standard Time",
                _ => throw new ArgumentException("Unknown location", nameof(location))
            };

        }
        else
        {
            timeZoneId = location switch
            {
                Location.NewYork => "America/New_York",
                Location.London => "Europe/London",
                Location.Paris => "Europe/Paris",
                _ => throw new ArgumentException("Unknown location", nameof(location))
            };

        }
        return timeZoneId;
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        DateTime alertTime = alertLevel switch
        {
            AlertLevel.Early => appointment - TimeSpan.FromDays(1),
            AlertLevel.Standard => appointment - TimeSpan.FromMinutes(105),
            AlertLevel.Late => appointment - TimeSpan.FromMinutes(30),
            _ => throw new ArgumentException("Unknown alertLevel", nameof(alertLevel))
        };
        return alertTime;
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId(location));
        return (timeZoneInfo.IsDaylightSavingTime(dt) != timeZoneInfo.IsDaylightSavingTime(dt -  TimeSpan.FromDays(7)));
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        CultureInfo cultureInfo = location switch
        {
            Location.NewYork => new CultureInfo("en-US"),
            Location.London => new CultureInfo("en-GB"),
            Location.Paris => new CultureInfo("fr-FR"),
            _ => throw new ArgumentException("Unknown location", nameof(location))
        };
        return DateTime.TryParse(dtStr, cultureInfo, out DateTime dt) ? dt : DateTime.MinValue;
    }
}
