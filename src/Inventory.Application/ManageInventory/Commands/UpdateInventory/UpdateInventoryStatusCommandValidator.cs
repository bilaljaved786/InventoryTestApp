using FluentValidation;

namespace Inventory.Application.ManageInventory.Commands.UpdateInventory
{
	public class UpdateInventoryStatusCommandValidator: AbstractValidator<UpdateInventoryStatusCommand>
	{
		public UpdateInventoryStatusCommandValidator()
		{
			RuleFor(m => m.InventoryId).NotEmpty()
				.NotNull().WithMessage("must not be {PropertyName}");

			RuleFor(m => m.ProductStatus).NotEmpty()
				.NotNull().WithMessage("must not be {PropertyName}");
		}
	}
}
