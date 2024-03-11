using System.Data;

namespace GameOfLife;

public class Cell : ICell
{
    public bool State { get; set; }
    public List<bool> Neighbours { get; set; } = new List<bool>();

    public Cell(bool State)
    {
        this.State = State;
    }
    
    public static void UpdateNeighbours(Grid grid)
    {
        for (int row = 0; row < grid.rows; row++)
        {
            for (int column = 0; column < grid.columns; column++)
            {
                List<bool> neighbours = new List<bool>();
                
                if (row - 1 > -1)
                {
                    neighbours.Add(grid.GetCellState(row - 1,column)); // Above
                    if (column - 1 > -1)
                    {
                        neighbours.Add(grid.GetCellState(row - 1,column - 1)); // Above left
                    }
                    if (column + 1 < grid.columns)
                    {
                        neighbours.Add(grid.GetCellState(row - 1,column + 1)); // Above right
                    }
                }
                if (row + 1 < grid.rows)
                {
                    neighbours.Add(grid.GetCellState(row + 1, column)); // Below
                    if (column - 1 > -1)
                    {
                        neighbours.Add(grid.GetCellState(row + 1, column - 1)); // Below left
                    }
                    if (column + 1 < grid.columns)
                    {
                        neighbours.Add(grid.GetCellState(row + 1, column + 1)); // Below right
                    }
                }
                if (column - 1 > -1)
                {
                    neighbours.Add(grid.GetCellState(row, column - 1)); // Left
                }
                if (column + 1 < grid.columns)
                {
                    neighbours.Add(grid.GetCellState(row, column + 1)); // Right
                }

                grid.grid[row][column].Neighbours = neighbours;
            }
        }
    }
}