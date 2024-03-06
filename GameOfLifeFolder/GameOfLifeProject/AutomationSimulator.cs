namespace GameOfLife;

public class AutomationSimulator
{
    public void StartSimulation(Grid grid)
    {
        DisplayGrid(grid);
        while(true)
        {
            Console.WriteLine("Press 'N' to advance to the next generation.");
            Console.WriteLine("Press 'S' to save the current grid state to a file.");
            Console.WriteLine("Press 'X' to exit the simulation.");
            string? option = Console.ReadLine();

            switch (option)
        {
            case "N":
                break;
            case "S":
                break;
            case "X":
                return;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
        }
    }

    public void DisplayGrid(Grid grid)
    {
        // for loops 
    }
}