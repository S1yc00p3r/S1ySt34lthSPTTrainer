using S1ySt34lth.Trainer.Configuration;
using S1ySt34lth.Trainer.Extensions;
using S1ySt34lth.Trainer.Properties;
using JetBrains.Annotations;
using UnityEngine;

#nullable enable

namespace S1ySt34lth.Trainer.Features;

[UsedImplicitly]
internal class Speed : HoldFeature
{
	public override string Name => Strings.FeatureSpeedName;
	public override string Description => Strings.FeatureSpeedDescription;

	public override KeyCode Key { get; set; } = KeyCode.None;

	[ConfigurationProperty]
	public float Intensity { get; set; } = 2.0f;

	protected override void UpdateWhenHold()
	{
		var player = GameState.Current?.LocalPlayer;
		if (!player.IsValid())
			return;

		var camera = GameState.Current?.Camera;
		if (camera == null)
			return;

		player.Transform.position += Intensity * Time.deltaTime * camera.transform.forward;
	}
}
