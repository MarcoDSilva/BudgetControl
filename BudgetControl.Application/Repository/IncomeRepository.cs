using BudgetControl.Data.Context;
using BudgetControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using BudgetControl.Application.Repository.Interfaces;

namespace BudgetControl.Application.Repository;

public class IncomeRepository : IIncomeRepository
{
	private readonly BudgetControlDBContext _budgetControlDB;

	public IncomeRepository(BudgetControlDBContext budgetControlDBContext)
	{
		_budgetControlDB = budgetControlDBContext;
	}

	public async Task<bool> CreateAsync(Income entity)
	{
		var inserted = await _budgetControlDB.Incomes.AddAsync(entity);
		var save = await _budgetControlDB.SaveChangesAsync();

		return save > 0;
	}

	public async Task<bool> DeleteAsync(Income entity)
	{
		var deleted = _budgetControlDB.Incomes.Remove(entity);
		var save = await _budgetControlDB.SaveChangesAsync();

		return save > 0;
	}

	public async Task<List<Income>> GetAllAsync()
	{
		var incomes = await _budgetControlDB.Incomes.ToListAsync();
		return incomes;
	}

	public async Task<Income?> GetByIdAsync(int id)
	{
		var incomes = await _budgetControlDB.Incomes.ToListAsync();
		var income = incomes.Where(inc => inc.Id == id).FirstOrDefault();

		return income;
	}

	public async Task<List<Income?>> GetByNameAsync(string name)
	{
		var incomes = await _budgetControlDB.Incomes.ToListAsync();
		var income = incomes.Where(inc => inc.Description.ToLower()
											.Equals(name?.ToLower())
									).ToList();

		return income;
	}

	public async Task<bool> Update(Income entity)
	{
		_budgetControlDB.Incomes.Update(entity);
		var wasSaved = await _budgetControlDB.SaveChangesAsync();

		return wasSaved > 0;
	}
}
