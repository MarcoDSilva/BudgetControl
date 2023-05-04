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
				await AddExpense();
				break;
			case nameof(Options.Edit):
				break;
			case nameof(Options.Delete):
				break;
			case nameof(Options.View):
				await GetExpenses();
				break;
			default: throw new ArgumentException("");
		}
	}

	public async Task AddExpense()
	{
		var rule = new Rule("[yellow4_1]Expense to add[/]");
		rule.LeftJustified();
		AnsiConsole.Write(rule);

		var transactionDate = AnsiConsole.Ask<DateTime>("What was the [green]transaction date[/]? yyyy-mm-dd");
		var category = AnsiConsole.Ask<int>("What was the [mediumorchid]category[/]?");
		var subCategory = AnsiConsole.Ask<int>("What was the [grey63]subCategory[/]?");
		var value = AnsiConsole.Ask<decimal>("What was the moneraty [red]value[/]?");
		var description = AnsiConsole.Ask<string>("Do you want to add a description about this expense?");

		var expense = new ExpensesDTO();
		expense.TransactionDate = transactionDate;
		expense.CategoryId = category;
		expense.Description = description;
		expense.SubCategoryId = subCategory;
		expense.Value = value;

		bool wasAdded = await _expensesService.AddAsync(expense);

		if (wasAdded)
			AnsiConsole.WriteLine("sucessfully added");
		else
			AnsiConsole.Write("something super wrong happened");
	}

	public async Task GetExpenses()
	{
		var expenses = await _expensesService.GetExpenses();

		if (expenses?.Count > 0)
		{
			decimal sum = 0;

			var tableExpenses = new Table();
			tableExpenses.Border = TableBorder.SimpleHeavy;
			tableExpenses.Expand();

			tableExpenses.Title = new TableTitle("[yellow]Expenses[/]");

			tableExpenses.AddColumn(new TableColumn("Date"));
			tableExpenses.AddColumn(new TableColumn("Category").Centered());
			tableExpenses.AddColumn(new TableColumn("SubCategory").Centered());
			tableExpenses.AddColumn(new TableColumn("Value").Centered());
			tableExpenses.AddColumn(new TableColumn("Description").Centered());

			foreach (var expense in expenses)
			{
				sum += expense.Value;

				tableExpenses.AddRow(expense.TransactionDate.ToString(), expense.CategoryId.ToString(),
					expense.SubCategoryId.ToString(), expense.Value.ToString(), expense.Value.ToString());
			}

			tableExpenses.Caption = new TableTitle($"This transactions cost you [red]{sum}[/] euros");
			AnsiConsole.Write(tableExpenses);
		}
	}
}
