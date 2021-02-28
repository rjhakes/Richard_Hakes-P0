using Model = StoreModels;
using Entity = StoreDL.Entities;
using StoreModels;
using StoreDL.Entities;
namespace StoreDL
{
    public class CustomerMapper : ICustomerMapper
    {
        public Model.Customer ParseCustomer(Entity.Customer customer)
        {
            return new Model.Customer
            {
                CustomerName = customer.CustomerName,
                CustomerEmail = customer.CustomerEmail,
                CustomerPasswordHash = customer.CustomerPasswordHash,
                CustomerPhone = customer.CustomerPhone,
                CustomerAddress = customer.CustomerAddress,
                Id = customer.Id
            };
        }

        public Entity.Customer ParseCustomer(Model.Customer customer)
        {
            if (customer.Id == null)
            {
                return new Entity.Customer
                {
                    CustomerName = customer.CustomerName,
                    CustomerEmail = customer.CustomerEmail,
                    CustomerPasswordHash = customer.CustomerPasswordHash,
                    CustomerPhone = customer.CustomerPhone,
                    CustomerAddress = customer.CustomerAddress,
                };
            }

            return new Entity.Customer
            {
                CustomerName = customer.CustomerName,
                CustomerEmail = customer.CustomerEmail,
                CustomerPasswordHash = customer.CustomerPasswordHash,
                CustomerPhone = customer.CustomerPhone,
                CustomerAddress = customer.CustomerAddress,
                Id = (int)customer.Id
            };
        }
    }
}