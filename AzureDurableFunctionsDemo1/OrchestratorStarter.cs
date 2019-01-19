using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using AzureDurableFunctionsDemo1.Models;

namespace AzureDurableFunctionsDemo1
{
    public static class OrchestratorStarter
    {
        [FunctionName("OrchestratorStarter")]
        public static async Task<HttpResponseMessage> HttpStart(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post")]HttpRequestMessage req,
            [OrchestrationClient]DurableOrchestrationClient starter,
            ILogger log)
        {
            UserInfo userInfo = await req.Content.ReadAsAsync<UserInfo>();

            // Function input comes from the request content.
            string instanceId = await starter.StartNewAsync("Orchestrator", userInfo.Name);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}
