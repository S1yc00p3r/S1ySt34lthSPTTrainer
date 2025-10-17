using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

#nullable enable

namespace S1ySt34lth.Trainer.Features;

internal class ShaderCache : MonoBehaviour
{
	public Dictionary<Renderer, Shader?> Cache { get; } = [];

	[UsedImplicitly]
	public void OnDestroy()
	{
		Cache.Clear();
	}
}
