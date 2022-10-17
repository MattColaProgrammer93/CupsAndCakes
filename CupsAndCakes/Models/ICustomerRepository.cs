using CupsAndCakes.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace CupsAndCakes.Models
{
    public interface ICustomerRepository
    {
        Task SaveCustomer(Customer customer);
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task DeleteCustomer(int customerId);
        Task UpdateCustomer(Customer customer);
        Task<Customer> GetCustomer(int customerId);
    }

    public class CustomerRepository : ICustomerRepository
    {
        private ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context )
        {
            _context = context;
        }

        public async Task DeleteCustomer(int customerId)
        {
            Customer? customer = await GetCustomer(customerId);

            if (customer != null)
            {
                // Change all related orders to a null customer
                using DbConnection con = _context.Database.GetDbConnection();
                await con.OpenAsync();
                using DbCommand query = con.CreateCommand();
                query.CommandText = "UPDATE Orders SET PersonId = null WHERE PersonId = " + customer.Id;
                int rowsAffected = await query.ExecuteNonQueryAsync();

                // Remove customer from database
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _context.Customers.OrderBy(customer => customer.FullName).ToListAsync();
        }

        public async Task<Customer?> GetCustomer(int customerId)
        {
            return await _context.Customers.SingleOrDefaultAsync(i => i.Id == customerId);
        }

        public async Task SaveCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomer(Customer customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
        }
    }
}
