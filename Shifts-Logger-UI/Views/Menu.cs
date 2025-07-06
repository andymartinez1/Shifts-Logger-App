using Phone_Book.Services;
using Shifts_Logger_UI.Enums;
using Spectre.Console;

namespace Shifts_Logger_UI.Views;

public class Menu
{
    private readonly Enums.Enums.MenuOptions[] _menuOptions =
    [
        Enums.Enums.MenuOptions.ViewAllShifts,
        Enums.Enums.MenuOptions.ViewShiftById,
        Enums.Enums.MenuOptions.CreateShift,
        Enums.Enums.MenuOptions.UpdateShift,
        Enums.Enums.MenuOptions.DeleteShift,
        Enums.Enums.MenuOptions.Exit,
    ];

    internal void MainMenu()
    {
        var isMenuRunning = true;

        while (isMenuRunning)
        {
            var userChoice = AnsiConsole.Prompt(
                new SelectionPrompt<Enums.Enums.MenuOptions>()
                    .Title("Select an option:")
                    .PageSize(10)
                    .AddChoices(_menuOptions)
                    .UseConverter(c => c.GetDisplayName())
            );

            switch (userChoice)
            {
                case Enums.Enums.MenuOptions.ViewAllShifts:
                    AnsiConsole.Clear();
                    break;
                case Enums.Enums.MenuOptions.ViewShiftById:
                    AnsiConsole.Clear();
                    break;
                case Enums.Enums.MenuOptions.CreateShift:
                    AnsiConsole.Clear();
                    break;
                case Enums.Enums.MenuOptions.UpdateShift:
                    AnsiConsole.Clear();
                    break;
                case Enums.Enums.MenuOptions.DeleteShift:
                    AnsiConsole.Clear();
                    break;
                case Enums.Enums.MenuOptions.Exit:
                    AnsiConsole.MarkupLine(
                        "[red]Thank you for using Shifts Logger! Press any key to exit.[/]"
                    );
                    Console.ReadKey();
                    isMenuRunning = false;
                    break;
            }
        }
    }
}
