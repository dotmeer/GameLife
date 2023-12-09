using GameLife.Rules.Cells;
using GameLife.Rules.Fields;

namespace GameLife.Rules.Rules;

internal interface IRule
{
    void InitializeField(Field field);

    CellState CalculateNextState(Cell cell);
}