using System.Diagnostics.CodeAnalysis;
using S1ySt34lth.Interactive;

#nullable enable

namespace S1ySt34lth.Trainer.Extensions;

public static class ExfiltrationPointExtensions
{
	public static bool IsValid([NotNullWhen(true)] this ExfiltrationPoint? point)
	{
		return point != null
			   && point.Settings?.Name != null
			   && point.transform != null;
	}
}
