using BudgetControl.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetControl.Domain.Common;

public class SubCategory : BaseEntity
{
    [Required, StringLength(50)]
    public string Name { get; set; }

    [Required, ForeignKey("Categories")]
    public int CategoryId { get; set; }
}
