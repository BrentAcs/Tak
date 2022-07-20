using Tak.Core.Extensions;

namespace Tak.Core.Game;

public interface IPathFinder
{
   BorderPosition IdentifyBorderPosition(GameBoard board, int x, int y);
   BorderPosition IdentifyBorderPosition(GameBoard board, Point point);
   IEnumerable<BorderPosition> IdentifyWinningSides(BorderPosition startingPosition);
}

public class PathFinder : IPathFinder
{
   private static Dictionary<Direction, Point> _directionOffsets = new Dictionary<Direction, Point>
   {
      {Direction.Up, new Point(0, -1)},
      {Direction.Down, new Point(0, 1)},
      {Direction.Left, new Point(-1, 0)},
      {Direction.Right, new Point(1, 0)}
   };

   public BorderPosition IdentifyBorderPosition(GameBoard board, int x, int y)
      => IdentifyBorderPosition(board, new Point(x, y));

   public BorderPosition IdentifyBorderPosition(GameBoard board, Point point)
   {
      var idStrategies = new Dictionary<BorderPosition, Func<Point, bool>>
      {
         {BorderPosition.CornerUpperLeft, pt => pt.X == 0 && pt.Y == 0},
         {BorderPosition.CornerUpperRight, pt => pt.X == board.MaxWidth - 1 && pt.Y == 0},
         {BorderPosition.CornerLowerLeft, pt => pt.X == 0 && pt.Y == board.MaxHeight - 1},
         {BorderPosition.CornerLowerRight, pt => pt.X == board.MaxWidth - 1 && pt.Y == board.MaxHeight - 1},
         {BorderPosition.LeftEdge, pt => (pt.X == 0) && (pt.Y != 0 && pt.Y != board.MaxHeight - 1)},
         {BorderPosition.RightEdge, pt => (pt.X == board.MaxWidth - 1) && (pt.Y != 0 && pt.Y != board.MaxHeight - 1)},
         {BorderPosition.TopEdge, pt => (pt.X != 0 && pt.X != board.MaxWidth - 1) && (pt.Y == 0)},
         {BorderPosition.BottomEdge, pt => (pt.X != 0 && pt.X != board.MaxWidth - 1) && (pt.Y == board.MaxHeight - 1)}
      };

      return idStrategies.Keys.FirstOrDefault(key => idStrategies[ key ](point));
   }

   public IEnumerable<BorderPosition> IdentifyWinningSides(BorderPosition startingPosition)
   {
      var idStrategies = new Dictionary<BorderPosition, BorderPosition[]>
      {
         {BorderPosition.CornerUpperLeft, new[] {BorderPosition.BottomEdge, BorderPosition.RightEdge}},
         {BorderPosition.CornerUpperRight, new[] {BorderPosition.BottomEdge, BorderPosition.LeftEdge}},
         {BorderPosition.CornerLowerLeft, new[] {BorderPosition.TopEdge, BorderPosition.RightEdge}},
         {BorderPosition.CornerLowerRight, new[] {BorderPosition.TopEdge, BorderPosition.LeftEdge}},
         {BorderPosition.LeftEdge, new[] {BorderPosition.RightEdge}},
         {BorderPosition.RightEdge, new[] {BorderPosition.LeftEdge}},
         {BorderPosition.TopEdge, new[] {BorderPosition.BottomEdge}},
         {BorderPosition.BottomEdge, new[] {BorderPosition.TopEdge}}
      };

      return idStrategies[ startingPosition ];
   }

   // public IEnumerable<Point> Find(GameBoard board, int startingX, int startingY)
   //    => Find(board, new Point(startingX, startingY));
   //
   // public IEnumerable<Point> Find(GameBoard board, Point startingPosition)
   // {
   //    var path = new List<(Point, List<Direction>)>();
   //
   //    if (!IdentifyBorderPosition(board, startingPosition).IsOnBorder())
   //       return path.Select(x => x.Item1);
   //    if (board[ startingPosition ].IsEmpty)
   //       return path.Select(x => x.Item1);
   //
   //    var startBorder = IdentifyBorderPosition(board, startingPosition);
   //    var winningSides = IdentifyWinningSides(startBorder);
   //    var current = startingPosition;
   //    
   //    // var possibleMoves = FindPossibleMoves(board, current);
   //    // foreach (var possibleMove in possibleMoves)
   //    // {
   //    //    
   //    // }
   //
   //    return path.Select(x => x.Item1);
   // }

   public bool FindWinner(GameBoard board, Point startingPosition)
   {
      if (!IdentifyBorderPosition(board, startingPosition).IsOnBorder())
         return false;
      if (board[ startingPosition ].IsEmpty)
         return false;

      var startBorder = IdentifyBorderPosition(board, startingPosition);
      var winningSides = IdentifyWinningSides(startBorder);

      return FindWinner(board, winningSides, startingPosition);
   }
   
   private bool FindWinner(GameBoard board, IEnumerable<BorderPosition> winningBorders, Point current)
   {
      var possibleMoves = FindPossibleMoves(board, current);
      foreach (var possibleMove in possibleMoves)
      {
         var possibleEdge = IdentifyBorderPosition(board, possibleMove);
         if (winningBorders.Contains(possibleEdge))
            return true;
      }

      return false;
   }

   public IEnumerable<Point> FindPossibleMoves(GameBoard board, Point current)
   {
      var possibles = new List<Point>();
      var player = board[ current ].Owner;

      foreach (var direction in Enum.GetValues<Direction>())
      {
         var possible = current;
         possible.Offset(_directionOffsets[ direction ]);

         if (!board.IsOnBoard(possible))
            continue;
         if (board[ possible ].IsEmpty)
            continue;
         if (board[ possible ].Owner != player)
            continue;
         if (board[ possible ].Stack!.TopStone!.IsWalled)
            continue;

         possibles.Add(possible);
      }

      return possibles;
   }
}
