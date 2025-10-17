﻿using System.Linq;
using S1ySt34lth.InventoryLogic;
using S1ySt34lth.Trainer.Properties;
using JetBrains.Annotations;
using UnityEngine;

#nullable enable

namespace S1ySt34lth.Trainer.Features;

[UsedImplicitly]
internal class AirDrop : TriggerFeature
{
	public override string Name => Strings.FeatureAirDropName;
	public override string Description => Strings.FeatureAirDropDescription;

	public override KeyCode Key { get; set; } = KeyCode.None;

	protected override void UpdateOnceWhenTriggered()
	{
		var player = GameState.Current?.LocalPlayer;
		if (player == null)
			return;

		if (TemplateHelper.FindTemplates(KnownTemplateIds.RedSignalFlare).FirstOrDefault() is not AmmoTemplate template)
			return;

		player.HandleFlareSuccessEvent(player.Transform.position, template);
	}
}
