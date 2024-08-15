using QuartzInjectionExample.App.Interface;
using QuartzInjectionExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzInjectionExample.App.Services
{
    public class SMSService : ISender
    {
        public void Send(Customer customer, string message)
        {
            message = message + $"/{customer.phone}, by sms.";
            Console.WriteLine(message);
        }
    }

}
