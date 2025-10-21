using System;

#nullable enable

namespace S1ySt34lth.Trainer.ConsoleCommands;

internal class BuiltInCommand(string name, Action action) : ConsoleCommandWithoutArgument
{
	public override string Name => name;

	public override void Execute()
	{
		action();
	}
}
