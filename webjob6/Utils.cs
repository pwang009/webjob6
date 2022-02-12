using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using webjob6.Extensions;

namespace webjob6
{
    public class Utils<T> where T : class
    {
        private static readonly string _connString;
        private static readonly string _queueName;

        static Utils()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile(
                "appsettings.json", 
                optional: false, 
                reloadOnChange: true
              );

            var configRoot = builder.Build();

            _connString = configRoot["AzureWebJobsStorage"];
            _queueName = configRoot["queueName"];
        }

        public static async Task AddMessage(T obj)
        {
            var jsonData = JsonSerializer.Serialize<T>(obj);
            var msg = new BinaryData(jsonData.CompressGZip());

            try
            {
                // set MessageEncoding to None, otherwise, it is defaulted as Base64
                var queue = new QueueClient(_connString, _queueName,
                    new QueueClientOptions() { MessageEncoding = QueueMessageEncoding.Base64 });

                await queue.SendMessageAsync(msg);
                Console.WriteLine($"message sent to queue {_queueName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"something went wrong, {ex}");
            }
        }


    }
}
