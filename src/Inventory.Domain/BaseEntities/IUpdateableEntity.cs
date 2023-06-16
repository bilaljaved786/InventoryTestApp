using System;
namespace Inventory.Domain.BaseEntities
{
	public class UpdateableEntity<TKey> where TKey : struct
	{
		TKey CreatedBy { get; set; }

		DateTime CreatedAt { get; set; }

		TKey? UpdatedBy { get; set; }

		DateTime? UpdatedAt { get; set; }
	}
}
