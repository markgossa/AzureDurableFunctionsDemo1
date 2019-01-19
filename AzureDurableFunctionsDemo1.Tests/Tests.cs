using Xunit;
using AzureDurableFunctionsDemo1.Functions;

namespace AzureDurableFunctionsDemo1.Tests
{
    public class AzureDurableFunctionsDemo1Tests
    {
        [Fact]
        public void TestSayHello()
        {
            string output = HelloActivity.SayHello("Joe");
            string correctOutput = "Hello Joe!";
            Assert.Equal(correctOutput, output);
        }
    }
}
