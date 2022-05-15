using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {

        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();

            command.FirstName = "Andre";
            command.LastName = "Baltieri";
            command.Document = "32052022258";
            command.Email = "hello@balta.io";
            command.Phone = "11969445574";

            Assert.AreEqual(true, command.Valid());
        }


    }
}
