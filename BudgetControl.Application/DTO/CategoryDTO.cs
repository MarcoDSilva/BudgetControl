﻿using System.ComponentModel.DataAnnotations;

namespace BudgetControl.Application.DTO;

public class CategoryDTO
{
	public string Name { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime ChangedAt { get; set; }
}
