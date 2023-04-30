using BudgetControl.Presentation.UI.Components;
using Spectre.Console;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BudgetControl.Application;
using BudgetControl.Application.Services.Interfaces;
using BudgetControl.Application.Services.Logic;
using BudgetControl.Infrastructure;

internal class Program
{
	private static async Task Main(string[] args)
	{
		// to setup configurations like appsettings and so on
		var config = new ConfigurationBuilder();


		// to setup DI
		var services = new ServiceCollection();
		services.AddServicesDI();
		services.AddInfrastructureDI();

		services.AddAutoMapper(typeof(Program).Assembly);

		// building services
		var s = services.BuildServiceProvider();

		// getting services for DI to presentation
		var expenseService = s.GetRequiredService<IExpensesService>();

		// running the program
		var main = new MainMenu(expenseService);

		string selected = main.StartSelection();
		await main.CallSelectedMenu(selected);
	}
}