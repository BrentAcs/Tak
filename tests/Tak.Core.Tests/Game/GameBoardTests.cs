using Tak.Core.Game;

namespace Tak.Core.Tests.Game;

public class GameBoardTests
{
   // ----- General

   [Fact]
   public void AfterCreate_SquareWillBe_Empty()
   {
      var sut = new GameBoard(5, 5);

      var isEmpty = sut[ 2, 2 ].IsEmpty;

      isEmpty.Should().BeTrue();
   }
   
   // ----- IsOnBoard

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
   
   // ----- IdentifyBorderPosition 

   // [Theory]
   // [InlineData(1, 1, BorderPosition.NotOnBorder)]
   // [InlineData(0, 0, BorderPosition.CornerUpperLeft)]
   // [InlineData(4, 0, BorderPosition.CornerUpperRight)]
   // [InlineData(0, 4, BorderPosition.CornerLowerLeft)]
   // [InlineData(4, 4, BorderPosition.CornerLowerRight)]
   // [InlineData(0, 3, BorderPosition.LeftEdge)]
   // [InlineData(4, 3, BorderPosition.RightEdge)]
   // [InlineData(3, 0, BorderPosition.TopEdge)]
   // [InlineData(3, 4, BorderPosition.BottomEdge)]
   // public void IdentifyBorderPosition_On5by5Board(int x, int y, BorderPosition expected)
   // {
   //    var sut = new GameBoard(5, 5);
   //    
   //    var position = sut.IdentifyBorderPosition(x, y);
   //
   //    position.Should().Be(expected);
   // } 
   
}
