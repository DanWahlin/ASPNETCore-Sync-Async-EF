using ASPNETCore_Sync_Async_EF.Models;
using ASPNETCore_Sync_Async_EF.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASPNETCore_Sync_Async_EF.Apis
{
    [Route("api/async/customers")]
    [EnableCors("AllowAnyOrigin")]
    public class CustomersApiControllerAsync : Controller
    {
        ICustomersRepositoryAsync _CustomersRepository;
        ILogger _Logger;

        public CustomersApiControllerAsync(ICustomersRepositoryAsync customersRepo, ILoggerFactory loggerFactory)
        {
            _CustomersRepository = customersRepo;
            _Logger = loggerFactory.CreateLogger(nameof(CustomersApiController));
        }

        // GET api/async/customers
        [HttpGet]
        public async Task<ActionResult> Customers()
        {
            try
            {
                var customers = await _CustomersRepository.GetCustomersAsync();
                return Ok(customers);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new { Status = false });
            }
        }

        // GET api/async/customers/page/10/10
        [HttpGet("page/{skip}/{take}")]
        public async Task<ActionResult> CustomersPage(int skip, int take)
        {
            try
            {
                var pagingResult = await _CustomersRepository.GetCustomersPageAsync(skip, take);
                Response.Headers.Add("X-InlineCount", pagingResult.TotalRecords.ToString());
                return Ok(pagingResult.Records);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new { Status = false });
            }
        }

        // GET api/async/customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Customers(int id)
        {
            try
            {
                var customer = await _CustomersRepository.GetCustomerAsync(id);
                return Ok(customer);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new { Status = false });
            }
        }
    }
}
