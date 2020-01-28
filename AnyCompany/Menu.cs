using System;

namespace AnyCompany
{
    public class Menu
    {
        public int MenuItemId { get; set; }
        public string MenuItem { get; set; }
        public Menu(int _MenuItemId, string _MenuItem)
        {
            MenuItemId = _MenuItemId;
            MenuItem = _MenuItem;
        }
    }
    public class MenuItemModify
    {
		public int MenuItemId { get; set; }
		public string MenuItem { get; set; }
    }
}
