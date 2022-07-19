namespace Tak.Core.Game;

public interface ISquare
{
   IStoneStack? Stack { get; }
   bool IsEmpty { get; }
   PlayerColor Owner { get; }
}

public class Square : ISquare
{
   public IStoneStack? Stack { get; } = new StoneStack();

   public bool IsEmpty => Stack!.Count == 0;
   public PlayerColor Owner => Stack!.Owner;
}
