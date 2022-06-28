using Quartz;
using System.Threading.Tasks;

namespace Biblioflash.Manager.Services
{
    public class SimpleJob : IJob
    {
        Fachada fachada = new Fachada();
        public Task Execute(IJobExecutionContext context)
        {
            fachada.NotificarUsuarios();
            return null;
        }
    }
}
