﻿// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Xml;
using Tak.Core.Extensions;
using Tak.Core.Game;

Console.WriteLine("Hello, World!");

var board = new[ , ]
{
   {"00", "01", "02", "03", "04"}, // -------------------------------------------------------------------------------- 
   {"10", "11", "12", "13", "14"}, // --------------------------------------------------------------------------------
   {"20", "21", "22", "23", "24"}, // --------------------------------------------------------------------------------
   {"30", "31", "32", "33", "34"}, // --------------------------------------------------------------------------------
   {"40", "41", "42", "43", "44"} // --------------------------------------------------------------------------------
   
};

for (int y = 0; y < 5; y++)
{
   for (int x = 0; x < 5; x++)
   {
      Console.Write($"{board[ x, y ]} ");
   }

   Console.WriteLine();
}

//Console.WriteLine($"{board[ 1, 1 ]}");
Console.ReadKey(true);
