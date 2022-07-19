// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Xml;
using Tak.Core.Extensions;
using Tak.Core.Game;

Console.WriteLine("Hello, World!");

var boardSetup = new[ , ]
{
   {"--", "--", "--", "--", "--"}, {"--", "--", "--", "--", "--"}, {"wf", "wf", "wf", "wf", "wf"}, {"--", "--", "--", "--", "--"},
   {"--", "--", "--", "--", "--"},
   // {"--", "--", "wf", "--", "--"},
   // {"--", "--", "wf", "--", "--"}, 
   // {"--", "--", "wf", "--", "--"},
   // {"--", "--", "wf", "--", "--"},
   // {"--", "--", "wf", "--", "--"},
};

var board = CreateInitialTestBoard5by5();

// for (int y = 0; y < 5; y++)
// {
//    for (int x = 0; x < 5; x++)
//    {
//       Debug.WriteLine($"{x}, {y}");
//       Console.Write($"{(board[ x, y ].IsEmpty ? "." : "X")}");
//    }
//
//    Console.WriteLine();
// }
//
// Debug.WriteLine($"------------");
// Console.WriteLine();
//
// for (int x = 0; x < 5; x++)
// {
//    for (int y = 0; y < 5; y++)
//    {
//       Debug.WriteLine($"{x}, {y}");
//       Console.Write($"{(board[ x, y ].IsEmpty ? "." : "X")}");
//    }
//
//    Console.WriteLine();
// }

boardSetup[ 1, 2 ] = "NO";

for (int x = 0; x < 5; x++)
{
   for (int y = 0; y < 5; y++)
   {
      Debug.WriteLine($"{x}, {y}");
      Console.Write($"{boardSetup[ x, y ]}");
   }

   Console.WriteLine();
}

Console.ReadKey(true);

GameBoard CreateInitialTestBoard5by5()
{
   // ref: https://stackoverflow.com/questions/2203525/are-the-x-y-and-row-col-attributes-of-a-two-dimensional-array-backwards
   // for why it's [y, x] not [x, y]
   var board = new GameBoard(boardSetup.GetLength(0), boardSetup.GetLength(1));
   for (int y = 0; y < boardSetup.GetLength(1); y++)
   {
      for (int x = 0; x < boardSetup.GetLength(0); x++)
      {
         var stone = boardSetup[ x, y ].ToStone();
         if (stone is not null)
            board[ y, x ].Stack!.Add(stone);
      }
   }

   return board;
}
