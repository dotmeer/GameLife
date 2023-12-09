using FluentAssertions;
using GameLife.Rules.Cells;
using GameLife.Rules.Fields;
using GameLife.Rules.Rules;

namespace GameLife.Tests.Rules.Rules;

public sealed class TestRuleTests
{
    [Fact]
    public void InitializeField_AllCellsAlive()
    {
        // arrange
        var rule = new TestRule();
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
                field.Cells[i, j].State.Should().Be(CellState.Alive);
            }
        }
    }

    [Theory]
    [InlineData(CellState.Alive)]
    [InlineData(CellState.Dead)]
    public void CalculateNextState_SameState(CellState state)
    {
        // arrange
        var cell = new Cell(state);
        var rule = new TestRule();

        // act
        var result = rule.CalculateNextState(cell);

        // assert
        result.Should().Be(state);
    }
}