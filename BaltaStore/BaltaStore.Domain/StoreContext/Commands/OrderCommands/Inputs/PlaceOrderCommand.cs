using BaltaStore.Domain.StoreContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand
    {
        public Guid Customer { get; set; }

        public IList<OrderItemCommand> OrderItems { get; set; }


    }

    public class OrderItemCommand {

        public Guid Product { get; set; }

        public decimal Quantity { get; set; }
    }
}
