// See https://aka.ms/new-console-template for more information
using AdventOfCode23.Solutions;


var day1 = new Day1Trebuchet();

int solution1 = day1.GetSolution(@"C:\Users\Ana Garcia\Documents\Visual Studio 2022\AdventOfCode23\AdventOfCode23\Inputs\Day1TrebuchetInput.txt", true);
Console.WriteLine("Day1, Part1: " + solution1);

int solution2 = day1.GetSolution(@"C:\Users\Ana Garcia\Documents\Visual Studio 2022\AdventOfCode23\AdventOfCode23\Inputs\Day1TrebuchetInput.txt", false);
Console.WriteLine("Day1, Part2: " + solution2);
