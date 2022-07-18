namespace Tak.Core.Game;

public enum PlayerColor
{
   White = 1,
   Black,
}

public abstract record Stone
{
   public abstract bool IsCapstone { get; }
   public PlayerColor Player { get; init; }

   protected Stone(PlayerColor player)
   {
      Player = player;
   }
}

public record FlatStone : Stone
{
   public override bool IsCapstone => false;
   public bool IsWall { get; set; }
   public bool IsFlat => !IsWall;

   public FlatStone(PlayerColor player) : base(player)
   {
   }
}

public record Capstone : Stone
{
   public override bool IsCapstone => true;

   public Capstone(PlayerColor player) : base(player)
   {
   }
}
