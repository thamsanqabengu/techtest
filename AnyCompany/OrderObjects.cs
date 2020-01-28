using System;
using System.Collections.Generic;

namespace AnyCompany
{
	public class OrderObjects
	{
		public List<Customer> _customer { get; set; }
		public List<Menu> _menu { get; set; }
		public List<Orders> _orders { get; set; }
		public OrderMessages _orderMessages { get; set; }
	}
}
