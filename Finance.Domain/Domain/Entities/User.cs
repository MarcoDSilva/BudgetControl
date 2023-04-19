﻿using Finance.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Finance.Domain.Entities;

public class User : BaseEntity
{
	[Required, StringLength(30)]
	public string Username { get; set; }

	[Required, StringLength(255)]
	public string Email { get; set; }

	[Required, StringLength(255)]
	public string Password { get; set; }
}
