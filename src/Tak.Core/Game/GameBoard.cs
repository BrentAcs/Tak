namespace Tak.Core.Game;

// Board size     3x3   4x4   5x5   6x6   7x7   8x8
// Normal pieces	10	   15	   21	   30	   40	   50
// Capstone	      0	   0	   1	   1	   2[9]	2

// CornerUpperLeft      x=0,              y=0                  bottom or right
// CornerUpperRight     x=max-1           y=0                  bottom or left
// CornerLowerLeft      x=0               y=max-1              top or right
// CornerLowerRight     x-max-1           y=max-1              top or left
// LeftEdge             x=0               y != 0 and max-1     right
// RightEdge            x=max-1           y != 0 and max-1     left
// TopEdge              x != 0 and max-1  y = 0                bottom
// BottomEdge           x != 0 and max-1  y = 1                top

public class GameSetup
{
   public Size BoardSize { get; set; }
   public int NormalPieces { get; set; }
   public int Capstones { get; set; }
}

public class GameBoard
{
   public int MaxWidth => Squares?.GetLength(0) ?? 0;
   public int MaxHeight => Squares?.GetLength(1) ?? 0;

   public GameBoard() { }

   public GameBoard(Size size) : this(size.Width, size.Height)
   {
   }

   public GameBoard(int width, int height)
   {
      Squares = new Square[ width, height ];

      for (int x = 0; x < MaxWidth; x++)
      {
         for (int y = 0; y < MaxHeight; y++)
         {
            Squares[ x, y ] = new Square();
         }
      }
   }

   public Square[ , ]? Squares { get; set; }

   public Square this[int x, int y]
   {
      get => Squares![ x, y ];
      //set => SetSquare(x,y, value);
   }

   public Square this[Point point]
   {
      get => Squares![ point.X, point.Y ];
      //set => SetSquare(point.X, point.Y, value);
   }

   // private void SetSquare(int x, int y, Square? value)
   // {
   //    if (Squares is null)
   //       return;
   //    Squares[ x, y ] = value;
   // } 

   public bool IsOnBoard(Point point) =>
      point.X >= 0 && point.X < MaxWidth && point.Y >= 0 && point.Y < MaxHeight;

   // public BorderPosition IdentifyBorderPosition(int x, int y)
   //    => IdentifyBorderPosition(new Point(x, y));
   //
   // public BorderPosition IdentifyBorderPosition(Point point)
   // {
   //    var strats = new Dictionary<BorderPosition, Func<Point, bool>>
   //    {
   //       {BorderPosition.CornerUpperLeft, pt => pt.X == 0 && pt.Y == 0},
   //       {BorderPosition.CornerUpperRight, pt => pt.X == MaxWidth - 1 && pt.Y == 0},
   //       {BorderPosition.CornerLowerLeft, pt => pt.X == 0 && pt.Y == MaxHeight - 1},
   //       {BorderPosition.CornerLowerRight, pt => pt.X == MaxWidth - 1 && pt.Y == MaxHeight - 1},
   //       {BorderPosition.LeftEdge, pt => (pt.X == 0) && (pt.Y != 0 && pt.Y != MaxHeight - 1)},
   //       {BorderPosition.RightEdge, pt => (pt.X == MaxWidth - 1) && (pt.Y != 0 && pt.Y != MaxHeight - 1)},
   //       {BorderPosition.TopEdge, pt => (pt.X != 0 && pt.X != MaxWidth - 1) && (pt.Y == 0)},
   //       {BorderPosition.BottomEdge, pt => (pt.X != 0 && pt.X != MaxWidth - 1) && (pt.Y == MaxHeight - 1)}
   //    };
   //
   //    return strats.Keys.FirstOrDefault(key => strats[ key ](point));
   // }

   public void ForEach(Action<Point> action)
   {
      for (int x = 0; x < MaxWidth; x++)
      {
         for (int y = 0; y < MaxHeight; y++)
         {
            action(new Point(x, y));
         }
      }
   }

   public void ForEach(Action<Square?> action)
   {
      for (int x = 0; x < MaxWidth; x++)
      {
         for (int y = 0; y < MaxHeight; y++)
         {
            action(this[ x, y ]);
         }
      }
   }
}
