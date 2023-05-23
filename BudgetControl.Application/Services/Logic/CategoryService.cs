using AutoMapper;
using BudgetControl.Application.DTO;
using BudgetControl.Application.Services.Interfaces;
using BudgetControl.Domain.Entities;
using BudgetControl.Infrastructure.Interfaces;

namespace BudgetControl.Application.Services.Logic;

public class CategoryService : ICategoryService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}

	public async Task<bool> AddAsync(CategoryDTO categoryDTO)
	{
		var category = new Category()
		{
			Name = categoryDTO.Name,
			CreatedAt = DateTime.Now,
			ChangedAt = DateTime.Now
		};

		var addedCategory = await _unitOfWork.categoryRepository.CreateAsync(category);
		return addedCategory;
	}

	public async Task<List<CategoryDTO>> GetAllAsync()
	{
		var categories = await _unitOfWork.categoryRepository.GetAllAsync();
		var categoriesDTO = new List<CategoryDTO>();

		categories.ForEach(ct => categoriesDTO.Add(new CategoryDTO
		{
			Name = ct.Name
		}));

		return categoriesDTO;
	}

	public async Task<bool> EditAsync(Category category)
	{
		var wasSaved = await _unitOfWork.categoryRepository.Update(category);
		return wasSaved;
	}

	public async Task<bool> RemoveAsync(Category category)
	{
		var remove = await _unitOfWork.categoryRepository.DeleteAsync(category);
		return remove;
	}
	public async Task<Category?> GetByID(int id)
	{
		var categories = await _unitOfWork.categoryRepository.GetAllAsync();
		var category = categories.Find(ct => ct.Id == id);

		return category;
	}
}
