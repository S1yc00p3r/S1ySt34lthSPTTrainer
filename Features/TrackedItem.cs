using S1ySt34lth.Trainer.Configuration;
using JsonType;
using Newtonsoft.Json;
using UnityEngine;

#nullable enable

namespace S1ySt34lth.Trainer.Features;

internal class TrackedItem(string name, Color? color = null, ELootRarity? rarity = null)
{
	public const string MatchAll = "*";
	public string Name { get; set; } = name;

	[JsonConverter(typeof(ColorConverter))]
	public Color? Color { get; set; } = color;

	public ELootRarity? Rarity { get; set; } = rarity;

	[JsonIgnore]
	public bool IsMatchAll => Name == MatchAll;
}
