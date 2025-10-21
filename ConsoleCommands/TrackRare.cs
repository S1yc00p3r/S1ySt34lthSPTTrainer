using S1ySt34lth.Trainer.Properties;
using JetBrains.Annotations;
using JsonType;

#nullable enable

namespace S1ySt34lth.Trainer.ConsoleCommands;

[UsedImplicitly]
internal class TrackRare : BaseTrackCommand
{
	public override string Name => Strings.CommandTrackRare;
	protected override ELootRarity? Rarity => ELootRarity.Rare;
}
