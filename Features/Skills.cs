﻿using S1ySt34lth.Trainer.Extensions;
using S1ySt34lth.Trainer.Properties;
using JetBrains.Annotations;
using UnityEngine;

#nullable enable

namespace S1ySt34lth.Trainer.Features;

[UsedImplicitly]
internal class Skills : TriggerFeature
{
	public override string Name => Strings.FeatureSkillsName;
	public override string Description => Strings.FeatureSkillsDescription;

	public override KeyCode Key { get; set; } = KeyCode.None;

	protected override void UpdateOnceWhenTriggered()
	{
		var player = GameState.Current?.LocalPlayer;
		if (!player.IsValid())
			return;

		if (player.Skills?.Skills == null)
			return;

		foreach (var skill in player.Skills.DisplayList)
			skill.SetLevel(51);

		if (player.Skills.Mastering == null)
			return;

		foreach (var item in player.Skills.Mastering.Values)
			item.Current = item.MasteringGroup.Level2 + item.MasteringGroup.Level3;
	}
}
