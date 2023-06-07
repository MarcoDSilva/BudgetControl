using System.ComponentModel.DataAnnotations;

namespace BudgetControl.Application.DTO;

public class SubCategoryDTO
{
	public string Name { get; set; }
	public int CategoryId { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime ChangedAt { get; set; }
}
