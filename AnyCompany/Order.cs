using System;

namespace AnyCompany
{
	public class Orders
	{
		public int OrderId { get; set; }
		public int CustomerId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string EmailAddress { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Country { get; set; }
		public int MenuItemId { get; set; }
		public string MenuItem { get; set; }
		public decimal Amount { get; set; }
		public decimal VAT { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreateDate { get; set; }

		public Orders(int _OrderId , int _CustomerId, string _FirstName, string _LastName, string _PhoneNumber, 
			string _EmailAddress, DateTime _DateOfBirth, string _Country, int _MenuItemId, string _MenuItem,
			decimal _Amount, decimal _VAT, bool _IsActive, DateTime _CreateDate)
		{
			OrderId = _OrderId;
			CustomerId = _CustomerId;
			FirstName = _FirstName;
			LastName = _LastName;
			PhoneNumber = _PhoneNumber;
			EmailAddress = _EmailAddress;
			DateOfBirth = _DateOfBirth;
			Country = _Country;
			MenuItemId = _MenuItemId;
			MenuItem = _MenuItem;
			Amount = _Amount;
			VAT = _VAT;
			IsActive = _IsActive;
			CreateDate = _CreateDate;
		}
	}
	public class OrderModify
	{
		public int OrderId { get; set; }
		public int CustomerId { get; set; }
		public int MenuItemId { get; set; }
		public decimal Amount { get; set; }
		public decimal VAT { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreateDate { get; set; }
	}
}
