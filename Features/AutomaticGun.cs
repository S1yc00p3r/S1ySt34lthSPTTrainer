﻿using S1ySt34lth.InventoryLogic;
using S1ySt34lth.Trainer.Configuration;
using S1ySt34lth.Trainer.Extensions;
using S1ySt34lth.Trainer.Properties;
using JetBrains.Annotations;

#nullable enable

namespace S1ySt34lth.Trainer.Features;

[UsedImplicitly]
internal class AutomaticGun : ToggleFeature
{
	public override string Name => Strings.FeatureAutomaticGunName;
	public override string Description => Strings.FeatureAutomaticGunDescription;

	public override bool Enabled { get; set; } = false;

	[ConfigurationProperty]
	public int Rate { get; set; } = 500;

	protected override void UpdateWhenEnabled()
	{
		var player = GameState.Current?.LocalPlayer;
		if (!player.IsValid())
			return;

		if (player.HandsController.Item is not Weapon weapon)
			return;

		var fireModeComponent = weapon.GetItemComponent<FireModeComponent>();
		if (fireModeComponent == null)
			return;

		fireModeComponent.FireMode = Weapon.EFireMode.fullauto;

		if (player.HandsController is not Player.FirearmController controller)
			return;

		var template = controller.Item?.Template;
		if (template == null)
			return;

		template.BoltAction = false;
		template.bFirerate = Rate;
	}
}
