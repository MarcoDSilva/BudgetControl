using BudgetControl.Infrastructure.Interfaces;
using BudgetControl.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetControl.Infrastructure;

public static class InfrastructureService
{
	public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
	{
		services.AddScoped<ICategoryRepository, CategoryRepository>();
		services.AddScoped<IExpensesRepository, ExpensesRepository>();
		services.AddScoped<IIncomeRepository, IncomeRepository>();
		services.AddScoped<IInvestmentRepository, InvestmentRepository>();
		services.AddScoped<IUnitOfWork, UnitOfwork>();
		//services.AddScoped<IValidations, Validations>();

		return services;
	}
}
