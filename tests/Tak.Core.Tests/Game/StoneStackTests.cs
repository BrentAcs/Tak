using FluentAssertions;
using Tak.Core.Game;

namespace Tak.Core.Tests.Game;

public class StoneStackTests
{
   [Fact]
   public void Count_WillBe_IncrementedByOne_AfterAdd()
   {
      var sut = new StoneStack();
      var priorCount = sut.Count;

      sut.Add(new FlatStone(PlayerColor.White));

      sut.Count.Should().Be(priorCount + 1);
   }

   [Fact]
   public void CanAddStone_IsTrue_WhenEmpty()
   {
      var sut = new StoneStack();

      var result = sut.CanAddStone();

      result.Should().BeTrue();
   }

   [Fact]
   public void CanAddStone_IsTrue_WhenTopStoneIsFlat()
   {
      var sut = new StoneStack {new FlatStone(PlayerColor.White)};

      var result = sut.CanAddStone();

      result.Should().BeTrue();
   }
}
