using Biblioflash.Manager.Services;
using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiblioFlash_UI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainAsync().Wait(); //Se ejecuta de manera asincrónica la task "MainAsync" notificando a los usuarios correspondientes
            Application.Run(new Form1());
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
            // Trigger the job to run now, and then every 24 hours
            ITrigger CadaDiaTrigger1 = TriggerBuilder.Create()
                .WithIdentity("Cada24HorasreportePorVencerTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInHours(24)
                    .RepeatForever())
            .Build();

            await scheduler.ScheduleJob(reportePorVencerJob, CadaDiaTrigger1);  //Llamada a la ejecución del scheduler
        }
    }
}
