using BudgetControl.Application.Services.Interfaces;
using BudgetControl.Application.Services.Logic;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetControl.Application;

public static class ServicesRegistration
{
	// Adding the DI dependencies to the services collection
	public static IServiceCollection AddServicesDI(this IServiceCollection services)
	{
		services.AddTransient<IExpensesService, ExpensesService>();

		return services;
	}
}
