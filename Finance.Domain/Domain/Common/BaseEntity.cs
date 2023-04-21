using System.ComponentModel.DataAnnotations;

namespace BudgetControl.Domain.Common;

public abstract class BaseEntity
{
	[Key]
	public int Id { get; set; }
	[Required]
	public DateTime CreatedAt { get; set; }
	[Required]
	public DateTime ChangedAt { get; set; }
}
