namespace GameLife.Rules;

public class Cell
{
    public CellState State { get; private set; }

    private CellState? _nextState;

    private IReadOnlyCollection<Cell>? _neighbors;

    public Cell(CellState state)
    {
        State = state;
    }

    public void InitNeighbors(IReadOnlyCollection<Cell>? neighbors)
    {
        _neighbors ??= neighbors;
    }

    public void CalculateNexState()
    {
        if (_neighbors is null)
        {
            throw new Exception("Нет информации о соседних клетках");
        }

        var aliveNeighborsCount = _neighbors.Count(_ => _.State != CellState.Dead);
        switch (State)
        {
            case CellState.Dead:
                if (aliveNeighborsCount == 3)
                {
                    _nextState = CellState.Alive;
                }
                break;

            case CellState.Alive:
                if (aliveNeighborsCount < 2 || aliveNeighborsCount > 3)
                {
                    _nextState = CellState.Dead;
                }
                else if (State == CellState.Alive)
                {
                    _nextState = CellState.Alive;
                }
                break;
        }
    }

    public void UpdateState()
    {
        State = _nextState ?? State;
        _nextState = null;
    }
}