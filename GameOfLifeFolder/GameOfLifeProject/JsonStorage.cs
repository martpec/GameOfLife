using System.Text.Json;
using System.IO;

namespace GameOfLife;

public class JsonStorage : IStorage
{
    public void Save()
    {
        
    }

    public Grid Load()
    {
        Console.Write("Enter the path to JSON file: ");
        string? filepath = Console.ReadLine();
         if (!string.IsNullOrWhiteSpace(filepath) && filepath.EndsWith(".json"))
            {
                Grid? grid = JsonSerializer.Deserialize<Grid>(filepath);
            }
    

        

        return new Grid();
    }
}