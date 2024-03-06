namespace GameOfLife;

public class Cell : ICell
{
    public bool State { get; set; }
    public List<int[]> Neighbours { get; set; } = new List<int[]>();
}