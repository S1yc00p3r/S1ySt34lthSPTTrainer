using System.Linq;
using S1ySt34lth.InventoryLogic;
using S1ySt34lth.Trainer.Extensions;
using S1ySt34lth.Trainer.Properties;
using JetBrains.Annotations;

#nullable enable

namespace S1ySt34lth.Trainer.Features;

[UsedImplicitly]
internal class Durability : ToggleFeature
{
	public override string Name => Strings.FeatureDurabilityName;
	public override string Description => Strings.FeatureDurabilityDescription;

	public override bool Enabled { get; set; } = false;

	protected override void UpdateWhenEnabled()
	{
		var player = GameState.Current?.LocalPlayer;
		if (!player.IsValid())
			return;

		var allPlayerItems = player.Profile
			.Inventory
			.GetPlayerItems()
			.ToArray();

		foreach (var item in allPlayerItems)
		{
			var repairable = item?.GetItemComponent<RepairableComponent>();
			if (repairable == null)
				continue;

			repairable.MaxDurability = repairable.TemplateDurability;
			repairable.Durability = repairable.MaxDurability;
		}
	}
}
