using System;
using S1ySt34lth.MovingPlatforms;
using S1ySt34lth.Trainer.Properties;
using JetBrains.Annotations;
using UnityEngine;

#nullable enable

namespace S1ySt34lth.Trainer.Features;

[UsedImplicitly]
internal class Train : TriggerFeature
{
	public override string Name => Strings.FeatureTrainName;
	public override string Description => Strings.FeatureTrainDescription;

	public override KeyCode Key { get; set; } = KeyCode.None;

	protected override void UpdateOnceWhenTriggered()
	{
		var locomotive = FindObjectOfType<Locomotive>();
		if (locomotive == null)
			return;

		locomotive.Init(DateTime.UtcNow);
	}
}
