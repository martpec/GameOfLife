using System.Text.Json;
using System.IO;

namespace GameOfLife;

public class JsonStorage : IStorage
{
    public void Save(Grid grid)
    {
        string filePath = "gridSave.json";
        string jsonString = JsonSerializer.Serialize(grid);
        File.WriteAllText(filePath, jsonString);
    }

    public Grid Load()
    {
        Console.Write("Enter the path to JSON file: ");
        string? filepath = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(filepath) && filepath.EndsWith(".json"))
        {
            string content = File.ReadAllText(filepath);
            Grid? grid = JsonSerializer.Deserialize<Grid>(content);
            if (grid != null)
            {
                return grid;
            }
        }
        return new Grid(0, 0, new bool[0][]);
    }

}