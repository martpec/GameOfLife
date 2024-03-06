namespace GameOfLife;

public interface ICell
{
    bool State { get; set; }
    List<int[]> Neighbours { get; set; }
}