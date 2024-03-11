using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;

namespace GameOfLife;

public class JsonStorage : IStorage
{
    // no idea how this works :)
    public class CellConverter : JsonConverter<Cell[][]>
    {
        public override Cell[][] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument document = JsonDocument.ParseValue(ref reader))
            {
                bool[][]? boolArray = JsonSerializer.Deserialize<bool[][]>(document.RootElement.GetRawText(), options);
                if (boolArray != null)
                {
                    Cell[][] cellArray = boolArray.Select(row => row.Select(b => new Cell(b)).ToArray()).ToArray();
                    return cellArray;
                }
            }
            return new Cell[0][];
        }

        public override void Write(Utf8JsonWriter writer, Cell[][] value, JsonSerializerOptions options)
        {
            bool[][] boolArray = value.Select(row => row.Select(cell => cell.State).ToArray()).ToArray();
            JsonSerializer.Serialize(writer, boolArray, options);
        }
    }
    public void Save(Grid grid)
    {
        string filePath = "gridSave.json";
        var options = new JsonSerializerOptions();
        options.Converters.Add(new CellConverter());
        string jsonString = JsonSerializer.Serialize(grid,options);
        File.WriteAllText(filePath, jsonString);
    }

    public Grid Load()
    {
        Console.Write("Enter the path to JSON file: ");
        string? filepath = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(filepath) && filepath.EndsWith(".json"))
        {
            string content = File.ReadAllText(filepath);
            var options = new JsonSerializerOptions();
            options.Converters.Add(new CellConverter());
            Grid? grid = JsonSerializer.Deserialize<Grid>(content, options);
            if (grid != null)
            {
                return grid;
            }
        }
        return new Grid(0, 0, new Cell[0][]);
    }

}