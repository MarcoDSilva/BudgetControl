using BudgetControl.Data.Context;
using BudgetControl.Domain.Entities;
using BudgetControl.Domain.Interfaces;
using BudgetControl.Infrastructure.Interfaces;
using System.Runtime.CompilerServices;

namespace BudgetControl.Infrastructure.Repository;
public class CategoryRepository : ICategoryRepository
{
	private readonly BudgetControlDBContext _budgetControlDB;

	public CategoryRepository(BudgetControlDBContext budgetControlDBContext)
	{
		_budgetControlDB = budgetControlDBContext;
	}


	public Task<bool> CreateAsync(Category entity)
	{
		throw new NotImplementedException();
	}

	public Task<bool> DeleteAsync(Category entity)
	{
		throw new NotImplementedException();
	}

	public Task<List<Category>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task<Category?> GetByIdAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task<List<Category?>> GetByNameAsync(string name)
	{
		throw new NotImplementedException();
	}

	public Task<bool> Update(Category entity)
	{
		throw new NotImplementedException();
	}	
}
