using System;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.SemanticKernel;

public class MusicLibraryPlugin
{
    [KernelFunction]
    [Description("Get a list of music recently played by the user")]
    public static string GetRecentPlays()
    {
        string filePath = "data/recentlyplayed.txt";

        // Check if file exists and return content or a message if it doesn’t exist
        if (!File.Exists(filePath))
        {
            return "No recently played songs found.";
        }

        string content = File.ReadAllText(filePath);
        return string.IsNullOrWhiteSpace(content) ? "No recently played songs found." : content;
    }

    [KernelFunction]
    [Description("Add a song to the recently played list")]
    public static string AddToRecentlyPlayed(
        [Description("The name of the artist")] string artist,
        [Description("The title of the song")] string song,
        [Description("The song genre")] string genre)
    {
        string filePath = "data/recentlyplayed.txt";
        JsonArray recentlyPlayed;

        // Ensure the "data" directory exists
        Directory.CreateDirectory("data");

        // Attempt to read and parse the existing JSON content
        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);

            // Try to parse jsonContent as JsonArray or initialize a new JsonArray if parsing fails
            recentlyPlayed = JsonNode.Parse(jsonContent) as JsonArray ?? new JsonArray();
        }
        else
        {
            // If file doesn't exist, initialize a new JsonArray
            recentlyPlayed = new JsonArray();
        }

        // Create a new JSON object for the song
        var newSong = new JsonObject
        {
            ["title"] = song ?? "Unknown Title",
            ["artist"] = artist ?? "Unknown Artist",
            ["genre"] = genre ?? "Unknown Genre"
        };

        // Insert the new song at the beginning of the array
        recentlyPlayed.Insert(0, newSong);

        // Write the updated JSON content back to the file with indentation
        File.WriteAllText(filePath, JsonSerializer.Serialize(recentlyPlayed, new JsonSerializerOptions { WriteIndented = true }));

        return $"Added '{song}' to recently played";
    }
}
