using BudgetControl.Data.Context;
using BudgetControl.Domain.Entities;
using BudgetControl.Application.Repository.Interfaces;

namespace BudgetControl.Application.Repository;

public class InvestmentRepository : IInvestmentRepository
{
	private readonly BudgetControlDBContext _budgetControlDB;

	public InvestmentRepository(BudgetControlDBContext budgetControlDBContext)
	{
		_budgetControlDB = budgetControlDBContext;
	}

	public Task<bool> CreateAsync(Investments entity)
	{
		throw new NotImplementedException();
	}

	public Task<bool> DeleteAsync(Investments entity)
	{
		throw new NotImplementedException();
	}

	public Task<List<Investments>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task<Investments?> GetByIdAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task<List<Investments?>> GetByNameAsync(string name)
	{
		throw new NotImplementedException();
	}

	public Task<bool> Update(Investments entity)
	{
		throw new NotImplementedException();
	}
}
