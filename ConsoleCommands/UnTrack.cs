﻿using System.Text.RegularExpressions;
using S1ySt34lth.Trainer.Properties;
using JetBrains.Annotations;

#nullable enable

namespace S1ySt34lth.Trainer.ConsoleCommands;

[UsedImplicitly]
internal class UnTrack : BaseTrackCommand
{
	public override string Name => Strings.CommandUnTrack;

	public override void Execute(Match match)
	{
		var matchGroup = match.Groups[ValueGroup];
		if (matchGroup is not { Success: true })
			return;

		TrackList.ShowTrackList(this, LootItemsFeature, LootItemsFeature.UnTrack(matchGroup.Value));
	}
}
