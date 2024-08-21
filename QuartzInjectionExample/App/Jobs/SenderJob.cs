using Quartz;
using QuartzInjectionExample.App.Funct;
using QuartzInjectionExample.App.Interface;
using QuartzInjectionExample.App.Repositories;
using QuartzInjectionExample.App.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuartzInjectionExample.Models;

namespace QuartzInjectionExample.App.Jobs
{
    public class SenderJob : IJob
    {
        private readonly ISender _sender;
        private CustomerService customerService;
        private CustomerRepository repository;
        //private MySQLConnection connection;
        private OracleConnection connection;
        private string message;
        private List<Customer> customers;
        

        public SenderJob(ISender sender)
        {
            _sender = sender;

            //connection = new MySQLConnection();
            connection = new OracleConnection();
            repository = new CustomerRepository(connection);
            customerService = new CustomerService(repository);
        }

        public Task Execute(IJobExecutionContext context)
        {
            customers = customerService.GetCustomers();

            foreach (var customer in customers)
            {
                message = $"Message sent to {customer.name}";
                _sender.Send(customer, message);
            }

            return Task.CompletedTask;
        }
    }
}
