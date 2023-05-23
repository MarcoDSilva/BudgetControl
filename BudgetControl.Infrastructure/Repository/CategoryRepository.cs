using BudgetControl.Data.Context;
using BudgetControl.Domain.Entities;
using BudgetControl.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BudgetControl.Infrastructure.Repository;
public class CategoryRepository : ICategoryRepository
{
	private readonly BudgetControlDBContext _budgetControlDB;

	public CategoryRepository(BudgetControlDBContext budgetControlDBContext)
	{
		_budgetControlDB = budgetControlDBContext;
	}


	public async Task<bool> CreateAsync(Category entity)
	{
		var inserted = await _budgetControlDB.Categories.AddAsync(entity);
		var save = await _budgetControlDB.SaveChangesAsync();

		return save > 0;
	}

	public async Task<bool> DeleteAsync(Category entity)
	{
		var deleted = _budgetControlDB.Categories.Remove(entity);
		var save = await _budgetControlDB.SaveChangesAsync();

		return save > 0;
	}

	public async Task<List<Category>> GetAllAsync()
	{
		var categories = await _budgetControlDB.Categories.ToListAsync();
		return categories;
	}

	public async Task<Category?> GetByIdAsync(int id)
	{
		var categories = await _budgetControlDB.Categories.ToListAsync();
		var category = categories.Where(ct => ct.Id == id).FirstOrDefault();

		return category;
	}

	public async Task<List<Category?>> GetByNameAsync(string name)
	{
		var categories = await _budgetControlDB.Categories.ToListAsync();
		var category = categories.Where(ct => ct.Name.ToLower()
												.Equals(
													name.ToLower())
										).ToList();

		return category;
	}

	public async Task<bool> Update(Category entity)
	{
		_budgetControlDB.Categories.Update(entity);
		var wasSaved = await _budgetControlDB.SaveChangesAsync();

		return wasSaved > 0;
	}
}
