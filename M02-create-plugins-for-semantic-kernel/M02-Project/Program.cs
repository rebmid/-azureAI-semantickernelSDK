#pragma warning disable SKEXP0050
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Plugins.Core;



var builder = Kernel.CreateBuilder();

builder.AddAzureOpenAIChatCompletion(
    "openAImodeldeploymentname",
    "openAIendpoint",
    "APIkey");

builder.Plugins.AddFromType<ConversationSummaryPlugin>();
var kernel = builder.Build();

string language = "French";
string prompt = @$"Create a list of helpful phrases and 
    words in ${language} a traveler would find useful.";


var result = await kernel.InvokePromptAsync(prompt);
Console.WriteLine(result);