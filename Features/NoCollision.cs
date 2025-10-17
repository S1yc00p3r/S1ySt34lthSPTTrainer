﻿using S1ySt34lth.Trainer.Properties;
using JetBrains.Annotations;
using UnityEngine;

#nullable enable

namespace S1ySt34lth.Trainer.Features;

[UsedImplicitly]
internal class NoCollision : ToggleFeature
{
	public override string Name => Strings.FeatureNoCollisionName;
	public override string Description => Strings.FeatureNoCollisionDescription;

	public override bool Enabled { get; set; } = false;

	protected override void Update()
	{
		base.Update();

		var player = GameState.Current?.LocalPlayer;
		if (player == null)
			return;

		foreach (var rigidbody in player.GetComponentsInChildren<Rigidbody>())
		{
			if (rigidbody.detectCollisions == !Enabled)
				continue;

			rigidbody.detectCollisions = !Enabled;
		}
	}
}
