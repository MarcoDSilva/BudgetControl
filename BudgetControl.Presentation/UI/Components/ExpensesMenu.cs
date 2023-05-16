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

	public async Task Selection(string menuName)
	{
		switch (menuName)
		{
			case nameof(Options.Add):
				await AddExpense();
				break;
			case nameof(Options.Edit):
				await EditExpense();
				break;
			case nameof(Options.Delete):
				await DeleteExpense();
				break;
			case nameof(Options.View):
				await GetExpenses();
				break;
			default: throw new ArgumentException("Option not available");
		}
	}

	public async Task AddExpense()
	{
		Question("Expense to add");

		var transactionDate = AnsiConsole.Ask<DateTime>("What was the [green]transaction date[/]? yyyy-mm-dd");
		var category = AnsiConsole.Ask<int>("What was the [mediumorchid]category[/]?");
		var subCategory = AnsiConsole.Ask<int>("What was the [grey63]subCategory[/]?");
		var value = AnsiConsole.Ask<decimal>("What was the monetary [red]value[/]?");
		var description = AnsiConsole.Ask<string>("Do you want to add a description about this expense?");

		var expense = new ExpensesDTO()
		{
			TransactionDate = transactionDate,
			CategoryId = category,
			Description = description,
			SubCategoryId = subCategory,
			Value = value
		};

		bool wasAdded = await _expensesService.AddAsync(expense);

		AnsiConsole.WriteLine(wasAdded ? "sucessfully added" : "something super wrong happened");
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

			expenses.ForEach(expense =>
			{
				sum += expense.Value;

				tableExpenses.AddRow(expense.TransactionDate.ToString(), expense.CategoryId.ToString(),
					expense.SubCategoryId.ToString(), expense.Value.ToString(), expense.Value.ToString());
			});

			tableExpenses.Caption = new TableTitle($"This transactions cost you [red]{sum}[/] euros");
			AnsiConsole.Write(tableExpenses);
		}
	}

	public async Task DeleteExpense()
	{
		Question("Expense to remove?");

		var expenseId = GetID("What is the ID of the expense you want to remove?");
		var expense = await _expensesService.GetExpenseByID(expenseId);

		if (expense is null)
		{
			AnsiConsole.WriteLine("Expense not found");
			return;
		}

		var result = await _expensesService.RemoveAsync(expense);

		AnsiConsole.WriteLine(result ? "sucessfully removed" : "something super wrong happened");
	}

	public async Task EditExpense()
	{
		// get expense id
		Question("Expense to edit.");

		var expenseId = GetID("What is the ID of the expense you want to edit?");
		var expense = _expensesService.GetExpenseByID(expenseId);

		if (expense is null)
		{
			AnsiConsole.WriteLine("expense was not found");
			return;
		}

		// what do you want to edit
		// get field
		// edit that field
		// send to db
		// update/fail
		// sucess or fail message
	}

	private void Question(string message)
	{
		var rule = new Rule($"[yellow4_1]{message}[/]");
		rule.LeftJustified();
		AnsiConsole.Write(rule);
	}

	private int GetID(string message)
	{
		var expenseId = AnsiConsole.Prompt<int>(
							new TextPrompt<int>(message)
							.PromptStyle("red")
							.ValidationErrorMessage("[red]That's not a valid ID[/]")
							.Validate(id =>
							{
								return id switch
								{
									<= 0 => ValidationResult.Error("[red]Id can't be equal or under to 0![/]"),
									_ => ValidationResult.Success(),
								};
							}));

		return expenseId;
	}
}
