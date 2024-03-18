namespace GameOfLife;

public class AutomationSimulator
{
    private readonly IStorage storage;
    public AutomationSimulator(IStorage storage)
    {
        this.storage = storage;
    }
    
    public void StartSimulation(Grid grid)
    {
        Cell.UpdateNeighbours(grid);
        DisplayGrid(grid);
        
        while (true)
        {
            Console.WriteLine("Press 'N' to advance to the next generation.");
            Console.WriteLine("Press 'S' to save the current grid state to a file.");
            Console.WriteLine("Press 'X' to exit the simulation.");
            string? option = Console.ReadLine();

            switch (option?.ToLower())
            {
                case "n":
                    Cell.UpdateNeighbours(grid);
                    CalculateNextGeneration(grid);
                    DisplayGrid(grid);
                    break;
                case "s":
                    storage.Save(grid);
                    break;
                case "x":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public void DisplayGrid(Grid grid)
    {
        Console.WriteLine();
        for (int i = 0; i < grid.rows; i++)
        {
            for (int j = 0; j < grid.columns; j++)
            {
                Console.Write(grid.GetCellState(i, j) ? "O" : ".");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public void CalculateNextGeneration(Grid grid)
    {
        for (int i = 0; i < grid.rows; i++)
        {
            for (int j = 0; j < grid.columns; j++)
            {
                int trues = CountTrueInList(grid.grid[i][j].Neighbours);
                if (grid.GetCellState(i,j))
                {
                    if (trues < 2 || trues > 3)
                    {
                        grid.UpdateCellState(grid, i, j);
                    }
                }
                else
                {
                    if (trues == 3)
                    {
                        grid.UpdateCellState(grid, i, j);
                    }
                }
            }
        }
    }

    public int CountTrueInList(List<bool> list)
    {
        int count = 0;
        foreach (bool item in list)
        {
            if (item)
            {
                count++;
            }
        }
        return count;
    }
}