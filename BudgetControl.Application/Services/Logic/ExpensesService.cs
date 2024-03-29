﻿using AutoMapper;
using BudgetControl.Application.DTO;
using BudgetControl.Application.Services.Interfaces;
using BudgetControl.Domain.Entities;
using BudgetControl.Application.Repository.Interfaces;

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

	public async Task<List<ExpensesDTO>> GetAllAsync()
	{
		var expenses = await _unitOfWork.expensesRepository.GetAllAsync();
		var expensesDTO = new List<ExpensesDTO>();

		expenses.ForEach(exp => expensesDTO.Add(new ExpensesDTO
		{
			CategoryId = exp.CategoryId,
			Description = exp.Description,
			SubCategoryId = exp.SubCategoryId,
			Value = exp.Value,
			TransactionDate = exp.TransactionDate
		}));

		return expensesDTO;
	}

	public async Task<bool> EditAsync(Expenses expenses)
	{
		var wasSaved = await _unitOfWork.expensesRepository.Update(expenses);
		return wasSaved;
	}

	public async Task<bool> RemoveAsync(Expenses expense)
	{
		var remove = await _unitOfWork.expensesRepository.DeleteAsync(expense);
		return remove;
	}

	public async Task<Expenses?> GetByID(int id)
	{
		var expenses = await _unitOfWork.expensesRepository.GetAllAsync();
		var expense = expenses.Find(exp => exp.Id == id);

		return expense;
	}
}
