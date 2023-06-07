using Spectre.Console;

namespace BudgetControl.Presentation.Shared.Components;

public abstract class DrawComponents
{
	public void Question(string message)
	{
		var rule = new Rule($"[yellow4_1]{message}[/]");
		rule.LeftJustified();
		AnsiConsole.Write(rule);
	}

	public int GetID(string message)
	{
		var id = AnsiConsole.Prompt<int>(
							new TextPrompt<int>(message)
							.PromptStyle("red")
							.ValidationErrorMessage("[red]That's not a valid ID[/]")
							.Validate(id =>
							{
								return id switch
								{
									<= 0 => ValidationResult.Error("[red]Id can't be equal or under to 0![/]"),
									_ => ValidationResult.Success(),
								};
							}));

		return id;
	}

	public int FieldToEdit()
	{
		var answer = AnsiConsole.Prompt<int>(
								new TextPrompt<int>("What field you want to edit? Pick the number from the field.")
								.Validate(id =>
								{
									return id switch
									{
										<= 0 => ValidationResult.Error("[red]Id can't be equal or under to 0![/]"),
										_ => ValidationResult.Success(),
									};
								}));

		return answer;
	}
}
