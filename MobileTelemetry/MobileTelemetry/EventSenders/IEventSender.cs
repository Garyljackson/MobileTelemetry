using System.Threading.Tasks;

namespace MobileTelemetry.EventSenders
{
    public interface IEventSender<T>
    {
        Task SendEvent(T data);
    }
}