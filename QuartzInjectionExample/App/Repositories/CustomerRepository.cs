using QuartzInjectionExample.App.Funct;
using QuartzInjectionExample.App.Interface;
using QuartzInjectionExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzInjectionExample.App.Repositories
{
    public class CustomerRepository : IRepository
    {
        private IDbConnection _connection;

        public CustomerRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public List<Customer> GetCustomers()
        {
            if (_connection.GetType() == typeof(MySQLConnection)) Console.WriteLine("Get Customers from MySQL");
            else if (_connection.GetType() == typeof(OracleConnection)) Console.WriteLine("Get Customers from Oracle");

            return new List<Customer>
            {
                new Customer () {id = 1, name = "Juan Escutia", email = "juanescutia@gmail.com", phone = "3311223344"},
                new Customer () {id = 1, name = "Maribel Guardia", email = "maribelguardia@gmail.com", phone = "3344332211"}
            };
        }
    }

}
