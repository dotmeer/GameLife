using FluentAssertions;
using GameLife.Rules.Cells;
using GameLife.Rules.Fields;
using GameLife.Rules.Rules;

namespace GameLife.Tests.Rules.Rules;

public sealed class BasicRuleTests
{
    [Fact]
    public void InitializeField_EachCellHas8Neighbors()
    {
        // arrange
        var rule = new BasicRule();
        var width = 10;
        var height = 10;
        var field = new Field(width, height, rule);

        // act
        rule.InitializeField(field);

        // assert
        for (var i = 0; i < field.Width; i++)
        {
            for (var j = 0; j < field.Height; j++)
            {
                field.Cells[i, j].Neighbors!.Count.Should().Be(8);
            }
        }
    }

    [Fact]
    public void CalculateNextState_CellNeighborsAreNull_Throws()
    {
        // arrange
        var cell = new Cell(CellState.Alive);
        var rule = new BasicRule();

        // act
        var action = () => rule.CalculateNextState(cell);

        // assert
        action.Should().Throw<Exception>();
    }

    [Theory]
    [InlineData(0, CellState.Dead)]
    [InlineData(1, CellState.Dead)]
    [InlineData(2, CellState.Dead)]
    [InlineData(3, CellState.Alive)]
    [InlineData(4, CellState.Dead)]
    [InlineData(5, CellState.Dead)]
    [InlineData(6, CellState.Dead)]
    [InlineData(7, CellState.Dead)]
    [InlineData(8, CellState.Dead)]
    public void CalculateNextState_CellStateDead_ExpectedNextState(int aliveNeighborsCount, CellState expected)
    {
        // arrange
        var cell = new Cell(CellState.Dead);
        var neighbors = new List<Cell>();
        for (var i = 0; i < 8; i++)
        {
            neighbors.Add(new Cell(
                i < aliveNeighborsCount
                    ? CellState.Alive
                    : CellState.Dead));
        }
        cell.InitNeighbors(neighbors);
        var rule = new BasicRule();

        // act
        var result = rule.CalculateNextState(cell);

        // assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(0, CellState.Dead)]
    [InlineData(1, CellState.Dead)]
    [InlineData(2, CellState.Alive)]
    [InlineData(3, CellState.Alive)]
    [InlineData(4, CellState.Dead)]
    [InlineData(5, CellState.Dead)]
    [InlineData(6, CellState.Dead)]
    [InlineData(7, CellState.Dead)]
    [InlineData(8, CellState.Dead)]
    public void CalculateNextState_CellStateAlive_ExpectedNextState(int aliveNeighborsCount, CellState expected)
    {
        // arrange
        var cell = new Cell(CellState.Alive);
        var neighbors = new List<Cell>();
        for (var i = 0; i < 8; i++)
        {
            neighbors.Add(new Cell(
                i < aliveNeighborsCount
                    ? CellState.Alive
                    : CellState.Dead));
        }
        cell.InitNeighbors(neighbors);
        var rule = new BasicRule();

        // act
        var result = rule.CalculateNextState(cell);

        // assert
        result.Should().Be(expected);
    }
}