﻿using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;



var builder = Kernel.CreateBuilder();
builder.AddAzureOpenAIChatCompletion(
    "openAImodeldeploymentname",
    "openAIendpoint",
    "APIkey");

    var kernel = builder.Build();
    kernel.ImportPluginFromType<MusicLibraryPlugin>();
    kernel.ImportPluginFromType<MusicConcertPlugin>();
    kernel.ImportPluginFromPromptDirectory("Prompts");

    OpenAIPromptExecutionSettings settings = new()
    {
        ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
    };

    string prompt = @"I live in Portland OR USA. Based on my recently 
        played songs and a list of upcoming concerts, which concert 
        do you recommend?";

var result = await kernel.InvokePromptAsync(prompt, new(settings));

Console.WriteLine(result);
