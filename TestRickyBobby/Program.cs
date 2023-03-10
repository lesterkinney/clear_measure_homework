using PrintRickyBobby;
using PrintRickyBobby.Models;
using System.Diagnostics;

Stopwatch sw = Stopwatch.StartNew();
RickyBobby printer = new RickyBobby();
RickyBobbyArgument arguments = new RickyBobbyArgument();
arguments.UpperBound = int.MaxValue;
arguments.ModNamePairs.Add("string1", 3);
arguments.ModNamePairs.Add("string2", 4);
arguments.Page = 25;
arguments.PageCount = 1000000;
arguments.MaximumUpperBoundAllowed= int.MaxValue;

var list = printer.PrintRickyBobby(arguments).ToList();


Console.WriteLine($"\n{sw.ElapsedMilliseconds / 1000} seconds elapsed.");
sw.Stop();
list.ForEach(x => Console.WriteLine(x));