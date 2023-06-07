using BudgetControl.Application.DTO;
using BudgetControl.Application.Services.Interfaces;
using BudgetControl.Domain.Entities;
using BudgetControl.Presentation.Shared.Components;
using BudgetControl.Presentation.Shared.Enums;
using Spectre.Console;

namespace BudgetControl.Presentation.UI.Components;

public class IncomeMenu : DrawComponents
{
	private readonly IIncomeService _incomeService;

	public IncomeMenu(IIncomeService incomeService)
	{
		_incomeService = incomeService;
	}

	public async Task Selection(string menuName)
	{
		switch (menuName)
		{
			case nameof(Options.Add):
				await AddIncome();
				break;
			case nameof(Options.Edit):
				await EditIncome();
				break;
			case nameof(Options.Delete):
				await DeleteIncome();
				break;
			case nameof(Options.View):
				await GetIncomes();
				break;
			default: throw new ArgumentException("Option not available");
		}
	}

	public async Task AddIncome()
	{
		Question("Expense to add");

		var transactionDate = AnsiConsole.Ask<DateTime>("What was the [green]income date[/]? yyyy-mm-dd");
		var category = AnsiConsole.Ask<int>("What was the [mediumorchid]category[/]?");
		var subCategory = AnsiConsole.Ask<int>("What was the [grey63]subCategory[/]?");
		var value = AnsiConsole.Ask<decimal>("What was the monetary [red]value[/]?");
		var description = AnsiConsole.Ask<string>("Do you want to add a description about this expense?");

		var income = new IncomeDTO()
		{
			TransactionDate = transactionDate,
			CategoryId = category,
			Description = description,
			SubCategoryId = subCategory,
			Value = value
		};

		bool wasAdded = await _incomeService.AddAsync(income);

		AnsiConsole.WriteLine(wasAdded ? "sucessfully added" : "something super wrong happened");
	}

	public async Task GetIncomes()
	{
		var incomes = await _incomeService.GetAllAsync();

		if (incomes?.Count > 0)
		{
			decimal sum = 0;

			var tableIncomes = new Table();
			tableIncomes.Border = TableBorder.SimpleHeavy;
			tableIncomes.Expand();

			tableIncomes.Title = new TableTitle("[yellow]Expenses[/]");

			tableIncomes.AddColumn(new TableColumn("Date"));
			tableIncomes.AddColumn(new TableColumn("Category").Centered());
			tableIncomes.AddColumn(new TableColumn("SubCategory").Centered());
			tableIncomes.AddColumn(new TableColumn("Value").Centered());
			tableIncomes.AddColumn(new TableColumn("Description").Centered());

			incomes.ForEach(income =>
			{
				sum += income.Value;

				tableIncomes.AddRow(income.TransactionDate.ToString(), income.CategoryId.ToString(),
					income.SubCategoryId.ToString(), income.Value.ToString(), income.Value.ToString());
			});

			tableIncomes.Caption = new TableTitle($"This incomes got you a total of [green]{sum}[/] euros");
			AnsiConsole.Write(tableIncomes);
		}
	}

	public async Task DeleteIncome()
	{
		Question("Income to remove?");

		var incomeId = GetID("What is the ID of the income you want to remove?");
		var income = await _incomeService.GetByID(incomeId);

		if (income is null)
		{
			AnsiConsole.WriteLine("Income not found");
			return;
		}

		var result = await _incomeService.RemoveAsync(income);

		AnsiConsole.WriteLine(result ? "sucessfully removed" : "something super wrong happened");
	}

	public async Task EditIncome()
	{
		// get income id
		Question("Income to edit.");

		var incomeId = GetID("What is the ID of the expense you want to edit?");
		var income = await _incomeService.GetByID(incomeId);

		if (income is null)
		{
			AnsiConsole.WriteLine("Income was not found");
			return;
		}

		DrawIncome(income);

		var expenseToEdit = EditIncomeField(income);
		var wasEdited = await _incomeService.EditAsync(expenseToEdit);

		AnsiConsole.WriteLine(wasEdited ? "sucessfully edited" : "something super wrong happened");
	}

	private void DrawIncome(Income income)
	{
		var tableIncome = new Table();
		tableIncome.Border = TableBorder.SimpleHeavy;
		tableIncome.Expand();

		tableIncome.Title = new TableTitle("[yellow]Income[/]");

		tableIncome.AddColumn(new TableColumn("1 - Date"));
		tableIncome.AddColumn(new TableColumn("2 - Category").Centered());
		tableIncome.AddColumn(new TableColumn("3 - SubCategory").Centered());
		tableIncome.AddColumn(new TableColumn("4 - Value").Centered());
		tableIncome.AddColumn(new TableColumn("5 - Description").Centered());

		tableIncome.AddRow(income.TransactionDate.ToString(), income.CategoryId.ToString(),
					income.SubCategoryId.ToString(), income.Value.ToString(), income.Value.ToString());

		tableIncome.Caption = new TableTitle($"This is the income you want to edit.");
		AnsiConsole.Write(tableIncome);
	}

	private Income EditIncomeField(Income income)
	{
		var editedIncome = FieldToEdit();

		switch (editedIncome)
		{
			case 1:
				income.TransactionDate = AnsiConsole.Ask<DateTime>("What was the [green]transaction date[/]? yyyy-mm-dd");
				break;
			case 2:
				income.CategoryId = AnsiConsole.Ask<int>("What was the [mediumorchid]category[/]?");
				break;
			case 3:
				income.SubCategoryId = AnsiConsole.Ask<int>("What was the [grey63]subCategory[/]?");
				break;
			case 4:
				income.Value = AnsiConsole.Ask<decimal>("What was the monetary [red]value[/]?");
				break;
			case 5:
				income.Description = AnsiConsole.Ask<string>("Do you want to add a description about this income?");
				break;
			default:
				break;
		}

		return income;
	}

}
