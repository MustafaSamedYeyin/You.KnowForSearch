using System;
using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Core.Interfaces;

namespace Business.Services;

public class RetryService : IRetryService
{
    public Task Retry<T>(Action action)
    {
        throw new NotImplementedException();
    }

    public Task RetryElasticSearch<T>(Action action)
    {
        throw new NotImplementedException();
    }

    public async Task RetryKafka<T>(Func<string,bool> kafkaMethod,string topic)
    {
        await CreateTopicIfDoesNotExist(topic);
        kafkaMethod(topic);
    }

    public Task RetryRedis<T>(Action action)
    {
        throw new NotImplementedException();
    }
    
    public async Task CreateTopicIfDoesNotExist(string topic)
    {
        var config = new AdminClientConfig { BootstrapServers = "localhost:9092" };
        using (var adminClient = new AdminClientBuilder(config).Build())
        {
            await adminClient.CreateTopicsAsync(new List<TopicSpecification>
            {
                new TopicSpecification { Name = topic, NumPartitions = 1, ReplicationFactor = 1 }
            });
        }
    }
}
