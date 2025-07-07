using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Shifts_Logger_UI.Models;

public class Shift
{
    [Key]
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("employeeName")]
    public string EmployeeName { get; set; }

    [JsonProperty("position")]
    public string Position { get; set; }

    [JsonProperty("shiftNumber")]
    public int ShiftNumber { get; set; }

    [JsonProperty("startTime")]
    public DateTime StartTime { get; set; }

    [JsonProperty("endTime")]
    public DateTime EndTime { get; set; }

    [JsonProperty("duration")]
    public TimeSpan Duration => EndTime - StartTime;
}
