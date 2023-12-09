namespace GameLife.Rules.Cells;

internal class Cell
{
    public CellState State { get; private set; }

    private CellState? _nextState;

    internal IReadOnlyCollection<Cell>? Neighbors { get; private set; }

    public Cell(CellState state)
    {
        State = state;
    }

    internal void InitNeighbors(IReadOnlyCollection<Cell>? neighbors)
    {
        Neighbors ??= neighbors;
    }
    
    internal void SetNextState(CellState state)
    {
        _nextState = state;
    }

    internal void UpdateState()
    {
        State = _nextState ?? State;
        _nextState = null;
    }
}