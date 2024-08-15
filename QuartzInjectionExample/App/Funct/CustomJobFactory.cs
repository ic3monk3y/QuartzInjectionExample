using Quartz.Spi;
using Quartz;
using System;
using System.Collections.Generic;

namespace QuartzInjectionExample.App.Funct
{
    public class CustomJobFactory : IJobFactory
    {
        private readonly IDictionary<Type, Func<IJob>> _jobFactory;

        public CustomJobFactory(IDictionary<Type, Func<IJob>> jobFactory)
        {
            _jobFactory = jobFactory;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            var jobType = bundle.JobDetail.JobType;
            if (_jobFactory.TryGetValue(jobType, out var factory))
            {
                return factory();
            }

            throw new InvalidOperationException("No factory registered for job type " + jobType);
        }

        public void ReturnJob(IJob job) { }

    }
}
