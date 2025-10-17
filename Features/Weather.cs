﻿using S1ySt34lth.Trainer.Properties;
using S1ySt34lth.Weather;
using JetBrains.Annotations;
using UnityEngine;

#nullable enable

namespace S1ySt34lth.Trainer.Features;

[UsedImplicitly]
internal class Weather : TriggerFeature
{
	public override string Name => Strings.FeatureWeatherName;
	public override string Description => Strings.FeatureWeatherDescription;

	public override KeyCode Key { get; set; } = KeyCode.None;

	protected override void UpdateOnceWhenTriggered()
	{
		ToClearWeather();
	}

	public static void ToClearWeather(bool changeTime = true)
	{
		var weatherController = WeatherController.Instance;
		if (weatherController != null)
		{
			var weatherDebug = weatherController.WeatherDebug;
			weatherDebug.Enabled = true;
			weatherDebug.CloudDensity = -0.7f;
			weatherDebug.Fog = 0.004f;
			weatherDebug.LightningThunderProbability = 0f;
			weatherDebug.Rain = 0f;
		}

		if (!changeTime)
			return;

		var sky = TOD_Sky.Instance;
		if (sky == null)
			return;

		sky.Components.Time.GameDateTime = null;
		sky.Cycle.Hour = 12f;
	}
}
