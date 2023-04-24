using BudgetControl.Domain.Entities;
using BudgetControl.Infrastructure.Interfaces;

namespace BudgetControl.Infrastructure.Repository;

public class InvestmentRepository : IInvestmentRepository
{
	public Task<Investments> CreateAsync(Investments entity)
	{
		throw new NotImplementedException();
	}

	public Task<Investments> DeleteAsync(Investments entity)
	{
		throw new NotImplementedException();
	}

	public Task<List<Investments>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task<Investments> GetByIdAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task<Investments> GetByNameAsync(string name)
	{
		throw new NotImplementedException();
	}

	public Task<Investments> UpdateAsync(Investments entity)
	{
		throw new NotImplementedException();
	}
}
