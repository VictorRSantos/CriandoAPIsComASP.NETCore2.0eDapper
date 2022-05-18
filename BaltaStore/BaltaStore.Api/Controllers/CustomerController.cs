using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Input;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BaltaStore.Api.Controllers
{
    public class CustomerController : Controller
    {

        [HttpGet]
        [Route("customers")]
        public List<Customer> Get()
        {
            var name = new Name("André", "Baltieri");
            var document = new Document("46718115533");
            var email = new Email("hello@balta.io");
            var customer = new Customer(name, document, email, "551441425");

            var customers = new List<Customer>();
            customers.Add(customer);
            return customers;
        }

        [HttpGet]
        [Route("customers/{id}")]
        public Customer GetById(Guid id)
        {
            var name = new Name("André", "Baltieri");
            var document = new Document("46718115533");
            var email = new Email("hello@balta.io");
            var customer = new Customer(name, document, email, "551441425");

            return customer;
        }

        [HttpGet]
        [Route("customer/{id}/orders")]
        public List<Order> GetOrders(Guid id)
        {
            var name = new Name("André", "Baltieri");
            var document = new Document("46718115533");
            var email = new Email("hello@balta.io");
            var customer = new Customer(name, document, email, "551441425");
            var order = new Order(customer);
            
            var mouse = new Product("Mouse Gamer", "Mouse Gamer", "mouse.jpg", 100M, 10);       
            var monitor = new Product("Monitor Gamer", "Monitor Gamer", "monitor.jpg", 100M, 10);

            order.AddItem(monitor, 5);
            order.AddItem(mouse, 5);

            var orders = new List<Order>();
            orders.Add(order);

            return orders;
        }


        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody] CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);         

            return customer;
        }

        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody] CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);

            return customer;
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public object Delete()
        {
            return new {message = "Cliente removido com sucesso!" };
        }
    }
}
