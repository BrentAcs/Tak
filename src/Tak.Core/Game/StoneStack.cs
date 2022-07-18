namespace Tak.Core.Game;

public class StoneStack : IReadOnlyList<Stone>
{
   private List<Stone> _stones = new();

   public IEnumerator<Stone> GetEnumerator() => _stones.GetEnumerator();
   IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
   public int Count => _stones.Count;
   public Stone this[int index] => _stones[ index ];

   public void Add(Stone? stone)
   {
      _stones.Add(stone);
   }
   
   public bool CanAddStone()
   {
      
      return true;
   }   
   
}
