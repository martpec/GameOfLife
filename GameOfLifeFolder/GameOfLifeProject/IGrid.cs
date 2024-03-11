namespace GameOfLife;

public interface IGrid
{
    void UpdateCellState(Grid grid, int row, int column);
    bool GetCellState(int row, int column);
}