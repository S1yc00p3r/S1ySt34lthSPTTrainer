﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Comfort.Common;
using S1ySt34lth.Counters;
using S1ySt34lth.Interactive;
using S1ySt34lth.Quests;
using S1ySt34lth.Trainer.Configuration;
using S1ySt34lth.Trainer.Extensions;
using S1ySt34lth.Trainer.Properties;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

#nullable enable

namespace S1ySt34lth.Trainer.Features;

[UsedImplicitly]
internal class Quests : PointOfInterests
{
	public override string Name => Strings.FeatureQuestsName;
	public override string Description => Strings.FeatureQuestsDescription;

	[ConfigurationProperty]
	public Color Color { get; set; } = Color.magenta;

	public override float CacheTimeInSec { get; set; } = 5f;
	public override bool Enabled { get; set; } = false;
	public override Color GroupingColor => Color;

	private readonly ConcurrentDictionary<string, ExperienceTrigger[]> _experienceTriggerCache = [];
	private readonly ConcurrentDictionary<string, PlaceItemTrigger[]> _placeItemTriggerCache = [];
	private static bool _refreshLookupTables = true;

#pragma warning disable IDE0060
	[UsedImplicitly]
	protected static void OnConditionChangedHandlerPostfix(QuestClass conditional)
	{
		_refreshLookupTables = true;
	}
#pragma warning restore IDE0060

	public override void RefreshData(List<PointOfInterest> data)
	{
		var world = Singleton<GameWorld>.Instance;
		if (world == null)
			return;

		var player = GameState.Current?.LocalPlayer;
		if (!player.IsValid())
			return;

		var camera = GameState.Current?.Camera;
		if (camera == null)
			return;

		var profile = player.Profile;
		if (profile == null)
			return;

		var scene = SceneManager.GetActiveScene();
		if (!scene.isLoaded)
			return;

		var startedQuests = profile.QuestsData
			.Where(q => q.Status is EQuestStatus.Started && q.Template != null)
			.ToArray();

		if (!startedQuests.Any())
			return;

		if (_refreshLookupTables)
		{
			_experienceTriggerCache.Clear();
			_placeItemTriggerCache.Clear();

			_refreshLookupTables = false;
		}

		RefreshPlaceOrRepairItemLocations(scene, startedQuests, profile, data);
		RefreshVisitPlaceLocations(scene, startedQuests, profile, data);
		RefreshFindItemLocations(startedQuests, world, data);
	}

	private void RefreshVisitPlaceLocations(Scene scene, QuestDataClass[] startedQuests, Profile profile, List<PointOfInterest> records)
	{
		if (!_experienceTriggerCache.TryGetValue(scene.name, out var triggers))
		{
			triggers = FindObjectsOfType<ExperienceTrigger>();
			if (triggers.Length > 0)
				_experienceTriggerCache[scene.name] = triggers;
		}

		foreach (var quest in startedQuests)
		{
			var conditions = quest.Template!.Conditions[EQuestStatus.AvailableForFinish].OfType<ConditionCounterCreator>().ToArray();
			foreach (var condition in conditions)
			{
				if (quest.CompletedConditions.Contains(condition.id))
					continue;

				foreach (var cvp in condition.Conditions.OfType<ConditionVisitPlace>())
				{
					var trigger = triggers.FirstOrDefault(t => t.Id == cvp.target);
					if (trigger == null)
						continue;

					var visited = profile.Stats.S1ySt34lth.OverallCounters.GetInt(CounterTag.TriggerVisited, trigger.Id) > 0;
					if (visited)
						continue;

					var position = trigger.transform.position;
					AddQuestRecord(records, condition, quest, position);
					break;
				}
			}
		}
	}

	private void RefreshFindItemLocations(QuestDataClass[] startedQuests, GameWorld world, List<PointOfInterest> records)
	{
		var lootItems = world.LootItems;

		for (var i = 0; i < lootItems.Count; i++)
		{
			var lootItem = lootItems.GetByIndex(i);
			if (!lootItem.IsValid())
				continue;

			if (!lootItem.Item.QuestItem)
				continue;

			foreach (var quest in startedQuests)
			{
				foreach (var condition in quest.Template!.Conditions[EQuestStatus.AvailableForFinish].OfType<ConditionFindItem>())
				{
					if (!condition.target.Contains(lootItem.Item.TemplateId.ToString()) || quest.CompletedConditions.Contains(condition.id))
						continue;

					var position = lootItem.transform.position;
					AddQuestRecord(records, condition, quest, position);
				}
			}
		}
	}

	private void RefreshPlaceOrRepairItemLocations(Scene scene, QuestDataClass[] startedQuests, Profile profile, List<PointOfInterest> records)
	{
		var allPlayerItems = profile
			.Inventory
			.GetPlayerItems()
			.ToArray();

		if (!_placeItemTriggerCache.TryGetValue(scene.name, out var triggers))
		{
			triggers = FindObjectsOfType<PlaceItemTrigger>();
			if (triggers.Length > 0)
				_placeItemTriggerCache[scene.name] = triggers;
		}

		foreach (var quest in startedQuests)
		{
			var conditions = quest.Template!.Conditions[EQuestStatus.AvailableForFinish].OfType<ConditionZone>().ToArray();
			foreach (var condition in conditions)
			{
				if (quest.CompletedConditions.Contains(condition.id))
					continue;

				var result = allPlayerItems.FirstOrDefault(x => condition.target.Contains(x.TemplateId.ToString()));
				if (result == null)
					continue;

				var trigger = triggers.FirstOrDefault(t => t.Id == condition.zoneId);
				if (trigger == null)
					continue;

				var position = trigger.transform.position;
				AddQuestRecord(records, condition, quest, position);
				break;
			}
		}
	}

	private void AddQuestRecord(List<PointOfInterest> records, Condition condition, QuestDataClass quest, Vector3 position)
	{
		var poi = Pool.Get();
		poi.Name = string.Format(Strings.FeatureQuestsFormat, condition.FormattedDescription, quest.Template!.Name);
		poi.Position = position;
		poi.Color = Color;
		poi.Owner = null;

		records.Add(poi);
	}

	protected override void UpdateWhenEnabled()
	{
		HarmonyPatchOnce(harmony =>
		{
			HarmonyPostfix(harmony, typeof(AbstractQuestControllerClass), nameof(AbstractQuestControllerClass.OnConditionChangedHandler), nameof(OnConditionChangedHandlerPostfix));
		});
	}
}
