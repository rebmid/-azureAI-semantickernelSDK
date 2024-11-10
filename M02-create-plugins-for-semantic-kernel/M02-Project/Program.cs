#pragma warning disable SKEXP0050
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Plugins.Core;



var builder = Kernel.CreateBuilder();

builder.AddAzureOpenAIChatCompletion(
    "gpt-35-turbo-16k-rebmid",
    "https://openai-rebmid.openai.azure.com/",
    "FeGq8JEJdloPwWbK23vKsWXrdzkatUfDpeQuypEo6iBoHeCJadRdJQQJ99AKACYeBjFXJ3w3AAABACOGNfvg");

builder.Plugins.AddFromType<ConversationSummaryPlugin>();
var kernel = builder.Build();

string input = @"Please create a list of vegan breakfast recipes and gather ideas for spicy vegan dishes. 
Also, check if there are vegan-friendly ingredients available in local stores.";

var result = await kernel.InvokeAsync(
    "ConversationSummaryPlugin", 
    "GetConversationActionItems", 
    new() {{ "input", input }});

Console.WriteLine(result);