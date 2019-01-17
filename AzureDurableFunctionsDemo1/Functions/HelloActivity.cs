using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureDurableFunctionsDemo1.Functions
{
    public class HelloActivity
    {
        [FunctionName("HelloActivity")]
        public static string HelloActivityMethod([ActivityTrigger] string name, ILogger log)
        {
            log.LogInformation($"Saying hello to {name}.");
            string output = SayHello(name);
            return output;
        }

        public static string SayHello(string name)
        {
            return $"Hello {name}!";
        }
    }
}
