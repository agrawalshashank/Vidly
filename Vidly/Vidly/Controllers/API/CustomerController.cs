using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomerController : ApiController
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

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customer.ToList();
        }

        public Customer GetCustomer(int id)
        {
            var customer = _context.Customer.SingleOrDefault(x => x.Id == id);

            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return customer;
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _context.Customer.Add(customer);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(Customer customer)
        {
            var customerData = _context.Customer.Single(x => x.Id == customer.Id);

            if (customerData == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            customerData.Name = customer.Name;
            customerData.IsNewsLetterSubscribed = customer.IsNewsLetterSubscribed;

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customer.Single(x => x.Id == id);

            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customer.Remove(customer);
            _context.SaveChanges();

            return Ok();
        }
    }

}
