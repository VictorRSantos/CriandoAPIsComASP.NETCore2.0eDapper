using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Shared.Commands;
using FluentValidator;
using System;


namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Input
{
    public class AddressCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public EAdressType Type { get; set; }

     

        public bool Valid()
        {
            return IsValid;
        }
    }
}
