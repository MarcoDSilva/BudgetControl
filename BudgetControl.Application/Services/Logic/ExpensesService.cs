using AutoMapper;
using BudgetControl.Application.DTO;
using BudgetControl.Application.Services.Interfaces;
using BudgetControl.Domain.Entities;
using BudgetControl.Infrastructure.Interfaces;

namespace BudgetControl.Application.Services.Logic;

public class ExpensesService : IExpensesService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public ExpensesService(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<bool> AddAsync(ExpensesDTO expensesDTO)
	{
		var expenses = new Expenses()
		{
			Description = expensesDTO.Description,
			CreatedAt = DateTime.Now,
			TransactionDate = expensesDTO.TransactionDate,
			Value = expensesDTO.Value,
			ChangedAt = DateTime.Now,
			CategoryId = 1,
			SubCategoryId = 1
		};

		var addedExpense = await _unitOfWork.expensesRepository.CreateAsync(expenses);
		return addedExpense;
	}

	public async Task<List<ExpensesDTO>> GetExpenses()
	{
		var expenses = await _unitOfWork.expensesRepository.GetAllAsync();
		var expensesDTO = new List<ExpensesDTO>();

		expenses.ForEach(exp => expensesDTO.Add(_mapper.Map<Expenses, ExpensesDTO>(exp)));
		return expensesDTO;
	}
}
