using System.Diagnostics;
using System.Xml;
using Spectre.Console;
using Tak.Core.Extensions;
using Tak.Core.Game;

Console.WindowHeight = 40;

var props = AnsiConsole.Profile.Capabilities; 

AnsiConsole.Profile.Capabilities.Unicode = true;

//Console.WriteLine("Hello, World!");

// var board = new[ , ]
// {
//    {"00", "01", "02", "03", "04"}, // -------------------------------------------------------------------------------- 
//    {"10", "11", "12", "13", "14"}, // --------------------------------------------------------------------------------
//    {"20", "21", "22", "23", "24"}, // --------------------------------------------------------------------------------
//    {"30", "31", "32", "33", "34"}, // --------------------------------------------------------------------------------
//    {"40", "41", "42", "43", "44"} // --------------------------------------------------------------------------------
//    
// };

//  -WC

var board = new GameBoard(8, 8);

var stone = new FlatStone(PlayerColor.White);
// var stack = new StoneStack();
// stack.Add(stone);
board[ 0, 0 ].Stack.Add(stone);

Render(0, 0, board[0,0]);

// for (int y = 0; y < board.MaxHeight; y++)
// {
//    for (int x = 0; x < board.MaxWidth; x++)
//    {
//       Render(x, y, board[ x, y ]);
//    }
//
//    Console.WriteLine();
// }

Console.ReadKey(true);

const int BoardTop = 1;
const int BoardLeft = 5;

//  -WC
void Render(int x, int y, Square? square)
{
   Console.BackgroundColor = ConsoleColor.DarkGray;
   Console.ForegroundColor = ConsoleColor.Black;

   Console.CursorLeft = BoardLeft + x * 2;
   Console.CursorTop = BoardTop + y * 2;
   Console.Write("     ");
   
   Console.CursorLeft = BoardLeft + x * 2;
   Console.CursorTop = (BoardTop + y * 2)+1;
   Console.Write("     ");
   
   Console.CursorLeft = BoardLeft + x * 2;
   Console.CursorTop = (BoardTop + y * 2)+2;
   Console.Write("     ");

   Console.CursorLeft = (BoardLeft + x * 2)+2;
   Console.CursorTop = (BoardTop + y * 2)+1;
   Console.Write($"\u2b23");

}
