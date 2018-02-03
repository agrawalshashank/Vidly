using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) 
        {
            _context.Dispose();
        }
        //
        // GET: /Customer/
        public ActionResult Customer()
        {
            var customer = _context.Customer.Include(c => c.MembershipType).ToList();
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customer.SingleOrDefault(x => x.Id == id);
            var membershipType = _context.MembershipType.ToList();

            var editCustomer = new CustomerViewModel
            {
                Customer = customer,
                MembershipType = membershipType
            };

            return View(editCustomer);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customer.SingleOrDefault(x => x.Id == id);
            return View(customer);
        }

        public ActionResult Create()
        {
            var membershipData = _context.MembershipType.ToList();

            var customerDataViewModel = new CustomerViewModel
            {
                MembershipType = membershipData,

            };

            return View(customerDataViewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customer.Add(customer);
            }
            else
            {
                var updateCustomer = _context.Customer.Single(x => x.Id == customer.Id);

                updateCustomer.Name = customer.Name;
                updateCustomer.IsNewsLetterSubscribed = customer.IsNewsLetterSubscribed;
                updateCustomer.DateOfBirth = customer.DateOfBirth;
                updateCustomer.MembershipTypeId = customer.MembershipTypeId;

            }
            int value = _context.SaveChanges();

            if (value > 1)
            {

            }

            return RedirectToAction("Customer", "Customer");
        }
    }
}