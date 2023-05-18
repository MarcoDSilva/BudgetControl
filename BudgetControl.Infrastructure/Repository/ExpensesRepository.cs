using BudgetControl.Data.Context;
using BudgetControl.Domain.Entities;
using BudgetControl.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BudgetControl.Infrastructure.Repository;
public class ExpensesRepository : IExpensesRepository
{
	private readonly BudgetControlDBContext _budgetControlDB;

    public ExpensesRepository(BudgetControlDBContext budgetControlDBContext)
    {
        _budgetControlDB = budgetControlDBContext;
    }

    public async Task<bool> CreateAsync(Expenses entity)
	{
		var inserted = await _budgetControlDB.Expenses.AddAsync(entity);
		var save = await _budgetControlDB.SaveChangesAsync();

		return save > 0;
	}

	public async Task<bool> DeleteAsync(Expenses entity)
	{
		var deleted = _budgetControlDB.Expenses.Remove(entity);
		var save = await _budgetControlDB.SaveChangesAsync();

		return save > 0;
	}

	public async Task<List<Expenses>> GetAllAsync()
	{
		var expenses = await _budgetControlDB.Expenses.ToListAsync();
		return expenses;
	}

	public async Task<Expenses?> GetByIdAsync(int id)
	{
		var expenses = await _budgetControlDB.Expenses.ToListAsync();
		var expense = expenses.Where(ex => ex.Id == id).FirstOrDefault();

		return expense;
	}

	public async Task<List<Expenses?>> GetByNameAsync(string name)
	{
		var expenses = await _budgetControlDB.Expenses.ToListAsync();
		var expense = expenses.Where(exp => exp.Description.Equals(name)).ToList();

		return expense;
	}

	public async Task<bool> Update(Expenses entity)
	{
		_budgetControlDB.Expenses.Update(entity);
		var wasSaved = await _budgetControlDB.SaveChangesAsync();

		return wasSaved > 0;
	}
}
