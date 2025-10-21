using System.Text.RegularExpressions;
using S1ySt34lth.Trainer.Configuration;
using S1ySt34lth.Trainer.Properties;
using JetBrains.Annotations;

#nullable enable

namespace S1ySt34lth.Trainer.ConsoleCommands;

[UsedImplicitly]
internal class LoadTrackList : BaseTrackListCommand
{
	public override string Name => Strings.CommandLoadTrackList;

	public override void Execute(Match match)
	{
		if (!TryGetTrackListFilename(match, out var filename))
			return;

		// StayInTarkov (SIT) is exposing a LootItems type in the global namespace, so make sure we use a qualified name here
		ConfigurationManager.LoadPropertyValue(filename, LootItemsFeature, nameof(Features.LootItems.TrackedNames));
	}
}
