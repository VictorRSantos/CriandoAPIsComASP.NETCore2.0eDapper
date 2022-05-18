using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Input;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BaltaStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _handler;

        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
            
        }

        [HttpGet]
        [Route("v1/customers")]
        [ResponseCache(Duration = 60)]
        public IEnumerable<ListCustomerQueryResult> Get() =>  _repository.Get();
        

        [HttpGet]
        [Route("v1/customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id) =>  _repository.Get(id);
        
        [HttpGet]
        [Route("v2/customers/{document}")]
        public GetCustomerQueryResult GetByDocument(Guid document) =>  _repository.Get(document);



        [HttpGet]
        [Route("v1/customer/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id) => _repository.GetOrders(id);
     

        [HttpPost]
        [Route("v1/customers")]
        public object Post([FromBody] CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult)_handler.Handle(command);
            if (_handler.Invalid)
                return BadRequest(_handler.Notifications);
            return result;
        }

        [HttpPut]
        [Route("v1/customers/{id}")]
        public Customer Put([FromBody] CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);

            return customer;
        }

        [HttpDelete]
        [Route("v1/customers/{id}")]
        public object Delete()
        {
            return new {message = "Cliente removido com sucesso!" };
        }
  
    
    }
}
