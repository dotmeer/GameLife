namespace GameLife.Rules;

public class Field
{
    public int Width { get; }

    public int Height { get; }

    internal Cell[,] Cells { get; }

    internal Field(int width, int height)
    {
        Width = width;
        Height = height;
        Cells = new Cell[width, height];
    }

    public void ExecuteTurn()
    {
        for (var i = 0; i < Width; i++)
        {
            for (var j = 0; j < Height; j++)
            {
                Cells[i, j].CalculateNexState();
            }
        }

        for (var i = 0; i < Width; i++)
        {
            for (var j = 0; j < Height; j++)
            {
                Cells[i, j].UpdateState();
            }
        }
    }

    public Cell? GetCell(int x, int y)
    {
        return x >= 0 && x < Width && y >= 0 && y < Height
            ? Cells[x, y]
            : null;
    }

    
}