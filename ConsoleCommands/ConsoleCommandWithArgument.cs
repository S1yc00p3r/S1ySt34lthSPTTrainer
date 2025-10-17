using System.Text.RegularExpressions;
using S1ySt34lth.Trainer.Properties;
using S1ySt34lth.UI;

#nullable enable

namespace S1ySt34lth.Trainer.ConsoleCommands;

internal abstract class ConsoleCommandWithArgument : ConsoleCommand
{
	public abstract string Pattern { get; }

	public abstract void Execute(Match match);

	protected const string ValueGroup = "value";
	protected const string ExtraGroup = "extra";

	protected const string RequiredArgumentPattern = $"(?<{ValueGroup}>.+)";
	protected const string OptionalArgumentPattern = $"(?<{ValueGroup}>.*)";

	public override void Register()
	{
#if DEBUG
		AddConsoleLog(string.Format(Strings.DebugRegisteringCommandWithArgumentsFormat, Name));
#endif
		ConsoleScreen.Processor.RegisterCommand(Name, (string args) =>
		{
			var regex = new Regex("^" + Pattern + "$");
			if (regex.IsMatch(args))
			{
				Execute(regex.Match(args));
			}
			else
			{
				AddConsoleLog(Strings.ErrorInvalidArguments.Red());
			}
		});
	}
}
