using BudgetControl.Domain.Common;
using BudgetControl.Domain.Domain.Entities;
using BudgetControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetControl.Data.Context;

public class BudgetControlDBContext : DbContext
{
	public BudgetControlDBContext(DbContextOptions<BudgetControlDBContext> options) : base(options)
	{

	}

	public DbSet<Category> Categories { get; set; }
	public DbSet<Expenses> Expenses { get; set; }
	public DbSet<Income> Incomes { get; set; }
	public DbSet<Investments> Investments { get; set; }
	public DbSet<SubCategory> SubCategories { get; set; }
	public DbSet<Balance> Balances { get; set; }

}
