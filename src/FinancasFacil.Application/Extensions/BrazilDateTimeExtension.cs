namespace FinancasFacil.Application.Extensions;

public static class BrazilDateTimeExtension
{
    public static DateTime ToBrazilDateTime(this DateTime dateTime)
    {
        var brazilTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
        var brazilTime = TimeZoneInfo.ConvertTime(dateTime, brazilTimeZone);

        return brazilTime;
    }
}
