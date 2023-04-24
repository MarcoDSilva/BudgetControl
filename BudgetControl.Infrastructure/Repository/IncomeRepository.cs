using BudgetControl.Domain.Entities;
using BudgetControl.Infrastructure.Interfaces;

namespace BudgetControl.Infrastructure.Repository;

public class IncomeRepository : IIncomeRepository
{
	public Task<Income> CreateAsync(Income entity)
	{
		throw new NotImplementedException();
	}

	public Task<Income> DeleteAsync(Income entity)
	{
		throw new NotImplementedException();
	}

	public Task<List<Income>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task<Income> GetByIdAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task<Income> GetByNameAsync(string name)
	{
		throw new NotImplementedException();
	}

	public Task<Income> UpdateAsync(Income entity)
	{
		throw new NotImplementedException();
	}
}
