using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace JewelleryInfo.Models
{
    public class CustomerService
    {
        public List<Customer> GetAllCustomers()
        {
            string xmlData = HttpContext.Current.Server.MapPath("~/App_Data/CustomerData.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(xmlData);
            var products = new List<Customer>();
            products = (from rows in ds.Tables[0].AsEnumerable()
                        select new Customer
                        {
                            CustomerId = Convert.ToInt32(rows[0].ToString()),
                            Username = rows[1].ToString(),
                            Customertype = rows[2].ToString(),
                            Password = rows[3].ToString(),
                        }).ToList();
            return products;
        }
    }
}
