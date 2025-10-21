using System.Diagnostics.CodeAnalysis;
using S1ySt34lth.Interactive;

#nullable enable

namespace S1ySt34lth.Trainer.Extensions;

public static class LootItemExtensions
{
	public static bool IsValid([NotNullWhen(true)] this LootItem? lootItem)
	{
		return lootItem != null
			   && lootItem.Item.IsValid();
	}
}
