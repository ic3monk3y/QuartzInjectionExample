﻿using QuartzInjectionExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzInjectionExample.App.Interface
{
    public interface ISender
    {
        void Send(Customer customer, string message);
    }
}
