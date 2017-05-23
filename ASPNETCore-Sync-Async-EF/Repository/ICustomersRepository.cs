using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using ASPNETCore_Sync_Async_EF.Models;

namespace ASPNETCore_Sync_Async_EF.Repository
{
    public interface ICustomersRepository
    {     
        List<Customer> GetCustomers();
        PagingResult<Customer> GetCustomersPage(int skip, int take);
        Customer GetCustomer(int id);
    }
}