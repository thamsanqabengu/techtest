using System.Collections.Generic;

namespace AnyCompany
{
    public class OrderService
    {
        private readonly OrderRepository orderRepository = new OrderRepository();

        public OrderObjects OrdersGet()
        {
            List<Orders> _orders = new List<Orders>();
            OrderMessages _message = new OrderMessages();

            var _returnObject = orderRepository.OrdersGet();

            _orders = _returnObject._orders;

            return new OrderObjects()
            {
                _orders = _orders,
                _orderMessages = _message
            };
        }
        public OrderObjects PlaceOrder(OrderModify order)
        {
            List<Orders> _orders = new List<Orders>();
            OrderMessages _message = new OrderMessages();

            var _returnObject = orderRepository.OrdersModify(order);

            _orders = _returnObject._orders;

            return new OrderObjects()
            {
                _orders = _orders,
                _orderMessages = _message
            };
        }
    }
}
