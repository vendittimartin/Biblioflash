using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioflash.Manager.DAL.EntityFramework;
using Quartz;
using Quartz.Impl;
using Biblioflash.Manager.Services;
using Biblioflash.Manager.Log;

namespace Biblioflash
{
    public class Program
    {

        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
            Log oLog = new Log(@"C:\Users\vendi\source\repos\Biblioflash\Biblioflash\Manager\Log");
            oLog.Add($"prueba pa ver si anda el main");
        }

        static async Task MainAsync()
        {
            // construct a scheduler factory using defaults
            StdSchedulerFactory factory = new StdSchedulerFactory();

            // get a scheduler
            IScheduler scheduler = await factory.GetScheduler();
            await scheduler.Start();

            // define the job and tie it to our ReportePorVencerJob class
            IJobDetail reportePorVencerJob = JobBuilder.Create<SimpleJob>()
                .WithIdentity("ReportePorVencerJob", "group1")
                .Build();
            // Trigger the job to run now, and then every 40 seconds
            ITrigger CadaDiaTrigger1 = TriggerBuilder.Create()
                .WithIdentity("Cada24HorasreportePorVencerTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInHours(24)
                    .RepeatForever())
            .Build();

            await scheduler.ScheduleJob(reportePorVencerJob, CadaDiaTrigger1);

        }
    }
}