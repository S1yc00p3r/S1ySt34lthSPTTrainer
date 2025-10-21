using S1ySt34lth.Trainer.Configuration;
using S1ySt34lth.Trainer.Extensions;
using S1ySt34lth.Trainer.Properties;
using S1ySt34lth.Trainer.UI;
using JetBrains.Annotations;
using UnityEngine;

#nullable enable

namespace S1ySt34lth.Trainer.Features;

[UsedImplicitly]
internal class CrossHair : ToggleFeature
{
	public override string Name => Strings.FeatureCrosshairName;
	public override string Description => Strings.FeatureCrosshairDescription;

	public override bool Enabled { get; set; } = false;

	[ConfigurationProperty]
	public Color Color { get; set; } = Color.red;

	[ConfigurationProperty]
	public bool HideWhenAiming { get; set; } = true;

	[ConfigurationProperty]
	public float Size { get; set; } = 10f;

	[ConfigurationProperty]
	public float Thickness { get; set; } = 2f;

	protected override void OnGUIWhenEnabled()
	{
		// do not show when the console is enabled or in the hideout
		if (Cursor.visible)
			return;

		var player = GameState.Current?.LocalPlayer;
		if (!player.IsValid())
			return;

		if (player.HandsController == null)
			return;

		if (player.HandsController.IsAiming && HideWhenAiming)
			return;

		var centerx = Screen.width / 2;
		var centery = Screen.height / 2;

		Render.DrawCrosshair(new Vector2(centerx, centery), Size, Color, Thickness);
	}
}
