using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Input;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Tests.Handlers
{
    [TestClass]
    public class CustomerHanlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();

            command.FirstName = "Andre";
            command.LastName = "Baltieri";
            command.Document = "32052022258";
            command.Email = "hello@balta.io";
            command.Phone = "11969445574";

            Assert.AreEqual(true, command.Valid());


            var hanlder = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());

        }
    }
}
