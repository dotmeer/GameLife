using GameLife.Rules.Cells;
using GameLife.Rules.Fields;

namespace GameLife.Rules.Rules;

public interface IRule
{
    void Initialize(Field field);

    CellState CalculateNextState(Cell cell);
}