namespace Tak.Core.Game;

public abstract record Stone
{
   public abstract bool IsFlat { get; }
   public bool IsWalled { get; init; }
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
   public override bool IsFlat => !IsWalled;

   public FlatStone(PlayerColor player) : base(player)
   {
   }
   
   public FlatStone(PlayerColor player, bool isWalled) : base(player)
   {
      IsWalled = isWalled;
   }
   
}

public record Capstone : Stone
{
   public override bool IsCapstone => true;
   public override bool IsFlat => false;

   public Capstone(PlayerColor player) : base(player)
   {
   }
}
