using System.Text;

namespace GameLife;

public class Field
{
    public int Width { get; }

    public int Height { get; }

    private readonly Random _random;

    private readonly Cell[,] _cells;

    public bool Initialized { get; private set; }

    public Field(int width, int height)
    {
        Width = width;
        Height = height;
        _random = new Random();
        Initialized = false;
        _cells = new Cell[width, height];
    }

    public void ExecuteTurn()
    {
        for (var i = 0; i < Width; i++)
        {
            for (var j = 0; j < Height; j++)
            {
                _cells[i, j].CalculateNexState();
            }
        }

        for (var i = 0; i < Width; i++)
        {
            for (var j = 0; j < Height; j++)
            {
                _cells[i, j].UpdateState();
            }
        }
    }

    public Cell? GetCell(int x, int y)
    {
        return x >= 0 && x < Width && y >= 0 && y < Height
            ? _cells[x, y]
            : null;
    }

    public void Initialize()
    {
        // TODO: возможно, предустановленные формации или условия генерации из списка (dropbox)
        for (var i = 0; i < Width; i++)
        {
            for (var j = 0; j < Height; j++)
            {
                _cells[i, j] = new Cell(GetInitialState());
            }
        }
        
        for (var i = 0; i < Width; i++)
        {
            for (var j = 0; j < Height; j++)
            {
                _cells[i, j].InitNeighbors(GetNeighbors(i, j));
            }
        }

        Initialized = true;
    }

    private CellState GetInitialState()
    {
        // TODO: возможно, надо как-то регулировать частоту
        var value = _random.Next(0, 100);
        return value >= 25
            ? CellState.Dead
            : CellState.New;
    }

    private IReadOnlyCollection<Cell> GetNeighbors(int x, int y)
    {
        var result = new List<Cell>();

        var leftX = x - 1 < 0
            ? Width - 1
            : x - 1;

        var rightX = x + 1 == Width
            ? 0
            : x + 1;

        var topY = y - 1 < 0
            ? Height - 1
            : y - 1;

        var bottomY = y + 1 == Height
            ? 0
            : y + 1;

        result.Add(_cells[leftX, topY]);
        result.Add(_cells[leftX, y]);
        result.Add(_cells[leftX, bottomY]);
        result.Add(_cells[x, topY]);
        result.Add(_cells[x, bottomY]);
        result.Add(_cells[rightX, topY]);
        result.Add(_cells[rightX, y]);
        result.Add(_cells[rightX, bottomY]);

        return result;
    }
}