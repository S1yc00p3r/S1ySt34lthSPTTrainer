using S1ySt34lth.Trainer.Configuration;
using JetBrains.Annotations;
using UnityEngine;

#nullable enable

namespace S1ySt34lth.Trainer.Features;

internal abstract class TriggerFeature : Feature
{
	[ConfigurationProperty(Order = 2)]
	public virtual KeyCode Key { get; set; } = KeyCode.None;

	[UsedImplicitly]
	private void Update()
	{
		if (Key != KeyCode.None && Input.GetKeyUp(Key))
			UpdateOnceWhenTriggered();
	}

	protected virtual void UpdateOnceWhenTriggered() { }
}
