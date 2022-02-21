using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioflash.Manager.DAL.EntityFramework;

namespace Biblioflash
{
    class Program
    {
        static void Main(string[] args)
        {
            Fachada fachada = new Fachada();
            // This Scheduler will start at 00:00 and call after every 1 Days
            // IntervalInDays(start_hour, start_minute, days)
            MyScheduler.IntervalInDays(11, 34, 1,
            () => {
                fachada.notificarUsuarios();
            });
        }
    }
}
