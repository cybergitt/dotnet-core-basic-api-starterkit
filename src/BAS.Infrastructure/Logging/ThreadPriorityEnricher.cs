using Serilog.Core;
using Serilog.Events;

namespace BAS.Infrastructure.Logging
{
    public class ThreadPriorityEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(
                propertyFactory.CreateProperty("ThreadPriority", Thread.CurrentThread.Priority.ToString())
            );
        }
    }
}
