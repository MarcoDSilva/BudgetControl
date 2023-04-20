using Spectre.Console;

namespace Finance.Presentation.UI.Components;

public class MainMenu
{
	public MainMenu()
	{
	}

	public string Login()
	{
		string selection = AnsiConsole.Prompt(
				new SelectionPrompt<string>()
				.Title("Welcome To BudgetControl!")
				.PageSize(6)
				.AddChoices(new[]
				{
					"Check Overall", "Expenses", "Income", "Investments", "Categories", "SubCategories"
				})
			);

		return selection;
	}
}
