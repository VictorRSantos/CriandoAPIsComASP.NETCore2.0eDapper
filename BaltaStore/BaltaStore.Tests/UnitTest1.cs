using BaltaStore.Domain.StoreContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new Customer("Andre", "Baltieri", "1234567811", "hello@balta.io", "1999999999", "Rua dos Developers, 1024");

            var order = new Order(c);

           


        }
    }
}
