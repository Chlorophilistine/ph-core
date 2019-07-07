namespace Notes.Controllers.APIv1
{
    using System.Collections.Generic;
    using System.Composition;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using DataAccess.Models;
    using DataAccess.Repositories;
    using Dtos;
    using Microsoft.AspNetCore.Mvc;

    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        [Route(CustomerRoutes.Customers)]
        public async Task<ActionResult<IEnumerable<CustomerSummaryDto>>> GetCustomers()
        {
            var customerSummaries = await _customerRepository
                .GetCustomerSummaries();

            return customerSummaries
                .Select(cs => cs.ToDto())
                .ToArray();
        }

        [HttpGet]
        [Route(CustomerRoutes.Customer)]
        public async Task<ActionResult<CustomerDetailDto>> GetCustomer(int customerId)
        {
            var (result, customer) = await _customerRepository.GetCustomerDetail(customerId);

            if (result is Result.NotFound)
            {
                return NotFound();
            }

            return Ok(customer.ToDto());
        }

        [HttpGet]
        [Route(CustomerRoutes.CustomerNotes)]
        public ActionResult<IEnumerable<NoteDetailDto>> GetNotes(int customerId)
        {
            return _customerRepository
                .GetCustomerNotes(customerId)
                .Select(nd => nd.ToDto())
                .ToArray();
        }

        [HttpPut]
        [Route(CustomerRoutes.StatusUpdate)]
        public async Task<IActionResult> CustomerStatusUpdate(StatusUpdateDto statusUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var (isParsed, status) = statusUpdateDto.Status.TryParse<Status>();
            if (!isParsed)
            {
                return BadRequest("unrecognised status");
            }

            var result = await _customerRepository.UpdateCustomerStatus(statusUpdateDto.CustomerId, status);

            if (result is Result.Completed) return NoContent();

            return NotFound();
        }

        [HttpPost]
        [Route(CustomerRoutes.Customer)]
        public async Task<ActionResult<CustomerDetailDto>> PostCustomer(CustomerDetailDto customerDetailDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var (isParsed, _) = customerDetailDto.Status.TryParse<Status>();
            if (!isParsed)
            {
                return BadRequest("unrecognised status");
            }

            var newCustomerDetail = await _customerRepository.AddCustomer(customerDetailDto.ToModel());

            return CreatedAtRoute("DefaultApi", new { id = newCustomerDetail.Id }, newCustomerDetail.ToDto());
        }

        [HttpDelete]
        [Route(CustomerRoutes.Customer)]
        public async Task<ActionResult<CustomerDetailDto>> DeleteCustomer(int customerId)
        {
            var (result, customer) = await _customerRepository.DeleteCustomer(customerId);

            if (result == Result.Completed)
            {
                return Ok(customer.ToDto());
            }

            return NotFound();
        }
    }
}