using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IKafkaService
    {
        Task ProduceMessageAsync(string topic, string message);
        Task<string> ConsumeMessageAsync(string topic, string groupId);
    }
}
