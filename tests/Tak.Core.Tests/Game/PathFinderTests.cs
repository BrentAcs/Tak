using Tak.Core.Extensions;
using Tak.Core.Game;

namespace Tak.Core.Tests.Game;

public class PathFinderTests
{
   private static GameBoard CreateInitialTestBoard5by5()
   {
      var boardSetup = new[ , ]
      {
         {"--", "--", "--", "--", "--"}, {"--", "--", "--", "--", "--"}, {"wf", "wf", "wf", "wf", "wf"}, {"--", "--", "--", "--", "--"},
         {"--", "--", "--", "--", "--"},
      };

      var board = new GameBoard(boardSetup.GetLength(0), boardSetup.GetLength(1));
      for (int y = 0; y < boardSetup.GetLength(0); y++)
      {
         for (int x = 0; x < boardSetup.GetLength(1); x++)
         {
            var stone = boardSetup[ x, y ].ToStone();
            if (stone is not null)
               board[ x, y ].Stack!.Add(stone);
         }
      }

      return board;
   }

   // ----- IdentifyBorderPosition 

   [Theory]
   [InlineData(1, 1, BorderPosition.NotOnBorder)]
   [InlineData(0, 0, BorderPosition.CornerUpperLeft)]
   [InlineData(4, 0, BorderPosition.CornerUpperRight)]
   [InlineData(0, 4, BorderPosition.CornerLowerLeft)]
   [InlineData(4, 4, BorderPosition.CornerLowerRight)]
   [InlineData(0, 3, BorderPosition.LeftEdge)]
   [InlineData(4, 3, BorderPosition.RightEdge)]
   [InlineData(3, 0, BorderPosition.TopEdge)]
   [InlineData(3, 4, BorderPosition.BottomEdge)]
   public void IdentifyBorderPosition_On5by5Board(int x, int y, BorderPosition expected)
   {
      var board = new GameBoard(5, 5);
      var sut = new PathFinder();

      var position = sut.IdentifyBorderPosition(board, x, y);

      position.Should().Be(expected);
   }

   // ----- Find

   [Fact]
   public void Find_WillReturnEmpty_WhenNotStartingOnBorder()
   {
      var board = CreateInitialTestBoard5by5();
      var pathFinder = new PathFinder();

      var path = pathFinder.Find(board, 1, 2);

      path.Should().BeEmpty();
   }

   [Fact]
   public void Find_WillReturnEmpty_WhenStartingOnEmtpy()
   {
      var board = CreateInitialTestBoard5by5();
      var pathFinder = new PathFinder();

      var path = pathFinder.Find(board, 0, 1);

      path.Should().BeEmpty();
   }

   [Fact]
   public void Find_Test_1()
   {
      var board = CreateInitialTestBoard5by5();
      var pathFinder = new PathFinder();

      var path = pathFinder.Find(board, 0, 2);

      path.Should().BeEmpty();
   }

   // ----- FindPossibleMoves

   [Theory]
   [ClassData(typeof(FindPossibleMovesTestTestCases))]
   public void FindPossibleMoves_ReturnsExpectedOn5x5(Func<GameBoard> creator, Point initial, Point[] expected)
   {
      var board = creator();
      var pathFinder = new PathFinder();

      var path = pathFinder.FindPossibleMoves(board, initial);

      path.Should().Contain(expected);
   }

   public class FindPossibleMovesTestTestCases : TheoryTestCases<Func<GameBoard>, Point, Point[]>
   {
      public FindPossibleMovesTestTestCases()
      {
         AddCase(CreateInitialTestBoard5by5, new Point(0, 2), new[] {new Point(1, 2)});
      }
   }
}
