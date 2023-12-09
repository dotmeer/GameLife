using FluentAssertions;
using GameLife.Rules.Cells;
using GameLife.Rules.Fields;
using GameLife.Rules.Rules;

namespace GameLife.Tests.Rules.Fields;

public sealed class FieldTests
{
    [Theory]
    [InlineData(-1, -1)]
    [InlineData(0, -1)]
    [InlineData(-1, 0)]
    [InlineData(10, 10)]
    [InlineData(0, 10)]
    [InlineData(10, 0)]
    public void GetCellState_OutOfRange_ReturnsNull(int x, int y)
    {
        // arrange
        var field = FieldFactory.Create(10, 10, RuleSet.Test);

        // act
        var result = field.GetCellState(x, y);

        // assert
        result.Should().BeNull();
    }

    [Fact]
    public void GetCellState_InRange_ReturnsState()
    {
        // arrange
        var field = FieldFactory.Create(10, 10, RuleSet.Test);

        // act
        var result = field.GetCellState(1, 1);

        // assert
        result.Should().Be(CellState.Alive);
    }

    [Fact]
    public void ExecuteTurn_NotThrows()
    {
        // arrange
        var field = FieldFactory.Create(10, 10, RuleSet.Test);

        // act
        var action = () => field.ExecuteTurn();

        // assert
        action.Should().NotThrow();
    }
}