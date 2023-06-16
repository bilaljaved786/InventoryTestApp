using System;
using Inventory.Domain.BaseEntities;

namespace Inventory.Domain.Entities
{
	public class Inventory: UpdateableEntity<Guid>, IBaseEntity<Guid>
	{
		private Inventory(Guid id) => this.Id = id;

		#region Columns

		public Guid Id { get; set; }
		public string Name { get; private set; }
		public string Barcode { get; private set; }
		public string Description { get; private set; }
		public string CategoryName { get; private set; }
		public bool Weighted { get; private set; }
		public int ProductStatus { get; private set; }

		#endregion

		public static Inventory Create(string name,string barcode,string description,string categoryName,bool weighted,int productStatus)
		  => new Inventory(Guid.NewGuid())
		  {
			  Name = name,
			  Barcode = barcode,
			  Description = description,
			  CategoryName = categoryName,
			  Weighted = weighted,
			  ProductStatus = productStatus
		  };

		#region DomainLogic

		public void SellProduct(int soldStatus)
			=> (ProductStatus) = (soldStatus);

		public void UpdateProduct(int productStatus)
			=> (ProductStatus) = (productStatus);
		#endregion
	}
}
