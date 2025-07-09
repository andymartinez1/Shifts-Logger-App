using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Shifts_Logger_UI.Controllers;
using Shifts_Logger_UI.Models;
using Shifts_Logger_UI.Views;
using Spectre.Console;

namespace Shifts_Logger_UI.Services;

public static class Helpers
{
    private static readonly ShiftsController Controller = new();
    private static readonly UserInterface Ui = new();

    public static string GetDisplayName(this Enum enumValue)
    {
        return enumValue
            .GetType()
            .GetMember(enumValue.ToString())
            .First()
            ?.GetCustomAttribute<DisplayAttribute>()
            ?.Name;
    }

    internal static async Task<Shift> ChooseShift()
    {
        await Ui.ViewAllShifts();

        var shifts = await Controller.GetAllShiftsAsync(Controller.Client);

        var shiftArray = shifts.Select(s => s.Id).ToArray();

        var userChoice = AnsiConsole.Prompt(
            new SelectionPrompt<int>()
                .Title("Select an employee to view shift details:")
                .AddChoices(shiftArray)
        );

        var selectedShift = shifts.FirstOrDefault(s => s.Id == userChoice);

        return selectedShift;
    }
}
