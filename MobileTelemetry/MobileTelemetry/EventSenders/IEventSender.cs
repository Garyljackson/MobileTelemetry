﻿using System.Threading.Tasks;

namespace MobileTelemetry.EventSenders
{
    public interface IEventSender<in T>
    {
        Task SendEvent(T data);
    }
}