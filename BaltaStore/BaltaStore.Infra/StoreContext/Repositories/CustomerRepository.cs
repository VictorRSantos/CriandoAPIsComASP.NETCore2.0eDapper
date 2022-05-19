using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Infra.StoreContext.DataContexts;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BaltaStore.Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BaltaDataContext _context;

        public CustomerRepository(BaltaDataContext context)
        {
            _context = context;
        }

        public bool CheckDocument(string document) =>
         _context.Connection.Query<bool>("spCheckDocument", new { Document = document },
             commandType: CommandType.StoredProcedure).FirstOrDefault();

        public bool CheckEmail(string email) =>
            _context.Connection.Query<bool>("spCheckEmail", new { Email = email },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

        public IEnumerable<ListCustomerQueryResult> Get() =>
         _context.Connection.Query<ListCustomerQueryResult>("SELECT [Id],CONCAT([FistName],' ', [LastName]) AS Name, Document FROM [Customer]");

        public GetCustomerQueryResult Get(Guid id) =>
             _context.Connection.Query<GetCustomerQueryResult>
            ("SELECT [Id],CONCAT([FistName],' ', [LastName]) AS Name, Document FROM [Customer] WHERE [Id]=@id", new {Id = id }).FirstOrDefault();

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document) =>
            _context.Connection.Query<CustomerOrdersCountResult>("spGetCustomerOrdersCount", new { Document = document },
              commandType: CommandType.StoredProcedure).FirstOrDefault();

        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id) =>
                _context.Connection.Query<ListCustomerOrdersQueryResult>
            ("", new { Id = id });

        public void Save(Customer customer)
        {

            _context.Connection.Execute("spCreateCustomer", new
            {
                Id = customer.Id,
                FirstName = customer.Name.FirstName,
                LastName = customer.Name.LastName,
                Document = customer.Document.Number,
                Email = customer.Email.Address,
                Phone = customer.Phone,
            }, commandType: CommandType.StoredProcedure);

            foreach (var address in customer.Addresses)
            {
                _context.Connection.Execute("spCreateAddress", new
                {
                    Id = address.Id,
                    CustomerId = customer.Id,
                    Number = address.Number,
                    Complement = address.Complement,
                    District = address.District,
                    City = address.City,
                    State = address.State,
                    Country = address.Country,
                    ZipCode = address.ZipCode,
                    Type = address.Type
                }, commandType: CommandType.StoredProcedure);

            }


        }
    }
}
