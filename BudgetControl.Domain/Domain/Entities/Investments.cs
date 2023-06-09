﻿using BudgetControl.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace BudgetControl.Domain.Entities;

public class Investments : BaseTransaction
{
	[Required]
	public bool IsActive { get; set; }

	[Required, Range(0.0, 1000)]
	public decimal ExpectedReturn { get; set; }
}
