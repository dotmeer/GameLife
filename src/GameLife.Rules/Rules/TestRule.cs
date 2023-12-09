using GameLife.Rules.Cells;
using GameLife.Rules.Fields;

namespace GameLife.Rules.Rules;

internal sealed class TestRule : IRule
{
    public void InitializeField(Field field)
    {
        for (var i = 0; i < field.Width; i++)
        {
            for (var j = 0; j < field.Height; j++)
            {
                field.Cells[i, j] = new Cell(CellState.Alive);
            }
        }
    }

    public CellState CalculateNextState(Cell cell)
    {
        return cell.State;
    }
}