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

	public Task<bool> AddAsync(ExpensesDTO expensesDTO)
	{
		return Task.FromResult(true);

		throw new NotImplementedException();
	}

	public async Task<List<ExpensesDTO>> GetExpenses()
	{
		var expenses = await _unitOfWork.expensesRepository.GetAllAsync();
		var expensesDTO = new List<ExpensesDTO>();
		
		expenses.ForEach(exp => expensesDTO.Add(_mapper.Map<Expenses, ExpensesDTO>(exp)));
		return expensesDTO;
	}
}
