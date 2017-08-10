using AutoMapper;
using Core;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web.Controllers.Api.Resources;

namespace Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CustomersController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customers = _unitOfWork.Customers.GetAll();

            var customerResouces = _mapper.Map<IEnumerable<CustomerResource>>(customers);
            return Ok(customerResouces);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customer = _unitOfWork.Customers.Get(id);

            if (customer == null)
                return NotFound();

            var customerResource = _mapper.Map<CustomerResource>(customer);
            return Ok(customerResource);
        }
        [HttpGet("{id}/Details")]
        public IActionResult GetCustomerWithProducts(int id)
        {
            var customer = _unitOfWork.Customers.GetWithProducts(id);

            if (customer == null)
                return NotFound();

            var customerResource = _mapper.Map<CustomerResource>(customer);
            return Ok(customerResource);
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerResource customerResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = _mapper.Map<Customer>(customerResource);
            _unitOfWork.Customers.Add(customer);
            _unitOfWork.Complete();

            customer = _unitOfWork.Customers.Get(customer.Id);

            var result = _mapper.Map<CustomerResource>(customer);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerResource customerResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = _unitOfWork.Customers.Get(id);

            if (customer == null)
                return NotFound();

            _mapper.Map(customerResource, customer);
            _unitOfWork.Complete();

            customer = _unitOfWork.Customers.Get(id);

            var result = _mapper.Map<CustomerResource>(customer);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _unitOfWork.Customers.Get(id);

            if (customer == null)
                return NotFound();

            _unitOfWork.Customers.Remove(customer);
            _unitOfWork.Complete();

            var result = _mapper.Map<CustomerResource>(customer);
            return Ok(result);
        }
    }
}