using System.Net.Http.Json;
using Newtonsoft.Json;
using Phone_Book.Services;
using Shifts_Logger_UI.Models;
using Shifts_Logger_UI.Utils;
using Spectre.Console;

namespace Shifts_Logger_UI.Controllers;

public class ShiftsController
{
    internal static HttpClient _client = new() { BaseAddress = new Uri("http://localhost:5267") };

    internal async Task<List<Shift>> GetAllShiftsAsync(HttpClient client)
    {
        try
        {
            using var response = await client.GetAsync("/api/shift");

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var deserializedResponse = JsonConvert.DeserializeObject<List<Shift>>(jsonResponse);

            var shifts = deserializedResponse;

            return shifts;
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteLine(ex.Message);
            throw;
        }
    }

    internal static async Task CreateShiftAsync(HttpClient client)
    {
        try
        {
            var newShift = new Shift
            {
                EmployeeName = AnsiConsole.Ask<string>("Enter Employee Name: "),
                Position = AnsiConsole.Ask<string>("Enter Position: "),
                ShiftNumber = AnsiConsole.Ask<int>("Enter Shift Number: "),
                StartTime = AnsiConsole.Ask<DateTime>(
                    "Enter Shift Start Time (yyyy-MM-dd HH:mm): "
                ),
                EndTime = AnsiConsole.Ask<DateTime>("Enter Shift End Time (yyyy-MM-dd HH:mm): "),
            };

            using var response = await client.PostAsJsonAsync("/api/shift", newShift);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            JsonConvert.SerializeObject(jsonResponse);
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteLine(ex.Message);
            throw;
        }
    }

    internal static async Task UpdateShift(HttpClient client)
    {
        try
        {
            var shift = Helpers.ChooseShift();
            var id = shift.Id;

            using var response = await client.GetAsync($"/api/shift/{id}");

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}
