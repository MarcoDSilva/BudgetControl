using System.ComponentModel.DataAnnotations;

namespace BudgetControl.Domain.Common;

public abstract class BaseEntity
{
	[Key, Required]
	public int Id { get; set; }
	[Required]
	public DateTime CreatedAt { get; set; }
	[Required]
	public DateTime ChangedAt { get; set; }
}
