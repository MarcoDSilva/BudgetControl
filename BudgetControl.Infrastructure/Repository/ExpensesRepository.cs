using BudgetControl.Domain.Entities;
using BudgetControl.Infrastructure.Interfaces;

namespace BudgetControl.Infrastructure.Repository;
public class ExpensesRepository : IExpensesRepository
{
	public Task<Expenses> CreateAsync(Expenses entity)
	{
		throw new NotImplementedException();
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
