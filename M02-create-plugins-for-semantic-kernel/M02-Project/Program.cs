#pragma warning disable SKEXP0050
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Plugins.Core;

var builder = Kernel.CreateBuilder();
builder.AddAzureOpenAIChatCompletion(
    "openAImodeldeploymentname",
    "openAIendpoint",
    "APIkey");

var kernel = builder.Build();

string language = "French";
string history = @"I'm traveling with my kids and one of them has a peanut allergy.";

// Assign a persona to the prompt
string prompt = @$"
    The following is a conversation with an AI travel assistant. 
    The assistant is helpful, creative, and very friendly.

    <message role=""user"">Can you give me some travel destination suggestions?</message>

    <message role=""assistant"">Of course! Do you have a budget or any specific 
    activities in mind?</message>

    <message role=""user"">${input}</message>";

string input = @"I'm planning an anniversary trip with my spouse. We like hiking, mountains, 
    and beaches. Our travel budget is $15000";

var result = await kernel.InvokePromptAsync(prompt);
Console.WriteLine(result);