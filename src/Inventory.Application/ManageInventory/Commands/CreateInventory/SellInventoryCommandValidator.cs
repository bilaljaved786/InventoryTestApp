using FluentValidation;

namespace Inventory.Application.ManageInventory.Commands.CreateInventory
{
	public class SellInventoryCommandValidator: AbstractValidator<SellInventoryCommand>
	{
		public SellInventoryCommandValidator()
		{
			RuleFor(inventoryCommand => inventoryCommand.InventoryId)
				.NotEmpty().NotNull().WithMessage("must not be {PropertyName}");
		}
	}
}
