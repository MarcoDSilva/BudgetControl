using Finance.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Finance.Domain.Domain.Entities;

public class Category : BaseEntity
{
	[Required, StringLength(50)]
	public string Name { get; set; }

}
