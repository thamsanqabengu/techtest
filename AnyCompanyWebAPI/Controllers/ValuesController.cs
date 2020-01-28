using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AnyCompany;

namespace AnyCompany.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly OrderService orderService = new OrderService();

        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        public OrderObjects Get()
        {
            List<Orders> _orders = new List<Orders>();
            OrderMessages _message = new OrderMessages();

            var _returnObject = orderService.OrdersGet();

            _orders = _returnObject._orders;
            return new OrderObjects()
            {
                _orders = _orders,
                _orderMessages = _message
            };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
