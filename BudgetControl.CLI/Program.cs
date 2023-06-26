using BudgetControl.Presentation.UI.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BudgetControl.Application;
using BudgetControl.Application.Services.Interfaces;
using BudgetControl.Infrastructure;
using BudgetControl.Data;
using Microsoft.Extensions.Hosting;
using AutoMapper;

internal class Program
{
	private static async Task Main(string[] args)
	{
		// to setup configurations like appsettings and so on
		var config = new ConfigurationBuilder();
		IMapper mapper = MapperRegistration.RegisteringMapper().CreateMapper();

		var host = Host.CreateDefaultBuilder()
						.ConfigureServices((context, services) =>
						{
							services.AddServicesDI();
							services.AddInfrastructureDI();
							services.AddSingleton(mapper);
							services.AddDBService();
						}).Build();

		// getting services for DI to presentation
		var expenseService = host.Services.GetRequiredService<IExpensesService>();
		var incomeService = host.Services.GetRequiredService<IIncomeService>();
		var categoryService = host.Services.GetRequiredService<ICategoryService>();
		var subCategoryService = host.Services.GetRequiredService<ISubCategoryService>();

		// running the program
		var main = new MainMenu(
				expenseService, incomeService, categoryService, subCategoryService);

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