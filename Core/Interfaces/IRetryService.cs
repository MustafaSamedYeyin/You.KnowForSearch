using System;

namespace Core.Interfaces;

public interface IRetryService
{
    Task Retry<T>(Action action);
    Task RetryKafka<T>(Func<string, bool> kafkaMethod, string topic);
    Task RetryElasticSearch<T>(Action action);
    Task RetryRedis<T>(Action action);
}
