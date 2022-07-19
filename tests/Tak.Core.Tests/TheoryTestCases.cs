namespace Tak.Core.Tests;

// credit:  https://andrewlock.net/creating-strongly-typed-xunit-theory-test-data-with-theorydata/
public abstract class TheoryTestCases : IEnumerable<object[]>
{
   readonly List<object?[]> _data = new();

   protected void AddRow(params object?[] values) =>
      _data.Add(values);

   public IEnumerator<object[]> GetEnumerator() =>
      _data.GetEnumerator();

   IEnumerator IEnumerable.GetEnumerator() =>
      GetEnumerator();
}

public class TheoryTestCases<T1> : TheoryTestCases
{
   public void AddCase(T1 p1) =>
      AddRow(p1);
}

public class TheoryTestCases<T1, T2> : TheoryTestCases
{
   public void AddCase(T1 p1, T2 p2) =>
      AddRow(p1, p2);
}

public class TheoryTestCases<T1, T2, T3> : TheoryTestCases
{
   public void AddCase(T1 p1, T2 p2, T3 p3) =>
      AddRow(p1, p2, p3);
}

public class TheoryTestCases<T1, T2, T3, T4> : TheoryTestCases
{
   public void AddCase(T1 p1, T2 p2, T3 p3, T4 p4) =>
      AddRow(p1, p2, p3, p4);
}

public class TheoryTestCases<T1, T2, T3, T4, T5> : TheoryTestCases
{
   public void AddCase(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5) =>
      AddRow(p1, p2, p3, p4, p5);
}
