using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace Biblioflash.Manager.Services
{
    public class SimpleJob : IJob
    {
        Fachada fachada = new Fachada();
        public Task Execute(IJobExecutionContext context)
        {
            fachada.notificarUsuarios();
            return null;
        }
    }
}
