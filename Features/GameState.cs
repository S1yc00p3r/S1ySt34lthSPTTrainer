﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Comfort.Common;
using S1ySt34lth.Trainer.Configuration;
using S1ySt34lth.Trainer.Extensions;
using S1ySt34lth.Trainer.Properties;
using JetBrains.Annotations;
using UnityEngine;

#nullable enable

namespace S1ySt34lth.Trainer.Features;

internal class GameState : CachableFeature<GameStateSnapshot>
{
	public override string Name => Strings.FeatureGameStateName;
	public override string Description => Strings.FeatureGameStateDescription;

	public static GameStateSnapshot? Current { get; private set; }

	public override float CacheTimeInSec { get; set; } = 2f;

	[ConfigurationProperty(Skip = true)] // we do not want to offer save/load support for this
	public override bool Enabled { get; set; } = true;

	[ConfigurationProperty(Skip = true)] // we do not want to offer save/load support for this
	public override KeyCode Key { get; set; } = KeyCode.None;

	public static Shader? OutlineShader { get; private set; }

	[UsedImplicitly]
	private void Awake()
	{
		// if we are not able to load our dedicated shader, we'll have OutlineShader==null => Unity will use the magenta-debug-shader, which is a nice fallback
		if (OutlineShader != null)
			return;

		var filename = Path.Combine(Application.dataPath, "outline");
		if (!File.Exists(filename))
			return;

		var bundle = AssetBundle.LoadFromFile(filename);
		if (bundle == null)
			return;

		OutlineShader = bundle.LoadAsset<Shader>("assets/outline.shader");
	}

	public override void RefreshData(List<GameStateSnapshot> data)
	{
		var snapshot = new GameStateSnapshot();
		var world = Singleton<GameWorld>.Instance;

		if (world == null)
			return;

		var players = world
			.RegisteredPlayers?
			.OfType<Player>();

		if (players == null)
			return;

		var hostiles = new List<Player>();
		snapshot.Hostiles = hostiles;

		foreach (var player in players)
		{
			if (player.IsYourPlayer)
			{
				snapshot.LocalPlayer = player;
				continue;
			}

			if (!player.IsAlive())
				continue;

			hostiles.Add(player);
		}

		snapshot.Camera = Camera.main;

		Current = snapshot;
		data.Add(snapshot);
	}
}

public class GameStateSnapshot
{
	public Camera? Camera { get; set; }
	public Camera? MapCamera { get; set; }
	public Player? LocalPlayer { get; set; }
	public IEnumerable<Player> Hostiles { get; set; } = [];
	public bool MapMode { get; set; } = false;
}
