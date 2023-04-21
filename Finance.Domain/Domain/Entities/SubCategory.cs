using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetControl.Domain.Common;

public class SubCategory
{
    [Required, StringLength(50)]
    public string Name { get; set; }

    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }
}
