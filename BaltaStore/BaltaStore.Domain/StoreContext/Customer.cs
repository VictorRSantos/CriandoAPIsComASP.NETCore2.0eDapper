using System;

namespace BaltaStore.Domain.StoreContext
{
    public class Customer
    {

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Salary { get; set; }

        // Metodos
        public void Register() { }

        // Eventos
        public void AoRegistrar() { }

    }

}