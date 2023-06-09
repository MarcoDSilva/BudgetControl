﻿namespace BudgetControl.Application.DTO;

public class IncomeDTO
{
	public DateTime TransactionDate { get; set; }
	public int CategoryId { get; set; }
	public int SubCategoryId { get; set; }
	public decimal Value { get; set; }
	public string Description { get; set; } = "";
}
