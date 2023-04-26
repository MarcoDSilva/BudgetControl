using BudgetControl.Domain.Common;
using BudgetControl.Domain.Domain.Entities;
using BudgetControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetControl.Data.Context;

public class BudgetControlDBContext : DbContext
{
	public string dbPath { get;  }

    public BudgetControlDBContext()
    {
		//var folder = Environment.SpecialFolder.LocalApplicationData;
		//var path = Environment.GetFolderPath(folder);
		dbPath = Path.Join("BudgetControl.db");
    }

	// The following configures EF to create a Sqlite database file in the
	// special "local" folder for your platform.
	protected override void OnConfiguring(DbContextOptionsBuilder options)
		=> options.UseSqlite($"Data Source={dbPath}");

	//public BudgetControlDBContext(DbContextOptions<BudgetControlDBContext> options) : base(options)
	//{

	//}

	public DbSet<Category> Categories { get; set; }
	public DbSet<Expenses> Expenses { get; set; }
	public DbSet<Income> Incomes { get; set; }
	public DbSet<Investments> Investments { get; set; }
	public DbSet<SubCategory> SubCategories { get; set; }
	public DbSet<Balance> Balances { get; set; }

}
