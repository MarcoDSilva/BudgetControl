using BudgetControl.Domain.Entities;
using BudgetControl.Infrastructure.Interfaces;

namespace BudgetControl.Infrastructure.Repository;
public class CategoryRepository : ICategoryRepository
{
	public Task<Category> CreateAsync(Category entity)
	{
		throw new NotImplementedException();
	}

	public Task<Category> DeleteAsync(Category entity)
	{
		throw new NotImplementedException();
	}

	public Task<List<Category>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task<Category> GetByIdAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task<Category> GetByNameAsync(string name)
	{
		throw new NotImplementedException();
	}

	public Task<Category> UpdateAsync(Category entity)
	{
		throw new NotImplementedException();
	}
}
