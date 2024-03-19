namespace GameOfLife.Tests;

public class GridTests
{
    [Fact]
    public void UpdateCellStateTest()
    {
        // Arrange
        Cell[][] cells = new Cell[2][];
        cells[0] = new Cell[] { new Cell(true), new Cell(true) };
        cells[1] = new Cell[] { new Cell(true), new Cell(true) };
        Grid grid = new Grid(2,2,cells);

        // Act
        grid.UpdateCellState(grid, 0, 0);

        // Assert
        Assert.False(grid.GetCellState(0, 0));
    }

    [Fact]
    public void GetCellStateTest()
    {
        // Arrange
        Cell[][] cells = new Cell[2][];
        cells[0] = new Cell[] { new Cell(true), new Cell(true) };
        cells[1] = new Cell[] { new Cell(true), new Cell(true) };
        Grid grid = new Grid(2,2,cells);

        // Act
        bool state = grid.GetCellState(0, 0);

        // Assert
        Assert.True(state);
    }
}