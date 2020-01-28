using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AnyCompany
{
    internal class OrderRepository
    {
        private static string ConnectionString = @"Data Source=(local);Database=Orders;User Id=admin;Password=password;";

        public OrderObjects OrdersModify(OrderModify order)
        {
            List<Orders> _orders = new List<Orders>();
            OrderMessages _message = new OrderMessages();

            SqlCommand command = new SqlCommand();
            DataSet ds = new DataSet();

            try
            {

                command.CommandType = CommandType.StoredProcedure;
                command.Connection = new SqlConnection(ConnectionString);
                command.CommandText = "OrderModify";

                command.Parameters.Add("@OrderId", SqlDbType.Int).Value = order.OrderId;
                command.Parameters.Add("@CustomerId", SqlDbType.Int).Value = order.CustomerId;
                command.Parameters.Add("@MenuItemId", SqlDbType.Int).Value = order.MenuItemId;
                command.Parameters.Add("@VAT", SqlDbType.Decimal).Value = order.VAT;
                command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = order.IsActive;
                command.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = order.CreateDate;

                SqlDataAdapter da = new SqlDataAdapter(command);

                da.Fill(ds, "Orders");

                da.Dispose();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        _orders.Add(new Orders(
                            int.Parse(ds.Tables[0].Rows[0]["OrderId"].ToString()),
                            int.Parse(ds.Tables[0].Rows[0]["CustomerId"].ToString()),
                            ds.Tables[0].Rows[0]["FirstName"].ToString(),
                            ds.Tables[0].Rows[0]["LastName"].ToString(),
                            ds.Tables[0].Rows[0]["PhoneNumber"].ToString(),
                            ds.Tables[0].Rows[0]["EmailAddress"].ToString(),
                            Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfBirth"].ToString()),
                            ds.Tables[0].Rows[0]["Country"].ToString(),
                            int.Parse(ds.Tables[0].Rows[0]["MenuItemId"].ToString()),
                            ds.Tables[0].Rows[0]["MenuItem"].ToString(),
                            Convert.ToDecimal(ds.Tables[0].Rows[0]["Amount"].ToString()),
                            Convert.ToDecimal(ds.Tables[0].Rows[0]["VAT"].ToString()),
                            Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"].ToString()),
                            Convert.ToDateTime(ds.Tables[0].Rows[0]["CreateDate"].ToString())
                            ));
                    }
                    else
                    {
                        _message.ErrorMessage = "Orders could not be found.";
                    }

                    _message.ErrorMessage = "Orders found.";
                }
                else
                {
                    _message.ErrorMessage = "Orders could not be found.";
                }
            }
            catch (Exception ex)
            {
                _message.ErrorMessage = _message.ErrorMessage + " - Exception: " + ex.Message.ToString();
            }

            return new OrderObjects()
            {
                _orders = _orders,
                _orderMessages = _message
            };
        }
        public OrderObjects OrdersGet()
        {
            List<Orders> _orders = new List<Orders>();
            OrderMessages _message = new OrderMessages();

            SqlCommand command = new SqlCommand();
            DataSet ds = new DataSet();

            try
            {

                command.CommandType = CommandType.StoredProcedure;
                command.Connection = new SqlConnection(ConnectionString);
                command.CommandText = "OrderGet";

                SqlDataAdapter da = new SqlDataAdapter(command);

                da.Fill(ds, "Order");

                da.Dispose();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        _orders.Add(new Orders(
                            int.Parse(ds.Tables[0].Rows[0]["OrderId"].ToString()),
                            int.Parse(ds.Tables[0].Rows[0]["CustomerId"].ToString()),
                            ds.Tables[0].Rows[0]["FirstName"].ToString(),
                            ds.Tables[0].Rows[0]["LastName"].ToString(),
                            ds.Tables[0].Rows[0]["PhoneNumber"].ToString(),
                            ds.Tables[0].Rows[0]["EmailAddress"].ToString(),
                            Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfBirth"].ToString()),
                            ds.Tables[0].Rows[0]["Country"].ToString(),
                            int.Parse(ds.Tables[0].Rows[0]["MenuItemId"].ToString()),
                            ds.Tables[0].Rows[0]["MenuItem"].ToString(),
                            Convert.ToDecimal(ds.Tables[0].Rows[0]["Amount"].ToString()),
                            Convert.ToDecimal(ds.Tables[0].Rows[0]["VAT"].ToString()),
                            Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"].ToString()),
                            Convert.ToDateTime(ds.Tables[0].Rows[0]["CreateDate"].ToString())
                            ));
                    }
                    else
                    {
                        _message.ErrorMessage = "Orders could not be found.";
                    }

                    _message.ErrorMessage = "Orders found.";
                }
                else
                {
                    _message.ErrorMessage = "Orders could not be found.";
                }
            }
            catch (Exception ex)
            {
                _message.ErrorMessage = _message.ErrorMessage + " - Exception: " + ex.Message.ToString();
            }

            return new OrderObjects()
            {
                _orders = _orders,
                _orderMessages = _message
            };
        }
    }
}
