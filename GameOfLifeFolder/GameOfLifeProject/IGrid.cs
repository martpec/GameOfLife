namespace GameOfLife;

public interface IGrid
{
    void UpdateCellState();
    bool GetCellState();
}