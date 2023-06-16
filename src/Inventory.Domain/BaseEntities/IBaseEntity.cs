namespace Inventory.Domain.BaseEntities
{
	public interface IBaseEntity<TKey>
	{
		TKey Id { get; set; }
	}
}
