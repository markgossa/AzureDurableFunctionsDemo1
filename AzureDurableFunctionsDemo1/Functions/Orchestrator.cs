using Microsoft.Azure.WebJobs;
using System.Threading.Tasks;

namespace AzureDurableFunctionsDemo1.Functions
{
    public class Orchestrator
    {
        [FunctionName("Orchestrator")]
        public static async Task<string> RunOrchestrator(
            [OrchestrationTrigger] DurableOrchestrationContext context)
        {
            string output = null;
            string name = context.GetInput<string>();
            output = await context.CallActivityAsync<string>("HelloActivity", name);
            return output;
        }
    }
}
