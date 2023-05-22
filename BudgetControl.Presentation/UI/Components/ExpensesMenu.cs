using BudgetControl.Application.DTO;
using BudgetControl.Application.Services.Interfaces;
using BudgetControl.Domain.Entities;
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
		var expenses = await _expensesService.GetAllAsync();

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
		var expense = await _expensesService.GetByID(expenseId);

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
		var expense = await _expensesService.GetByID(expenseId);

		if (expense is null)
		{
			AnsiConsole.WriteLine("expense was not found");
			return;
		}

		DrawExpense(expense);

		var expenseToEdit = EditExpenseField(expense);
		var wasEdited = await _expensesService.EditAsync(expenseToEdit);

		AnsiConsole.WriteLine(wasEdited ? "sucessfully edited" : "something super wrong happened");
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

	private void DrawExpense(Expenses expense)
	{
		var tableExpenses = new Table();
		tableExpenses.Border = TableBorder.SimpleHeavy;
		tableExpenses.Expand();

		tableExpenses.Title = new TableTitle("[yellow]Expenses[/]");

		tableExpenses.AddColumn(new TableColumn("1 - Date"));
		tableExpenses.AddColumn(new TableColumn("2 - Category").Centered());
		tableExpenses.AddColumn(new TableColumn("3 - SubCategory").Centered());
		tableExpenses.AddColumn(new TableColumn("4 - Value").Centered());
		tableExpenses.AddColumn(new TableColumn("5 - Description").Centered());

		tableExpenses.AddRow(expense.TransactionDate.ToString(), expense.CategoryId.ToString(),
					expense.SubCategoryId.ToString(), expense.Value.ToString(), expense.Value.ToString());

		tableExpenses.Caption = new TableTitle($"This is the expense you want to edit.");
		AnsiConsole.Write(tableExpenses);
	}

	private Expenses EditExpenseField(Expenses expense)
	{
		var editedExpense = AnsiConsole.Prompt<int>(
								new TextPrompt<int>("What field you want to edit? Pick the number from the field.")
								.Validate(id =>
								{
									return id switch
									{
										<= 0 => ValidationResult.Error("[red]Id can't be equal or under to 0![/]"),
										_ => ValidationResult.Success(),
									};
								}));

		switch (editedExpense)
		{
			case 1:
				expense.TransactionDate = AnsiConsole.Ask<DateTime>("What was the [green]transaction date[/]? yyyy-mm-dd");
				break;
			case 2:
				expense.CategoryId = AnsiConsole.Ask<int>("What was the [mediumorchid]category[/]?");
				break;
			case 3:
				expense.SubCategoryId = AnsiConsole.Ask<int>("What was the [grey63]subCategory[/]?");
				break;
			case 4:
				expense.Value = AnsiConsole.Ask<decimal>("What was the monetary [red]value[/]?");
				break;
			case 5:
				expense.Description = AnsiConsole.Ask<string>("Do you want to add a description about this expense?");
				break;
			default:
				break;
		}

		return expense;
	}
}
