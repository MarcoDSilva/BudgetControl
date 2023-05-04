using BudgetControl.Application.Services.Interfaces;
using BudgetControl.Application.Services.Logic;
using Spectre.Console;

namespace BudgetControl.Presentation.UI.Components;

public class MainMenu
{
	private readonly IExpensesService _expensesService;
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

	public MainMenu(IExpensesService expensesService)
	{
		_expensesService = expensesService;
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

	public async Task CallSelectedMenu(string selection)
	{
		// validate if db exists
		// if not, first runs migration to create
		// if exists, checks balance
		// if no balance, asks to create a balance (or starts at 0)
		// this can be only done once, with a global flag or something

		// then we go for the real menu
		await PickSelectedMenu(selection);
	}

	private async Task PickSelectedMenu(string selection)
	{
		switch (selection)
		{
			case nameof(Selections.Summary):
				Summary summary = new();
				summary.Render();
				break;
			case nameof(Selections.Expenses):
				var expenses = new ExpensesMenu(_expensesService);
				await expenses.GetOptions();
				break;
			case nameof(Selections.Income):
				//var income = new IncomeMenu(_incomeService);
				//await income.GetOptions();
				break;
			case nameof(Selections.Categories):
				//var category = new CategoriesMenu(_categoryService);
				//await category.GetOptions();
				break;
			case nameof(Selections.SubCategories):
				//var subCategory = new SubCategoriesMenu(_subCategoryService);
				//await subCategory.GetOptions();
				break;
			default:
				throw new ArgumentException("");
		}
	}
}
