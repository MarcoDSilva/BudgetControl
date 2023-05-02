using BudgetControl.Data.Context;
using BudgetControl.Domain.Entities;
using BudgetControl.Infrastructure.Interfaces;

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

	public Task<Expenses> DeleteAsync(Expenses entity)
	{
		throw new NotImplementedException();
	}

	public Task<List<Expenses>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task<Expenses> GetByIdAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task<Expenses> GetByNameAsync(string name)
	{
		throw new NotImplementedException();
	}

	public Task<Expenses> UpdateAsync(Expenses entity)
	{
		throw new NotImplementedException();
	}
}
