using System.Drawing;
using FluentAssertions;
using Tak.Core.Game;

namespace Tak.Core.Tests.Game;

public class GameBoardTests
{
   [Theory]
   [InlineData(5,5,0,0, true)]
   [InlineData(5,5,4,4, true)]
   [InlineData(5,5,-1,-1, false)]
   [InlineData(5,5,-1,0, false)]
   [InlineData(5,5,0,-1, false)]
   [InlineData(5,5,5,5, false)]
   [InlineData(5,5,5,4, false)]
   [InlineData(5,5,4,5, false)]
   public void IsOnBoard_Tests(int boardWidth, int boardHeight, int testX, int testY, bool expected)
   {
      var sut = new GameBoard(boardWidth, boardHeight);

      var result = sut.IsOnBoard(new Point(testX, testY));

      result.Should().Be(expected);
   }
}
