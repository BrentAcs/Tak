using Tak.Core.Game;

namespace Tak.Core.Extensions;

public static class BorderPositionExtensions
{
   public static bool IsOnBorder(this BorderPosition position) =>
      position != BorderPosition.NotOnBorder;
}
