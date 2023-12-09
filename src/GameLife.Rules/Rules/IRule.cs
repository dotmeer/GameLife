using GameLife.Rules.Cells;
using GameLife.Rules.Fields;

namespace GameLife.Rules.Rules;

// TODO: отделить генерацию от расчета следующего шага
internal interface IRule
{
    void InitializeField(Field field);

    //TODO: попробовать определять стратегию в зависимости от типа клетки
    CellState CalculateNextState(Cell cell);
}