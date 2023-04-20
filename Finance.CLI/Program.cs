using Finance.Domain.Entities;
using Finance.Presentation.UI.Components;
using Spectre.Console;

MainMenu main = new MainMenu();

string selected = main.Login();

AnsiConsole.MarkupLine($"[green]{selected}[/] was selected!");