using System;
using System.ComponentModel;
using System.IO;
using Microsoft.SemanticKernel;

public class MusicLibraryPlugin
{
    [KernelFunction]
    [Description("Get a list of music recently played by the user")]
    public static string GetRecentPlays()
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "data/recentlyplayed.txt");

        if (!File.Exists(filePath))
        {
            return "No recently played songs found.";
        }

        return File.ReadAllText(filePath);
    }

    [KernelFunction]
    [Description("Get a list of music available to the user")]
    public static string GetMusicLibrary()
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "data/musiclibrary.txt");

        if (!File.Exists(filePath))
        {
            return "No music library found.";
        }

        return File.ReadAllText(filePath);
    }
}
