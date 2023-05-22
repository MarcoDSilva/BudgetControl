using BudgetControl.Presentation.UI.Components;
using Spectre.Console;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BudgetControl.Application;
using BudgetControl.Application.Services.Interfaces;
using BudgetControl.Application.Services.Logic;
using BudgetControl.Infrastructure;
using BudgetControl.Data.Context;
using BudgetControl.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

internal class Program
{
	private static async Task Main(string[] args)
	{
		// to setup configurations like appsettings and so on
		var config = new ConfigurationBuilder();

		var host = Host.CreateDefaultBuilder()
						.ConfigureServices((context, services) =>
						{
							services.AddServicesDI();
							services.AddInfrastructureDI();
							services.AddAutoMapper(typeof(Program).Assembly);
							services.AddDBService();
						}).Build();

		// getting services for DI to presentation
		var expenseService = host.Services.GetRequiredService<IExpensesService>();
		var incomeService = host.Services.GetRequiredService<IIncomeService>();

		// running the program
		var main = new MainMenu(expenseService, incomeService);

		bool wasOrderedToClose = false;

		do
		{
			string selected = main.StartSelection();
			await main.CallSelectedMenu(selected);
			wasOrderedToClose = main.wasShuttedDown;
		}
		while (!wasOrderedToClose);
	}
}