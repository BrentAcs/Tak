using Tak.Core.Exceptions;

namespace Tak.Core.Game;

public interface IStoneStack : IReadOnlyList<Stone>
{
   PlayerColor Owner { get; }
   Stone? TopStone { get; }
   bool IsWalled { get; }
   bool IsCapstone { get; }
   void Add(Stone? stone);
   bool CanAddStone();
}

public class StoneStack : IStoneStack
{
   private List<Stone> _stones = new();

   public IEnumerator<Stone> GetEnumerator() => _stones.GetEnumerator();
   IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
   public int Count => _stones.Count;
   public Stone this[int index] => _stones[ index ];

   public PlayerColor Owner => GetOwner();
   public Stone? TopStone => GetTopStone();
   public bool IsWalled => GetIsWalled();
   public bool IsCapstone => GetIsCapstone();

   public void Add(Stone? stone)
   {
      if (IsWalled)
         throw new TakException("Unable to add to stack, is walled.");
      if (IsCapstone)
         throw new TakException("Unable to add to stack, is capped.");

      _stones.Add(stone ?? throw new ArgumentNullException(nameof(stone)));
   }
   
   public bool CanAddStone() =>
      TopStone is null || (!TopStone.IsWalled && TopStone is not Capstone);

   private PlayerColor GetOwner() =>
      !_stones.Any() ? PlayerColor.None : _stones[ ^1 ].Player;
   
   private bool GetIsWalled() =>
      _stones.Any() && TopStone!.IsWalled;

   private bool GetIsCapstone() =>
      _stones.Any() && TopStone!.IsCapstone;

   private Stone? GetTopStone() =>
      !_stones.Any() ? null : _stones[ ^1 ];
}
