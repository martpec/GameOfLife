﻿using System.Data;

namespace GameOfLife;

public class Program
{
    public static void Main(string[] args)
    {
        JsonStorage storage  = new JsonStorage();
        AutomationSimulator sim = new AutomationSimulator(storage);
        
        Console.WriteLine("Welcome in Game of Life Simulator");
        Grid grid = GridSetup(storage);
        sim.StartSimulation(grid);
    }

    public static Grid GridSetup(IStorage storage)
    {
        while (true)
        {
            Console.WriteLine("\nChoose your grid setup:");
            Console.WriteLine("1. Create a new random grid");
            Console.WriteLine("2. Load grid from JSON file");
            string? input = Console.ReadLine();
            if (input == "1")
            {
                return GridCreation.RandomGrid();
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

}