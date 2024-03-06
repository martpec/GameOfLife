using System.Data;

namespace GameOfLife;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome in Game of Life Simulator");
        Grid grid = GridSetup();
        AutomationSimulator sim = new AutomationSimulator();
        sim.StartSimulation(grid);
    }

    public static Grid GridSetup()
    {
        JsonStorage storage  = new JsonStorage();
        while (true)
        {
            Console.WriteLine("\nChoose your grid setup:");
            Console.WriteLine("1. Create a new random grid");
            Console.WriteLine("2. Load grid from JSON file");
            string? input = Console.ReadLine();
            if (input == "1")
            {
                return RandomGrid();
            }
            else if (input == "2")
            {
                return storage.Load();
            }
            else
            {
                Console.WriteLine("Incorrect input. Try again.");
                continue;
            }
        }
    }
    public static Grid RandomGrid()
    {
        Console.WriteLine("You selected option 1");
        Console.Write("Enter the number of rows for the grid (4-100): ");
        // need loop here
        if (!int.TryParse(Console.ReadLine(), out int rows))
        {

        }
        //need loop here also check size
        Console.WriteLine("Enter the number of columns for the grid (4-100): ");
        if (!int.TryParse(Console.ReadLine(), out int columns))
        {

        }
        // actual grid creation
        return new Grid();
    }


}