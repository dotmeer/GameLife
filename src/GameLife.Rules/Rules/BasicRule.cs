﻿using GameLife.Rules.Cells;
using GameLife.Rules.Fields;

namespace GameLife.Rules.Rules;

internal class BasicRule : IRule
{
    private static readonly Random Random = new();

    public void InitializeField(Field field)
    {
        for (var i = 0; i < field.Width; i++)
        {
            for (var j = 0; j < field.Height; j++)
            {
                field.Cells[i, j] = new Cell(GetInitialState());
            }
        }

        for (var i = 0; i < field.Width; i++)
        {
            for (var j = 0; j < field.Height; j++)
            {
                field.Cells[i, j].InitNeighbors(GetNeighbors(field, i, j));
            }
        }
    }

    public CellState CalculateNextState(Cell cell)
    {
        if (cell.Neighbors is null)
        {
            throw new Exception("Нет информации о соседних клетках");
        }

        var aliveNeighborsCount = cell.Neighbors.Count(_ => _.State == CellState.Alive);
        switch (cell.State)
        {
            case CellState.Dead:
                if (aliveNeighborsCount == 3)
                {
                    return CellState.Alive;
                }
                break;

            case CellState.Alive:
                if (aliveNeighborsCount < 2 || aliveNeighborsCount > 3)
                {
                    return CellState.Dead;
                }
                break;
        }

        return cell.State;
    }

    private static CellState GetInitialState()
    {
        return Random.Next(0, 100) >= 25
            ? CellState.Dead
            : CellState.Alive;
    }

    private static IReadOnlyCollection<Cell> GetNeighbors(Field field, int x, int y)
    {
        var result = new List<Cell>();

        var leftX = x - 1 < 0
            ? field.Width - 1
            : x - 1;

        var rightX = x + 1 == field.Width
            ? 0
            : x + 1;

        var topY = y - 1 < 0
            ? field.Height - 1
            : y - 1;

        var bottomY = y + 1 == field.Height
            ? 0
            : y + 1;

        result.Add(field.Cells[leftX, topY]);
        result.Add(field.Cells[leftX, y]);
        result.Add(field.Cells[leftX, bottomY]);
        result.Add(field.Cells[x, topY]);
        result.Add(field.Cells[x, bottomY]);
        result.Add(field.Cells[rightX, topY]);
        result.Add(field.Cells[rightX, y]);
        result.Add(field.Cells[rightX, bottomY]);

        return result;
    }
}