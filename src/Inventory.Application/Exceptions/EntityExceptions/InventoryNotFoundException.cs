using System;
using Inventory.Application.Exceptions.Common;

namespace Inventory.Application.Exceptions.EntityExceptions
{
    public class InventoryNotFoundException: EntityNotFoundException
    {
        public InventoryNotFoundException(Guid key) : base(nameof(Domain.Entities.Inventory), key,
          $"\"{nameof(Domain.Entities.Inventory)}\" not found with the \"{key}\"")
        { }
    }
}
