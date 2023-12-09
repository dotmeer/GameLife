using FluentAssertions;
using GameLife.Rules.Cells;

namespace GameLife.Tests.Rules.Cells;

public sealed class CellTests
{
    [Theory]
    [InlineData(CellState.Alive)]
    [InlineData(CellState.Dead)]
    public void Cctor_InitialState(CellState state)
    {
        // act
        var cell = new Cell(state);

        // assert
        cell.Should().BeEquivalentTo(new
        {
            State = state,
            NextState = (CellState?)null,
            Neighbors = (IReadOnlyCollection<Cell>?)null
        });
    }

    [Fact]
    public void InitNeighbors_NeighborsAdded()
    {
        // arrange
        var cell = new Cell(CellState.Alive);
        var neighbors = new List<Cell>
        {
            new(CellState.Dead)
        };

        // act
        cell.InitNeighbors(neighbors);

        // assert
        cell.Neighbors.Should().BeSameAs(neighbors);
    }



    [Fact]
    public void InitNeighbors_Twice_Ignored()
    {
        // arrange
        var cell = new Cell(CellState.Alive);

        var neighbors = new List<Cell>
        {
            new(CellState.Dead)
        };
        cell.InitNeighbors(neighbors);

        var neighborsDuplicate = new List<Cell>
        {
            new(CellState.Alive)
        };

        // act
        cell.InitNeighbors(neighborsDuplicate);

        // assert
        cell.Neighbors.Should().NotBeSameAs(neighborsDuplicate);
        cell.Neighbors.Should().NotBeEquivalentTo(neighborsDuplicate);
        cell.Neighbors.Should().BeSameAs(neighbors);
    }

    [Fact]
    public void SetNextState_NextStateUpdated()
    {
        // arrange
        var cell = new Cell(CellState.Alive);

        // act
        cell.SetNextState(CellState.Dead);

        // assert
        cell.NextState.Should().Be(CellState.Dead);
    }

    [Fact]
    public void UpdateState_StateUpdated()
    {
        // arrange
        var cell = new Cell(CellState.Alive);
        cell.SetNextState(CellState.Dead);

        // act
        cell.UpdateState();

        // assert
        cell.NextState.Should().BeNull();
        cell.State.Should().Be(CellState.Dead);
    }
}