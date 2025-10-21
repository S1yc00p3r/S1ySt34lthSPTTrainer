using S1ySt34lth.Trainer.Properties;
using JetBrains.Annotations;
using JsonType;

#nullable enable

namespace S1ySt34lth.Trainer.ConsoleCommands;

[UsedImplicitly]
internal class ListSuperRare : BaseListCommand
{
	public override string Name => Strings.CommandListSuperRare;
	protected override ELootRarity? Rarity => ELootRarity.Superrare;
}
