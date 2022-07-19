using FluentAssertions;
using Tak.Core.Exceptions;
using Tak.Core.Game;

namespace Tak.Core.Tests.Game;

public class StoneStackTests
{
   // ----- Count

   [Fact]
   public void Count_WillBe_IncrementedByOne_AfterAdd()
   {
      var sut = new StoneStack();
      var priorCount = sut.Count;

      sut.Add(new FlatStone(PlayerColor.White));

      sut.Count.Should().Be(priorCount + 1);
   }

   // ----- Owner

   [Fact]
   public void Owner_WillBe_NoneWhenEmpty()
   {
      var sut = new StoneStack();

      var owner = sut.Owner;

      owner.Should().Be(PlayerColor.None);
   }

   [Fact]
   public void Owner_WillBeWhite_LastPlacesIsWhite()
   {
      var sut = new StoneStack();

      sut.Add(new FlatStone(PlayerColor.Black));
      sut.Add(new FlatStone(PlayerColor.White));

      var owner = sut.Owner;

      owner.Should().Be(PlayerColor.White);
   }

   
   // ----- TopStone

   [Fact]
   public void TopStone_WillBe_NullWhenEmpty()
   {
      var sut = new StoneStack();

      var top = sut.TopStone;

      top.Should().BeNull();
   }

   [Fact]
   public void TopStone_WillBe_SameAsLastAdded()
   {
      var sut = new StoneStack();
      var stone = new FlatStone(PlayerColor.White);
      sut.Add(stone);

      var top = sut.TopStone;

      ReferenceEquals(top, stone).Should().BeTrue();
   }

   // ----- IsWalled
   
   [Fact]
   public void IsWalled_WillBeFalse_OnEmpty()
   {
      var sut = new StoneStack();

      var isWalled = sut.IsWalled;

      isWalled.Should().BeFalse();
   }

   [Fact]
   public void IsWalled_WillBeFalse_WhenTopIsFlat()
   {
      var sut = new StoneStack();
      sut.Add(new FlatStone(PlayerColor.White));

      var isWalled = sut.IsWalled;

      isWalled.Should().BeFalse();
   }

   [Fact]
   public void IsWalled_WillBeTrue_WhenTopIsWalled()
   {
      var sut = new StoneStack();
      sut.Add(new FlatStone(PlayerColor.White, true));

      var isWalled = sut.IsWalled;

      isWalled.Should().BeTrue();
   }

   [Fact]
   public void IsWalled_WillBeFalse_WhenTopIsCapstone()
   {
      var sut = new StoneStack();
      sut.Add(new Capstone(PlayerColor.White));

      var isWalled = sut.IsWalled;

      isWalled.Should().BeFalse();
   }

   // ----- IsCapstone
   
   [Fact]
   public void IsCapstone_WillBeFalse_OnEmpty()
   {
      var sut = new StoneStack();

      var isWalled = sut.IsCapstone;

      isWalled.Should().BeFalse();
   }

   [Fact]
   public void IsCapstone_WillBeFalse_WhenTopIsFlat()
   {
      var sut = new StoneStack();
      sut.Add(new FlatStone(PlayerColor.White));

      var isWalled = sut.IsCapstone;

      isWalled.Should().BeFalse();
   }

   [Fact]
   public void IsCapstone_WillBeFalse_WhenTopIsWalled()
   {
      var sut = new StoneStack();
      sut.Add(new FlatStone(PlayerColor.White, true));

      var isWalled = sut.IsCapstone;

      isWalled.Should().BeFalse();
   }

   [Fact]
   public void IsCapstone_WillBeTrue_WhenTopIsCapstone()
   {
      var sut = new StoneStack();
      sut.Add(new Capstone(PlayerColor.White));

      var isWalled = sut.IsCapstone;

      isWalled.Should().BeTrue();
   }
  
   // ----- CanAddStone

   [Fact]
   public void CanAddStone_IsTrue_WhenEmpty()
   {
      var sut = new StoneStack();

      var result = sut.CanAddStone();

      result.Should().BeTrue();
   }

   [Fact]
   public void CanAddStone_IsTrue_WhenTopStoneIsFlat()
   {
      var sut = new StoneStack();
      sut.Add(new FlatStone(PlayerColor.White));

      var result = sut.CanAddStone();

      result.Should().BeTrue();
   }

   [Fact]
   public void CanAddStone_IsFalse_WhenTopStoneIsWall()
   {
      var sut = new StoneStack();
      sut.Add(new FlatStone(PlayerColor.White, true));

      var result = sut.CanAddStone();

      result.Should().BeFalse();
   }
   
   [Fact]
   public void CanAddStone_IsFalse_WhenTopStoneIsCapstone()
   {
      var sut = new StoneStack();
      sut.Add(new Capstone(PlayerColor.White));

      var result = sut.CanAddStone();

      result.Should().BeFalse();
   }
   
   // ----- Add
   
   [Fact]
   public void Add_WillThrow_WhenTopStoneIsWall()
   {
      var sut = new StoneStack();
      sut.Add(new FlatStone(PlayerColor.White, true));

      var action = () => sut.Add(new FlatStone(PlayerColor.White));

      action.Should().ThrowExactly<TakException>().WithMessage("Unable to add to stack, is walled.");
   }
   
   [Fact]
   public void Add_WillThrow_WhenTopStoneIsCapstone()
   {
      var sut = new StoneStack();
      sut.Add(new Capstone(PlayerColor.White));

      var action = () => sut.Add(new FlatStone(PlayerColor.White));

      action.Should().ThrowExactly<TakException>().WithMessage("Unable to add to stack, is capped.");
   }
}
