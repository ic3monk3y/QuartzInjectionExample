using QuartzInjectionExample.App.Interface;
using QuartzInjectionExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzInjectionExample.App.Services
{
    public class CommunicationService
    {
        private ISender _sender;

        public CommunicationService(ISender sender)
        {
            _sender = sender;
        }

        public void SendMessage(Customer customer, string message)
        {
            _sender.Send(customer, message);
        }
    }

}
