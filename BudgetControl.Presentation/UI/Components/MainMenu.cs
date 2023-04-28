using Spectre.Console;

namespace BudgetControl.Presentation.UI.Components;

public class MainMenu
{
	public enum Selections
	{
		Summary,
		Expenses,
		Income,
		Investments,
		Categories,
		SubCategories
	};

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
					nameof(Selections.Summary),
					nameof(Selections.Expenses),
					nameof(Selections.Income),
					nameof(Selections.Investments),
					nameof(Selections.Categories),
					nameof(Selections.SubCategories)
				})
			);

		return selection;
	}

	public void CallSelectedMenu(string selection)
	{
		// validate if db exists
		// if not, first runs migration to create
		// if exists, checks balance
		// if no balance, asks to create a balance (or starts at 0)
		// this can be only done once, with a global flag or something

		// then we go for the real menu
		PickSelectedMenu(selection);
	}

	private void PickSelectedMenu(string selection)
	{
		switch (selection)
		{
			case nameof(Selections.Summary):
				Summary summary = new();
				summary.Render();
				break;
			case nameof(Selections.Expenses):
				break;
			case nameof(Selections.Income):
				break;
			case nameof(Selections.Categories):
				break;
			case nameof(Selections.SubCategories):
				break;
			default:
				break;
		}
	}
}
