using BudgetControl.Application.Repository;
using BudgetControl.Application.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetControl.Infrastructure;

public static class RepositoryRegistration
{
	public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
	{
		services
			.AddScoped<ICategoryRepository, CategoryRepository>()
			.AddScoped<ISubCategoryRepository, SubCategoryRepository>()
			.AddScoped<IExpensesRepository, ExpensesRepository>()
			.AddScoped<IIncomeRepository, IncomeRepository>()
			.AddScoped<IInvestmentRepository, InvestmentRepository>()
			.AddScoped<IUnitOfWork, UnitOfwork>();

		return services;
	}
}
