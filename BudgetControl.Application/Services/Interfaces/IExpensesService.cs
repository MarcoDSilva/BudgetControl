﻿using BudgetControl.Application.DTO;
using BudgetControl.Domain.Entities;

namespace BudgetControl.Application.Services.Interfaces;

public interface IExpensesService
{
	Task<List<ExpensesDTO>> GetAllAsync();
	Task<bool> AddAsync(ExpensesDTO expensesDTO);
	Task<bool> RemoveAsync(Expenses expense);
	Task<bool> EditAsync(Expenses expensesDTO);
	Task<Expenses?> GetByID(int id);
}
