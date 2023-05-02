using BudgetControl.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetControl.Data;

public static class DatabaseRegistration
{
	public static IServiceCollection AddDBService(this IServiceCollection services)
	{
		services.AddDbContext<BudgetControlDBContext>(options =>
		{
			options.UseSqlite("Data Source=D:\\Coding\\Finance_Apps\\Database\\BudgetControl.db");
		});

		return services;
	}
}
