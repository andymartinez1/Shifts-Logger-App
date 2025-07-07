using System.Globalization;

namespace Shifts_Logger_UI.Utils;

public class Validator
{
    public static bool IsStartDateBeforeEndDate(string startDate, string endDate)
    {
        var start = DateTime.ParseExact(
            startDate,
            "yyyy-MM-dd HH:mm",
            CultureInfo.InvariantCulture
        );
        var end = DateTime.ParseExact(endDate, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

        return start <= end;
    }
}
