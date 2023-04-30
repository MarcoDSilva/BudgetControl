using BudgetControl.Application.DTO;
using BudgetControl.Application.Services.Interfaces;
using BudgetControl.Presentation.Shared.Enums;
using Spectre.Console;

namespace BudgetControl.Presentation.UI.Components;

public class ExpensesMenu
{
	private readonly IExpensesService _expensesService;

	public ExpensesMenu(IExpensesService expenses)
	{
		_expensesService = expenses;
	}

	public async Task GetOptions()
	{
		var option = AnsiConsole.Prompt(
			new SelectionPrompt<string>()
				.Title("What do you want to do on the expenses menu?")
				.AddChoices(new[]
				{
					nameof(Options.Add),
					nameof(Options.Edit),
					nameof(Options.Delete),
					nameof(Options.View)
				})
			);

		await PickSelectedMenu(option);
	}

	public async Task PickSelectedMenu(string menuName)
	{
		switch (menuName)
		{
			case nameof(Options.Add):
				bool wasAdded = await AddExpense();
				break;
			case nameof(Options.Edit):
				break;
			case nameof(Options.Delete):
				break;
			case nameof(Options.View):
				break;
			default: throw new ArgumentException("");
		}
	}

	public async Task<bool> AddExpense()
	{
		var rule = new Rule("[yellow4_1]Expense to add[/]");
		rule.LeftJustified();
		AnsiConsole.Write(rule);

		var transactionDate = AnsiConsole.Ask<DateTime>("What was the [green]transaction date[/]? yyyy-mm-dd");
		var category = AnsiConsole.Ask<string>("What was the [mediumorchid]category[/]?");
		var subCategory = AnsiConsole.Ask<string>("What was the [grey63]subCategory[/]?");
		var value = AnsiConsole.Ask<decimal>("What was the moneraty [red]value[/]?");
		var description = AnsiConsole.Ask<string>("Do you want to add a description about this expense?");

		var expense = new ExpensesDTO();
		expense.TransactionDate = transactionDate;
		expense.Category = category;
		expense.Description = description;
		expense.SubCategory = subCategory;
		expense.Value = value;

		bool wasAdded = await _expensesService.AddAsync(expense);
		return wasAdded;
	}
}
