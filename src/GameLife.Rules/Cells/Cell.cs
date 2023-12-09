namespace GameLife.Rules.Cells;

internal class Cell
{
    public CellState State { get; private set; }

    internal CellState? NextState { get; private set; }

    internal IReadOnlyCollection<Cell>? Neighbors { get; private set; }

    public Cell(CellState state)
    {
        State = state;
    }

    internal void InitNeighbors(IReadOnlyCollection<Cell> neighbors)
    {
        Neighbors ??= neighbors;
    }
    
    internal void SetNextState(CellState state)
    {
        NextState = state;
    }

    internal void UpdateState()
    {
        State = NextState ?? State;
        NextState = null;
    }
}