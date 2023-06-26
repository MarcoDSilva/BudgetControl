using AutoMapper;
using BudgetControl.Application.DTO;
using BudgetControl.Domain.Entities;

namespace BudgetControl.Application;

public class MapperRegistration
{
	public static MapperConfiguration RegisteringMapper()
	{
		var mapConfig = new MapperConfiguration(config =>
		{
			config.CreateMap<Investments, InvestmentDTO>();
			config.CreateMap<InvestmentDTO, Investments>();
		});

		return mapConfig;
	}
}
