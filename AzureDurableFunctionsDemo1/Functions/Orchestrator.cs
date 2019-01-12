using Microsoft.Azure.WebJobs;
using System.Threading.Tasks;
using AzureDurableFunctionsDemo1.Models;

namespace AzureDurableFunctionsDemo1
{
    public class Orchestrator
    {
        [FunctionName("Orchestrator")]
        public static async Task<string> RunOrchestrator(
            [OrchestrationTrigger] DurableOrchestrationContext context)
        {
            string output = null;
            string name = context.GetInput<string>();
            //string name = userInfo.Name;
            output = await context.CallActivityAsync<string>("HelloActivity", name);
            return output;
        }
    }
}
