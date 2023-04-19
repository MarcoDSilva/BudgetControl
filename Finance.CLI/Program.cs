// See https://aka.ms/new-console-template for more information
using Finance.Domain.Entities;
using Spectre.Console;

var layout = new Layout("Main")
				.SplitColumns(
					new Layout("Left"),
					new Layout("Right")
						.SplitRows(
							new Layout("Top"),
							new Layout("Bottom")
					)
				);

layout["Left"]
	.Update(new Panel(Align.Center(
			new Markup("Hello matey"),
			VerticalAlignment.Middle))
	.Expand());

layout["Left"].Ratio(2);
layout["Right"].Ratio(2);
layout["Main"].Ratio(5);

AnsiConsole.Write(layout);