using Spectre.Console;
using System.Net.NetworkInformation;

namespace BudgetControl.Presentation.UI.Components;

public class Summary
{
	public void Render()
	{
		var tableExpenses = DrawExpensesTable();
				
		AnsiConsole.Write(tableExpenses);


		//var incomeCol = table.AddColumn(new TableColumn("Income").Centered());
		//var investmentCol = table.AddColumn(new TableColumn("Investment").Centered());



		//incomeCol.AddColumn(new TableColumn("Description").Centered());
		//incomeCol.AddColumn(new TableColumn("Value").Centered());
		//incomeCol.AddColumn(new TableColumn("Transaction Date"));
		//incomeCol.AddColumn(new TableColumn("Category").Centered());
		//incomeCol.AddColumn(new TableColumn("SubCategory").Centered());


		//investmentCol.AddColumn(new TableColumn("Description").Centered());
		//investmentCol.AddColumn(new TableColumn("Value").Centered());
		//investmentCol.AddColumn(new TableColumn("Transaction Date"));
		//investmentCol.AddColumn(new TableColumn("Category").Centered());
		//investmentCol.AddColumn(new TableColumn("SubCategory").Centered());
	}

	private Table DrawExpensesTable()
	{
		var tableExpenses = new Table();
		tableExpenses.Border = TableBorder.SimpleHeavy;
		tableExpenses.Expand();

		tableExpenses.Title = new TableTitle("[yellow]Expenses[/]");

		tableExpenses.AddColumn(new TableColumn("Date"));
		tableExpenses.AddColumn(new TableColumn("Category").Centered());
		tableExpenses.AddColumn(new TableColumn("SubCategory").Centered());
		tableExpenses.AddColumn(new TableColumn("Value").Centered());
		tableExpenses.AddColumn(new TableColumn("Description").Centered());

		// GetExpensesData
		tableExpenses.AddRow("2023-04-28", "Daily Expenses", "Groceries", "15", "meat");
		tableExpenses.AddRow("2023-04-25", "Bills", "Gas", "17", "");
		tableExpenses.AddRow("2023-04-23", "Bills", "Electricity", "22", "");
		tableExpenses.AddRow("2023-04-21", "House", "Rent", "500", "");
		tableExpenses.AddRow("2023-04-20", "IT", "Hardware", "120", "new lcd monitor");
		tableExpenses.Caption = new TableTitle("This transactions cost you [red]674[/] euros");

		return tableExpenses;
	}
}