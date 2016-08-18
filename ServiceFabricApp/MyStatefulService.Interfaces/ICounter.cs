
namespace MyStatefulService.Interfaces
{
    using Microsoft.ServiceFabric.Services.Remoting;
    using System.Threading.Tasks;

    public interface ICounter : IService
    {
        Task<long> GetCountAsync();
    }
}
