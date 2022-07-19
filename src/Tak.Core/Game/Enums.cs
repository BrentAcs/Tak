namespace Tak.Core.Game;

public enum PlayerColor
{
   None = 0,
   White = 1,
   Black,
}

public enum Direction
{
   Up = 1,
   Down,
   Left,
   Right
}

[Flags]
public enum BorderPosition
{
   NotOnBorder = 0,
   CornerUpperLeft = 1,
   CornerUpperRight,
   CornerLowerLeft,
   CornerLowerRight,
   LeftEdge,
   RightEdge,
   TopEdge,
   BottomEdge
}
