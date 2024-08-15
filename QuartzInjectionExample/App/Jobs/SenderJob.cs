using Quartz;
using QuartzInjectionExample.App.Funct;
using QuartzInjectionExample.App.Interface;
using QuartzInjectionExample.App.Repositories;
using QuartzInjectionExample.App.Services;
using System.Threading.Tasks;

namespace QuartzInjectionExample.App.Jobs
{
    public class SenderJob : IJob
    {
        private readonly ISender _sender;
        private CustomerService customerService;
        private string message;

        public SenderJob(ISender sender)
        {
            _sender = sender;

            var connection = new MySQLConnection();
            //var connection = new OracleConnection();
            var repository = new CustomerRepository(connection);
            customerService = new CustomerService(repository);
        }

        public Task Execute(IJobExecutionContext context)
        {
            var customers = customerService.GetCustomers();

            foreach (var customer in customers)
            {
                message = $"Message sent to {customer.name}";
                _sender.Send(customer, message);
            }

            return Task.CompletedTask;
        }
    }
}
