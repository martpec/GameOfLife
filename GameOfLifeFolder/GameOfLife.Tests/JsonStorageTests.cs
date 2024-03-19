using Xunit;
using GameOfLife;
using System.IO;

public class JsonStorageTests
{
    [Fact]
    public void SaveTest()
    {
        // Arrange
        Cell[][] cells = new Cell[2][];
        cells[0] = new Cell[] { new Cell(false), new Cell(true) };
        cells[1] = new Cell[] { new Cell(true), new Cell(false) };
        Grid grid = new Grid(2, 2, cells);
        JsonStorage storage = new JsonStorage();

        // Act
        storage.Save(grid);

        // Assert
        Assert.True(File.Exists("gridSave.json"));
        string content = File.ReadAllText("gridSave.json");
        Assert.Equal("{\"rows\":2,\"columns\":2,\"grid\":[[false,true],[true,false]]}", content);
    }
}