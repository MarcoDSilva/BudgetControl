using BudgetControl.Data.Context;
using BudgetControl.Domain.Common;
using Microsoft.EntityFrameworkCore;
using BudgetControl.Application.Repository.Interfaces;

namespace BudgetControl.Application.Repository;

public class SubCategoryRepository : ISubCategoryRepository
{
	private readonly BudgetControlDBContext _budgetControlDB;

	public SubCategoryRepository(BudgetControlDBContext budgetControlDB)
	{
		_budgetControlDB = budgetControlDB;
	}

	public async Task<bool> CreateAsync(SubCategory entity)
	{
		var inserted = await _budgetControlDB.SubCategories.AddAsync(entity);
		var save = await _budgetControlDB.SaveChangesAsync();

		return save > 0;
	}

	public async Task<bool> DeleteAsync(SubCategory entity)
	{
		var deleted = _budgetControlDB.SubCategories.Remove(entity);
		var save = await _budgetControlDB.SaveChangesAsync();

		return save > 0;
	}

	public async Task<List<SubCategory>> GetAllAsync()
	{
		var subCategories = await _budgetControlDB.SubCategories.ToListAsync();
		return subCategories;
	}

	public async Task<SubCategory?> GetByIdAsync(int id)
	{
		var subCategories = await _budgetControlDB.SubCategories.ToListAsync();
		var subCategory = subCategories.Where(ct => ct.Id == id).FirstOrDefault();

		return subCategory;
	}

	public async Task<List<SubCategory?>> GetByNameAsync(string name)
	{
		var subCategories = await _budgetControlDB.SubCategories.ToListAsync();
		var subCategory = subCategories.Where(ct => ct.Name.ToLower()
												.Equals(
													name.ToLower())
										).ToList();

		return subCategory;
	}

	public async Task<bool> Update(SubCategory entity)
	{
		_budgetControlDB.SubCategories.Update(entity);
		var wasSaved = await _budgetControlDB.SaveChangesAsync();

		return wasSaved > 0;
	}
}
