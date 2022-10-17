using CupsAndCakes.Data;

namespace CupsAndCakes.Models
{
    public interface ICustomerRepository
    {
        void SaveCustomer(Customer customer);
        IEnumerable<Customer> GetAllCustomers();
        void DeleteCustomer(int customerId);
        void UpdateCustomer(Customer customer);
        Customer GetCustomer(int customerId);
    }

    public class CustomerRepository : ICustomerRepository
    {
        private ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context )
        {
            _context = context;
        }

        public void DeleteCustomer(int customerId)
        {
            Customer customer = GetCustomer(customerId);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int customerId)
        {
            return _context.Customers.SingleOrDefault(i => i.Id == customerId);
        }

        public void SaveCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
