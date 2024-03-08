namespace GameOfLife;

public interface IStorage
{
    void Save(Grid grid);
    Grid Load();
}