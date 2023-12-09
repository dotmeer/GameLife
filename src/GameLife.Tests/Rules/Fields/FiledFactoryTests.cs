using FluentAssertions;
using GameLife.Rules.Fields;
using GameLife.Rules.Rules;

namespace GameLife.Tests.Rules.Fields;

public sealed class FiledFactoryTests
{
    [Fact]
    public void Create_ReturnsField()
    {
        // arrange
        var width = 10;
        var height = 10;

        // act
        var result = FieldFactory.Create(width, height, RuleSet.Test);

        // assert
        result.Should().NotBeNull();
        result.Width.Should().Be(width);
        result.Height.Should().Be(height);
    }
}