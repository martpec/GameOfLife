namespace GameOfLife;

public interface IStorage
{
    void Save();
    Grid Load();
}