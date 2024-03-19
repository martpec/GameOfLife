using System.Reflection.Metadata;
using System.Text;

namespace GameOfLife;

public class GridCreation
{
    public static Grid RandomGrid()
    {
        Random random = new Random();
        Console.WriteLine("You selected option 1");

        int rows = GetInputRowColumn("Enter the number of rows for the grid (4-100): ");
        int columns = GetInputRowColumn("Enter the number of columns for the grid (4-100): ");

        Cell[][] grid = new Cell[rows][];
        for (int i = 0; i < rows; i++)
        {
            grid[i] = new Cell[columns];
            for (int j = 0; j < columns; j++)
            {
                grid[i][j] = new Cell(random.Next(2) == 0);
            }
        }
        return new Grid(rows, columns, grid);
    }

    private static int GetInputRowColumn(string prompt)
    {
        int number;
        while (true)
        {
            Console.WriteLine(prompt);
            if (int.TryParse(Console.ReadLine(), out number) && 4 <= number && number <= 100)
            {
                return number;
            }
            Console.WriteLine("Wrong input");
            continue;
        }
    }
}
public class Grid : IGrid
{
    public int rows { get; set; }
    public int columns { get; set; }
    public Cell[][] grid { get; set; }
    public Grid(int rows, int columns, Cell[][] grid)
    {
        this.rows = rows;
        this.columns = columns;
        this.grid = grid;
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Rows: {rows}");
        sb.AppendLine($"Columns: {columns}");
        sb.AppendLine("Grid:");
        foreach (var row in grid)
        {
            sb.AppendLine(string.Join(", ", row.Select(b => b.ToString())));
        }
        return sb.ToString();
    }

    public void UpdateCellState(Grid grid, int row, int column)
    {
        Cell cell = grid.grid[row][column];
        if (grid.GetCellState(row, column))
        {
            cell.State = false;
        }
        else
        {
            cell.State = true;
        }
    }

    public bool GetCellState(int row, int column)
    {
        return grid[row][column].State;
    }
}