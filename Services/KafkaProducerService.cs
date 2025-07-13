using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace WebAPI_WEEK_4.Services
{
    public class KafkaProducerService : IKafkaProducerService
    {
        private readonly IConfiguration _configuration;
        private readonly string _bootstrapServers;

        public KafkaProducerService(IConfiguration configuration)
        {
            _configuration = configuration;
            _bootstrapServers = _configuration["Kafka:BootstrapServers"];
        }

        public async Task ProduceAsync(string topic, string message)
        {
            var config = new ProducerConfig { BootstrapServers = _bootstrapServers };

            using var producer = new ProducerBuilder<Null, string>(config).Build();
            var result = await producer.ProduceAsync(topic, new Message<Null, string> { Value = message });

            Console.WriteLine($"Kafka >> Delivered to: {result.TopicPartitionOffset}");
        }
    }
}
