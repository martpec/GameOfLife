namespace GameOfLife;

public interface ICell
{
    bool State { get; set; }
    List<bool> Neighbours { get; set; }
}