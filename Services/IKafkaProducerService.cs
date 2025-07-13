namespace WebAPI_WEEK_4.Services
{
    public interface IKafkaProducerService
    {
        Task ProduceAsync(string topic, string message);
    }
}
