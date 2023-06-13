using AutoMapper;
using BudgetControl.Application.DTO;
using BudgetControl.Application.Services.Interfaces;
using BudgetControl.Domain.Common;
using BudgetControl.Domain.Entities;
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

	public Task<bool> EditAsync(SubCategory subCategory)
	{
		throw new NotImplementedException();
	}

	public Task<List<SubCategoryDTO>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task<SubCategory?> GetByID(int id)
	{
		throw new NotImplementedException();
	}

	public Task<bool> RemoveAsync(SubCategory subCategory)
	{
		throw new NotImplementedException();
	}
}
