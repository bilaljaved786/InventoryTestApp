namespace Inventory.Application.Exceptions.Common
{
    public class EntityNotFoundException : InventoryAppException
{
        public string Operation { get; }

		protected EntityNotFoundException(string name,object key,string operation)
			: base($"Entity \"{name}\" ({key}) was not found.") => Operation = operation;
	}
}
