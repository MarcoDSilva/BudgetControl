using BudgetControl.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace BudgetControl.Domain.Entities;

public class Category : BaseEntity
{
	[Required, StringLength(50)]
	public string Name { get; set; }

}
