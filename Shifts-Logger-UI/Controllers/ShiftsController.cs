using Newtonsoft.Json;
using Shifts_Logger_UI.Models;
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
}
