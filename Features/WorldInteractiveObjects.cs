﻿using S1ySt34lth.Interactive;
using S1ySt34lth.Trainer.Extensions;
using S1ySt34lth.Trainer.Properties;
using JetBrains.Annotations;
using UnityEngine;

#nullable enable

namespace S1ySt34lth.Trainer.Features;

[UsedImplicitly]
internal class WorldInteractiveObjects : TriggerFeature
{
	public override string Name => Strings.FeatureWorldInteractiveObjectsName;
	public override string Description => Strings.FeatureWorldInteractiveObjectsDescription;

	public override KeyCode Key { get; set; } = KeyCode.KeypadPeriod;

	protected override void UpdateOnceWhenTriggered()
	{
		var player = GameState.Current?.LocalPlayer;
		if (!player.IsValid())
			return;

		var objects = LocationScene.GetAllObjects<WorldInteractiveObject>();
		foreach (var obj in objects)
		{
			if (!obj.IsValid())
				continue;

			if (obj.DoorState != EDoorState.Locked)
				continue;

			var offset = player.Transform.position - obj.transform.position;
			var sqrLen = offset.sqrMagnitude;

			// only unlock if near me, else you'll get a ban from BattlEye if you brute-force-unlock all objects
			if (sqrLen <= 20.0f)
				obj.DoorState = EDoorState.Shut;
		}
	}
}
