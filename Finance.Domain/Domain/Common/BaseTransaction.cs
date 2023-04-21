using BudgetControl.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetControl.Domain.Common;

public class BaseTransaction : BaseEntity
{
	[Required, StringLength(250)]
	public string Description { get; set; }

	[Required]
	public decimal Value { get; set; }

	[Required]
	public DateTime TransactionDate { get; set; }

	[ForeignKey(nameof(Category))]
	[Required]
	public int CategoryId { get; set; }

	[ForeignKey(nameof(SubCategory))]
	public int SubCategoryId { get; set; }

}
