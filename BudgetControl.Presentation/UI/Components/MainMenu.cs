using Spectre.Console;
using System.Reflection.Metadata.Ecma335;

namespace BudgetControl.Presentation.UI.Components;

public class MainMenu
{
	public MainMenu()
	{
	}

	public string StartSelection()
	{
		string selection = AnsiConsole.Prompt(
				new SelectionPrompt<string>()
				.Title("Welcome To BudgetControl!")
				.PageSize(6)
				.AddChoices(new[]
				{
					"Account Resume", "Expenses", "Income", "Investments", "Categories", "SubCategories"
				})
			);

		return selection;
	}

	public void CallSelectedMenu(string selection)
	{
		PickSelectedMenu(selection);
	}

	private void PickSelectedMenu(string selection)
	{

	}
}
