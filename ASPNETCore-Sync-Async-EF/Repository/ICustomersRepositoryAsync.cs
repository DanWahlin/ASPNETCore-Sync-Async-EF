using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using ASPNETCore_Sync_Async_EF.Models;

namespace ASPNETCore_Sync_Async_EF.Repository
{
    public interface ICustomersRepositoryAsync
    {     
        Task<List<Customer>> GetCustomersAsync();
        Task<PagingResult<Customer>> GetCustomersPageAsync(int skip, int take);
        Task<Customer> GetCustomerAsync(int id);
    }
}