using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Plugins.Core;


var builder = Kernel.CreateBuilder();
builder.AddAzureOpenAIChatCompletion(
    "openAImodeldeploymentname",
    "openAIendpoint",
    "APIkey");


var kernel = builder.Build();
kernel.ImportPluginFromType<MusicLibraryPlugin>();

var result = await kernel.InvokeAsync(
    "MusicLibraryPlugin", 
    "AddToRecentlyPlayed", 
    new() {
        ["artist"] = "Tiara", 
        ["song"] = "Danse", 
        ["genre"] = "French pop, electropop, pop"
    }
);

Console.WriteLine(result);
