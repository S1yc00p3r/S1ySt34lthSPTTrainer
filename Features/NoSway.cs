﻿using S1ySt34lth.Trainer.Extensions;
using S1ySt34lth.Trainer.Properties;
using JetBrains.Annotations;
using UnityEngine;

#nullable enable

namespace S1ySt34lth.Trainer.Features;

[UsedImplicitly]
internal class NoSway : ToggleFeature
{
	public override string Name => Strings.FeatureNoSwayName;
	public override string Description => Strings.FeatureNoSwayDescription;

	public override bool Enabled { get; set; } = false;

	protected override void UpdateWhenEnabled()
	{
		var player = GameState.Current?.LocalPlayer;
		if (!player.IsValid())
			return;

		var weaponAnimation = player.ProceduralWeaponAnimation;
		if (weaponAnimation == null)
			return;

		var motionReact = weaponAnimation.MotionReact;
		motionReact.Intensity = 0f;
		motionReact.SwayFactors = Vector3.zero;
		motionReact.Velocity = Vector3.zero;

		weaponAnimation.Breath.Intensity = 0;
		weaponAnimation.Walk.Intensity = 0;
		weaponAnimation.Shootingg.AimingConfiguration_0.AimProceduralIntensity = 0;
		weaponAnimation.ForceReact.Intensity = 0;
		weaponAnimation.WalkEffectorEnabled = false;
	}
}
