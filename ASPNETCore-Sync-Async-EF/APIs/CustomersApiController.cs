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
    [Route("api/customers")]
    [EnableCors("AllowAnyOrigin")]
    public class CustomersApiController : Controller
    {
        ICustomersRepository _CustomersRepository;
        ILogger _Logger;

        public CustomersApiController(ICustomersRepository customersRepo, ILoggerFactory loggerFactory)
        {
            _CustomersRepository = customersRepo;
            _Logger = loggerFactory.CreateLogger(nameof(CustomersApiController));
        }

        // GET api/customers
        [HttpGet]
        public ActionResult Customers()
        {
            try
            {
                var customers = _CustomersRepository.GetCustomers();
                return Ok(customers);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new { Status = false });
            }
        }

        // GET api/customers/page/10/10
        [HttpGet("page/{skip}/{take}")]
        public ActionResult CustomersPage(int skip, int take)
        {
            try
            {
                var pagingResult = _CustomersRepository.GetCustomersPage(skip, take);
                Response.Headers.Add("X-InlineCount", pagingResult.TotalRecords.ToString());
                return Ok(pagingResult.Records);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new { Status = false });
            }
        }

        // GET api/customers/5
        [HttpGet("{id}", Name = "GetCustomerRoute")]
        public ActionResult Customers(int id)
        {
            try
            {
                var customer = _CustomersRepository.GetCustomer(id);
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
