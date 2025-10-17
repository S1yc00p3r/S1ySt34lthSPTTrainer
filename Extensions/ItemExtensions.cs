using System.Diagnostics.CodeAnalysis;
using S1ySt34lth.InventoryLogic;
using S1ySt34lth.UI.DragAndDrop;

#nullable enable

namespace S1ySt34lth.Trainer.Extensions;

public static class ItemExtensions
{
	public static bool IsValid([NotNullWhen(true)] this Item? item)
	{
		return item?.Template != null;
	}

	public static bool IsFiltered(this Item item)
	{
		if (string.IsNullOrEmpty(item.TemplateId))
			return true;

		if (ItemViewFactory.IsSecureContainer(item))
			return true;

		if (item.CurrentAddress?.Container?.ParentItem?.TemplateId.ToString() == KnownTemplateIds.BossContainer)
			return true;

		return item.TemplateId.ToString() switch
		{
			KnownTemplateIds.DefaultInventory or KnownTemplateIds.Pockets => true,
			_ => false
			// KnownTemplateIds.Dollars or KnownTemplateIds.Euros or KnownTemplateIds.Roubles => false,
			// Incompatible with extra mods like AllInOne, setting item weight to zero
			//_ => item.Weight <= 0f,// easy way to remove special items like "Pockets" or "Default Inventory"
		};
	}
}
