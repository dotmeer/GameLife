using GameLife.Rules.Cells;
using GameLife.Rules.Rules;

namespace GameLife.Rules.Fields;

// TODO: unit-tests для правил
public class Field
{
    public int Width { get; }

    public int Height { get; }

    internal Cell[,] Cells { get; }

    private readonly IRule _rule;

    internal Field(int width, int height, IRule rule)
    {
        Width = width;
        Height = height;
        Cells = new Cell[width, height];
        _rule = rule;
    }

    public void ExecuteTurn()
    {
        for (var i = 0; i < Width; i++)
        {
            for (var j = 0; j < Height; j++)
            {
                Cells[i, j].SetNextState(
                    _rule.CalculateNextState(Cells[i, j]));
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

    public CellState? GetCellState(int x, int y)
    {
        return x >= 0 && x < Width && y >= 0 && y < Height
            ? Cells[x, y].State
            : null;
    }
}