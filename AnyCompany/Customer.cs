using System;

namespace AnyCompany
{
    public class CustomerModify
    {
		public int CustomerId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string EmailAddress { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Country { get; set; }
		public bool IsActive { get; set; }
		public bool CreateDate { get; set; }
	}
	public class Customer
	{
		public int CustomerId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string EmailAddress { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Country { get; set; }
		public bool IsActive { get; set; }
		public bool CreateDate { get; set; }
	}
}
