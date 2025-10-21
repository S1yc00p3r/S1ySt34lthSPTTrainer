using System.Diagnostics.CodeAnalysis;
using S1ySt34lth.Interactive;

#nullable enable

namespace S1ySt34lth.Trainer.Extensions;

public static class WorldInteractiveObjectExtensions
{
	public static bool IsValid([NotNullWhen(true)] this WorldInteractiveObject? obj)
	{
		return obj != null;
	}
}
