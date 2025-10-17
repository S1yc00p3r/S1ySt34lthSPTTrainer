using S1ySt34lth.Trainer.Properties;
using S1ySt34lth.UI;

#nullable enable

namespace S1ySt34lth.Trainer.ConsoleCommands;

internal abstract class ConsoleCommandWithoutArgument : ConsoleCommand
{
	public abstract void Execute();

	public override void Register()
	{
#if DEBUG
		AddConsoleLog(string.Format(Strings.DebugRegisteringCommandFormat, Name));
#endif
		ConsoleScreen.Processor.RegisterCommand(Name, Execute);
	}
}
