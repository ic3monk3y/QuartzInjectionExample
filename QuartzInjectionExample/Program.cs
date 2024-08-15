using Quartz.Impl;
using Quartz;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuartzInjectionExample.App.Jobs;
using QuartzInjectionExample.App.Services;
using QuartzInjectionExample.App.Funct;

namespace QuartzInjectionExample
{
    internal class Program
    {

        static async Task Main(string[] args)
        {

            #region Dependencias
            var jobFactory = new Dictionary<Type, Func<IJob>>
            {
                //{ typeof(SenderJob), () => new  SenderJob(new EmailService()) }
                { typeof(SenderJob), () => new  SenderJob(new SMSService()) }
            };
            #endregion Dependencias

            #region SchedulerTrigger
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();

            var scheduler = await schedulerFactory.GetScheduler();
            scheduler.JobFactory = new CustomJobFactory(jobFactory);
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<SenderJob>()
                                       .WithIdentity("myJob", "group1")
                                       .Build();

            ITrigger trigger = TriggerBuilder.Create()
                                             .WithIdentity("myTrigger", "group1")
                                             .StartNow()
                                             .WithSimpleSchedule(x => x
                                                 .WithIntervalInSeconds(5)
                                                 .RepeatForever())
                                             .Build();
            #endregion SchedulerTrigger

            await scheduler.ScheduleJob(job, trigger);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            await scheduler.Shutdown();
        }

    }
}
