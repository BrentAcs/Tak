using Tak.Core.Game;

namespace Tak.Core.Services;

public class NotationParser
{
   private static readonly Regex _notationStonePattern = new Regex("^(?<player>[w|b])(?<stone>[f|w|c])$", RegexOptions.IgnoreCase);

   public static Stone ParseStone(string notation)
   {
      if (!TryParseStone(notation, out var stone))
         throw new ArgumentException(
            $"{nameof(notation)} with value of '{notation}', does not match pattern: '{nameof(_notationStonePattern)}'.");

      return stone!;
   }

   public static bool TryParseStone(string notation, out Stone? stone)
   {
      stone = null;
      var match = _notationStonePattern.Match(notation);
      if (!match.Success)
         return false;

      var color = ParseColor(match.Groups[ "player" ].Captures[ 0 ].Value);

      switch (match.Groups[ "stone" ].Captures[ 0 ].Value)
      {
         case "f":
         case "F":
            stone = new FlatStone(color);
            break;
         case "w":
         case "W":
            stone = new FlatStone(color, true);
            break;
         case "c":
         case "C":
            stone = new Capstone(color);
            break;
      }

      return true;
   }

   private static PlayerColor ParseColor(string token) =>
      0 == string.Compare("w", token, StringComparison.OrdinalIgnoreCase)
         ? PlayerColor.White
         : PlayerColor.Black;
}
