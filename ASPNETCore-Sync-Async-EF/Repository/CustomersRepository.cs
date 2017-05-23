using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using ASPNETCore_Sync_Async_EF.Models;

namespace ASPNETCore_Sync_Async_EF.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly CustomersDbContext _Context;
        private readonly ILogger _Logger;

        public CustomersRepository(CustomersDbContext context, ILoggerFactory loggerFactory)
        {
            _Context = context;
            _Logger = loggerFactory.CreateLogger("CustomersRepository");
        }

        public List<Customer> GetCustomers()
        {
            return _Context.Customers.OrderBy(c => c.LastName)
                                 .ToList();
        }

        public PagingResult<Customer> GetCustomersPage(int skip, int take)
        {
            var totalRecords = _Context.Customers.Count();
            var customers = _Context.Customers
                                 .OrderBy(c => c.LastName)
                                 .Skip(skip)
                                 .Take(take)
                                 .ToList();
            return new PagingResult<Customer>(customers, totalRecords);
        }

        public Customer GetCustomer(int id)
        {
            return _Context.Customers
                                 .SingleOrDefault(c => c.Id == id);
        }

    }
}
