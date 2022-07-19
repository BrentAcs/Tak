using Tak.Core.Game;
using Tak.Core.Services;

namespace Tak.Core.Extensions;

public static class StoneExtensions
{
   public static Stone? ToStone(this string value) =>
      NotationParser.TryParseStone(value, out var stone) ? stone : null;
}
