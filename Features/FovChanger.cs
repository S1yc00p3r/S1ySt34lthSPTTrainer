﻿using S1ySt34lth.Trainer.Configuration;
using S1ySt34lth.Trainer.Properties;
using JetBrains.Annotations;
using UnityEngine;

namespace S1ySt34lth.Trainer.Features;

[UsedImplicitly]
internal class FovChanger : ToggleFeature
{
	public override string Name => Strings.FeatureFovChangerName;
	public override string Description => Strings.FeatureFovChangerDescription;

	[ConfigurationProperty(Order = 1)]
	public override bool Enabled { get; set; } = false;

	[ConfigurationProperty(Order = 2)]
	public float Fov { get; set; } = 75f;

	[ConfigurationProperty(Order = 3)]
	public float CameraOffset { get; set; } = 0.05f;

	[UsedImplicitly]
	private void LateUpdate()
	{
		if (!Enabled)
			return;

		var snapshot = GameState.Current;
		if (snapshot == null)
			return;

		var camera = snapshot.Camera;
		if (camera == null)
			return;

		var player = snapshot.LocalPlayer;
		if (player == null)
			return;

		var container = player.ProceduralWeaponAnimation.HandsContainer;
		if (container == null)
			return;

		container.CameraOffset = new Vector3(0.04f, 0.04f, CameraOffset);
		camera.fieldOfView = Fov;
	}
}
