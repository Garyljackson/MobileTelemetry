using System.Threading.Tasks;

namespace MobileTelemetry.Abstractions
{
    public interface IHub
    {
        Task SendEvent<T>(T data);
    }
}