namespace Tak.Core.Exceptions;

[ExcludeFromCodeCoverage]
public class TakException : Exception
{
   public TakException()
   {
   }

   public TakException(string message)
      : base(message)
   {
   }

   public TakException(string message, Exception inner)
      : base(message, inner)
   {
   }
}

