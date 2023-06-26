using BudgetControl.Application.Services.Interfaces;
using BudgetControl.Application.Services.Logic;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetControl.Application;

public static class ServicesRegistration
{
	// Adding the DI dependencies to the services collection
	public static IServiceCollection AddServicesDI(this IServiceCollection services)
	{
		services.AddScoped<IExpensesService, ExpensesService>();
		services.AddScoped<ICategoryService, CategoryService>();
		services.AddScoped<ISubCategoryService, SubCategoryService>();
		services.AddScoped<IIncomeService, IncomeService>();
		services.AddScoped<IInvestmentService, InvestmentService>();

		return services;
	}
}
