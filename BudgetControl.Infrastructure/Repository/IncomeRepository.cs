using BudgetControl.Data.Context;
using BudgetControl.Domain.Entities;
using BudgetControl.Infrastructure.Interfaces;

namespace BudgetControl.Infrastructure.Repository;

public class IncomeRepository : IIncomeRepository
{
	private readonly BudgetControlDBContext _budgetControlDB;

	public IncomeRepository(BudgetControlDBContext budgetControlDBContext)
	{
		_budgetControlDB = budgetControlDBContext;
	}

	public Task<bool> CreateAsync(Income entity)
	{
		throw new NotImplementedException();
	}

	public Task<bool> DeleteAsync(Income entity)
	{
		throw new NotImplementedException();
	}

	public Task<List<Income>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task<Income?> GetByIdAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task<List<Income?>> GetByNameAsync(string name)
	{
		throw new NotImplementedException();
	}

	public Task<bool> Update(Income entity)
	{
		throw new NotImplementedException();
	}
}
