using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AnyCompany
{
    public static class CustomerRepository
    {
        private static string ConnectionString = @"Data Source=(local);Database=Customers;User Id=admin;Password=password;";


        //public OrderObjects CustomerModify(CustomerModify _customer)
        //{
        //    List<Customer> _customers = new List<Customer>();
        //    OrderMessages _message = new OrderMessages();

        //    SqlCommand command = new SqlCommand();
        //    DataSet ds = new DataSet();

        //    try
        //    {

        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Connection = new SqlConnection(ConnectionString);
        //        command.CommandText = "CustomerModify";

        //        command.Parameters.Add("@CustomerId", SqlDbType.Int).Value = _customer.CustomerId;
        //        command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = _customer.FirstName;
        //        command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = _customer.LastName;
        //        command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = _customer.PhoneNumber;
        //        command.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = _customer.EmailAddress;
        //        command.Parameters.Add("@DateOfBirth", SqlDbType.SmallDateTime).Value = _customer.DateOfBirth;
        //        command.Parameters.Add("@Country", SqlDbType.VarChar).Value = _customer.Country;
        //        command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = _customer.IsActive;
        //        command.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = _customer.CreateDate;


        //        SqlDataAdapter da = new SqlDataAdapter(command);

        //        da.Fill(ds, "Customers");

        //        da.Dispose();

        //        if (ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                _customers.Add(new Customer(
        //                    ));
        //            }
        //            else
        //            {
        //                _message.ErrorMessage = "Customers could not be found.";
        //            }

        //            _message.ErrorMessage = "Customers found.";
        //        }
        //        else
        //        {
        //            _message.ErrorMessage = "Customers could not be found.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _message.ErrorMessage = _message.ErrorMessage + " - Exception: " + ex.Message.ToString();
        //    }

        //    return new OrderObjects()
        //    {
        //        _customer = _customers,
        //        _orderMessages = _message
        //    };
        //}
        //public OrderObjects CustomersGet()
        //{
        //    List<Customer> _customers = new List<Customer>();
        //    OrderMessages _message = new OrderMessages();

        //    SqlCommand command = new SqlCommand();
        //    DataSet ds = new DataSet();

        //    try
        //    {

        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Connection = new SqlConnection(ConnectionString);
        //        command.CommandText = "CustomerGet";

        //        SqlDataAdapter da = new SqlDataAdapter(command);

        //        da.Fill(ds, "Customers");

        //        da.Dispose();

        //        if (ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                _customers.Add(new Customer(
        //                    ));
        //            }
        //            else
        //            {
        //                _message.ErrorMessage = "Orders could not be found.";
        //            }

        //            _message.ErrorMessage = "Orders found.";
        //        }
        //        else
        //        {
        //            _message.ErrorMessage = "Orders could not be found.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _message.ErrorMessage = _message.ErrorMessage + " - Exception: " + ex.Message.ToString();
        //    }

        //    return new OrderObjects()
        //    {
        //        _customer = _customers,
        //        _orderMessages = _message
        //    };
        //}
    }
}
