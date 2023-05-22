using AutoMapper;
using BudgetControl.Application.DTO;
using BudgetControl.Application.Services.Interfaces;
using BudgetControl.Domain.Entities;
using BudgetControl.Infrastructure.Interfaces;

namespace BudgetControl.Application.Services.Logic;

public class IncomeService : IIncomeService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public IncomeService(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<bool> AddAsync(IncomeDTO incomeDTO)
	{
		var income = new Income()
		{
			Description = incomeDTO.Description,
			CreatedAt = DateTime.Now,
			TransactionDate = incomeDTO.TransactionDate,
			Value = incomeDTO.Value,
			ChangedAt = DateTime.Now,
			CategoryId = 1,
			SubCategoryId = 1
		};

		var addedIncome = await _unitOfWork.incomeRepository.CreateAsync(income);
		return addedIncome;
	}

	public async Task<bool> EditAsync(Income income)
	{
		var wasSaved = await _unitOfWork.incomeRepository.Update(income);
		return wasSaved;
	}

	public async Task<List<IncomeDTO>> GetAllAsync()
	{
		var incomes = await _unitOfWork.incomeRepository.GetAllAsync();
		var incomeDTO = new List<IncomeDTO>();

		incomes.ForEach(exp => incomeDTO.Add(new IncomeDTO
		{
			CategoryId = exp.CategoryId,
			Description = exp.Description,
			SubCategoryId = exp.SubCategoryId,
			Value = exp.Value,
			TransactionDate = exp.TransactionDate
		}));

		return incomeDTO;
	}

	public async Task<Income?> GetByID(int id)
	{
		var incomes = await _unitOfWork.incomeRepository.GetAllAsync();
		var income = incomes.Find(exp => exp.Id == id);

		return income;
	}

	public async Task<bool> RemoveAsync(Income income)
	{
		var remove = await _unitOfWork.incomeRepository.DeleteAsync(income);
		return remove;
	}
}
