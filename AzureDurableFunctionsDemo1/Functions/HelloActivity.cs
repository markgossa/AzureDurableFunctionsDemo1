using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureDurableFunctionsDemo1.Functions
{
    public class HelloActivity
    {
        [FunctionName("HelloActivity")]
        public static string SayHello([ActivityTrigger] string name, ILogger log)
        {
            log.LogInformation($"Saying hello to {name}.");
            return $"Hello {name}!";
        }
    }
}
