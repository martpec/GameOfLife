using Xunit;
using GameOfLife;
using System.Collections.Generic;

public class AutomationSimulatorTests
{
    [Fact]
    public void CountTrueInListTest()
    {
        // Arrange
        JsonStorage json = new JsonStorage();
        AutomationSimulator simulator = new AutomationSimulator(json);
        List<bool> list = new List<bool> { true, false, true, false, true };

        // Act
        int count = simulator.CountTrueInList(list);

        // Assert
        Assert.Equal(3, count);
    }

    [Fact]
    public void CalculateNextGenerationTest()
    {
        // Arrange
        Cell[][] cells = new Cell[3][];
        cells[0] = new Cell[] { new Cell(false), new Cell(true), new Cell(false) };
        cells[1] = new Cell[] { new Cell(true), new Cell(true), new Cell(true) };
        cells[2] = new Cell[] { new Cell(false), new Cell(true), new Cell(false) };
        Grid grid = new Grid(3, 3, cells);
        JsonStorage json = new JsonStorage();
        AutomationSimulator simulator = new AutomationSimulator(json);
        Cell.UpdateNeighbours(grid);

        // Act
        simulator.CalculateNextGeneration(grid);

        // Assert
        Assert.True(grid.GetCellState(0, 0));
        Assert.True(grid.GetCellState(0, 1));
        Assert.True(grid.GetCellState(0, 2));
        Assert.True(grid.GetCellState(1, 0));
        Assert.False(grid.GetCellState(1, 1));
        Assert.True(grid.GetCellState(1, 2));
        Assert.True(grid.GetCellState(2, 0));
        Assert.True(grid.GetCellState(2, 1));
        Assert.True(grid.GetCellState(2, 2));
    }
}