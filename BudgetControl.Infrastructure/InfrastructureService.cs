﻿using BudgetControl.Infrastructure.Interfaces;
using BudgetControl.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetControl.Infrastructure;

public static class InfrastructureService
{
	public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
	{
		services
			.AddScoped<ICategoryRepository, CategoryRepository>()
			.AddScoped<IExpensesRepository, ExpensesRepository>()
			.AddScoped<IIncomeRepository, IncomeRepository>()
			.AddScoped<IInvestmentRepository, InvestmentRepository>()
			.AddScoped<IUnitOfWork, UnitOfwork>();

		return services;
	}
}