using AutoMapper;
using BudgetControl.Application.DTO;
using BudgetControl.Application.Services.Interfaces;
using BudgetControl.Domain.Common;
using BudgetControl.Infrastructure.Interfaces;

namespace BudgetControl.Application.Services.Logic;

public class SubCategoryService : ISubCategoryService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public SubCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}

	public async Task<bool> AddAsync(SubCategoryDTO subCategoryDTO)
	{
		var subCategory = new SubCategory()
		{
			Name = subCategoryDTO.Name,
			CategoryId = subCategoryDTO.CategoryId,
			ChangedAt = DateTime.Now,
			CreatedAt = subCategoryDTO.CreatedAt
		};

		var addedCategory = await _unitOfWork.subCategoryRepository.CreateAsync(subCategory);
		return addedCategory;
	}

	public async Task<bool> EditAsync(SubCategory subCategory)
	{
		var wasSaved = await _unitOfWork.subCategoryRepository.Update(subCategory);
		return wasSaved;
	}

	public async Task<List<SubCategoryDTO>> GetAllAsync()
	{
		var subCategories = await _unitOfWork.subCategoryRepository.GetAllAsync();
		var subCategoriesDTO = new List<SubCategoryDTO>();

		subCategories.ForEach(ct => subCategoriesDTO.Add(new SubCategoryDTO
		{
			Name = ct.Name
		}));

		return subCategoriesDTO;
	}

	public async Task<SubCategory?> GetByID(int id)
	{
		var subCategories = await _unitOfWork.subCategoryRepository.GetAllAsync();
		var subCategory = subCategories.Find(ct => ct.Id == id);

		return subCategory;
	}

	public async Task<bool> RemoveAsync(SubCategory subCategory)
	{
		var remove = await _unitOfWork.subCategoryRepository.DeleteAsync(subCategory);
		return remove;
	}
}
