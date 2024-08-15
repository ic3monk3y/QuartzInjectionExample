using QuartzInjectionExample.App.Interface;
using QuartzInjectionExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzInjectionExample.App.Services
{
    public class CustomerService
    {
        private IRepository _repository;

        public CustomerService(IRepository repository)
        {
            _repository = repository;
        }

        public List<Customer> GetCustomers()
        {
            return _repository.GetCustomers();
        }
    }

}
