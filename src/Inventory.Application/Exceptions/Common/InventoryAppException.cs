using System;

namespace Inventory.Application.Exceptions.Common
{
    public class InventoryAppException: Exception
    {
        protected InventoryAppException(string message) : base(message)
        { }
    }
}
