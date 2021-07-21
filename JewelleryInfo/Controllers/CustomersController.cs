using JewelleryInfo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace JewelleryInfo.Controllers
{
    public class CustomersController : Controller
    {

        [HttpGet]
        public List<Customer> GetCustomers()
        {
            CustomerService customerService = new CustomerService();
            return customerService.GetAllCustomers();
        }

        public ActionResult Create(CustomerViewModel customer, string s)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerViewModel customer)
        {
            Customer customer1 = GetCustomers().ToList().Where(x => x.Username == customer.Username && x.Password == customer.Password).FirstOrDefault();
            if (customer1 != null)
            {
                customer.Username = customer1.Username;
                customer.Password = customer1.Password;
                customer.Customertype = customer1.Customertype;
                return RedirectToAction("Home", customer);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid credentials");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Home(CustomerViewModel goldDetails)
        {
            goldDetails.GoldPrice = 4900;
            if (goldDetails.Customertype == "Privileged")
            {
                goldDetails.Discount = 2;
                ViewBag.Discount = goldDetails.Discount;
                return View(goldDetails);
            }            
            return View(goldDetails);
        }

        [HttpPost]
        public ActionResult Home(CustomerViewModel goldDetails, string s)
        {
            if (goldDetails.Customertype == "General")
            {
                if (goldDetails.Discount == 0)
                {
                    goldDetails.TotalPrice = goldDetails.Weight * goldDetails.GoldPrice;
                }
            }
            else
            {
                if (goldDetails.Customertype == "Privileged")
                {
                    goldDetails.Discount = 2;
                    double discount = (goldDetails.Weight * goldDetails.GoldPrice * goldDetails.Discount) / 100;
                    goldDetails.TotalPrice = goldDetails.Weight * goldDetails.GoldPrice - discount;
                }
                
            }
            return RedirectToAction("Home", goldDetails);
        }

        public ActionResult Cancel()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();
            return RedirectToAction("Create", customerViewModel);
        }

    }
}