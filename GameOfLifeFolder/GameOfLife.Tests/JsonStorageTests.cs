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

    [Fact]
    public void TestLoad()
    {
        // Arrange
        string json = "{\"rows\":2,\"columns\":2,\"grid\":[[false,true],[true,false]]}";
        File.WriteAllText("testLoad.json", json);
        JsonStorage storage = new JsonStorage();

        // Act
        Grid grid = storage.Load();

        // Assert
        Assert.Equal(2, grid.rows);
        Assert.Equal(2, grid.columns);
        Assert.False(grid.GetCellState(0, 0));
        Assert.True(grid.GetCellState(0, 1));
        Assert.True(grid.GetCellState(1, 0));
        Assert.False(grid.GetCellState(1, 1));
    }
}