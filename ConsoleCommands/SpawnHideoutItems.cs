using System.Collections.Generic;
using System.Linq;
using S1ySt34lth.Trainer.Extensions;
using S1ySt34lth.Trainer.Features;
using S1ySt34lth.Trainer.Properties;
using HarmonyLib;
using JetBrains.Annotations;

#nullable enable

namespace S1ySt34lth.Trainer.ConsoleCommands;

[UsedImplicitly]
internal class SpawnHideoutItems : ConsoleCommandWithoutArgument
{
	public override string Name => Strings.CommandSpawnHideoutItems;

	public override void Execute()
	{
		var player = GameState.Current?.LocalPlayer;
		if (!player.IsValid())
			return;

		var manager = player.Profile?.WishlistManager;
		if (manager == null)
			return;

		// Find the obfuscated method that returns the computed hidout items
		// We need to have the auto-add hideout items enabled in S1ySt34lth settings
		var method = AccessTools
			.GetDeclaredMethods(manager.GetType())
			.FirstOrDefault(m => m.ReturnType == typeof(IEnumerable<MongoID>));

		if (method?.Invoke(manager, []) is not IEnumerable<MongoID> templates)
			return;

		foreach (var template in templates)
			Spawn.SpawnTemplate(template, player, this, _ => true);
	}
}
