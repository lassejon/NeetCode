// See https://aka.ms/new-console-template for more information
using System;
using System.Runtime.Intrinsics.X86;

Console.WriteLine("Hello, World!");

// var case1 = new List<string> { "rabbbit", "rabbit" };
// var case2 = new List<string> { "babgbag", "bag" };
// var case3 = new List<string> { "adbdadeecadeadeccaeaabdabdbcdabddddabcaaadbabaaedeeddeaeebcdeabcaaaeeaeeabcddcebddebeebedaecccbdcbcedbdaeaedcdebeecdaaedaacadbdccabddaddacdddc", "bcddceeeebecbc" };
//
// new List<List<string>>() { case1, case2, case3 }.ForEach(c => 
// {
//     Console.WriteLine("");
//     Console.WriteLine($"case: {c}");
//     Console.WriteLine($" solution: {Backtracking.Backtracking.NumDistinctRecursive(c[0], c[1])}");
// });

var nums = new [] { -1,2,-1,2,1,-1,2,1 };
var nums2 = new [] { 1, 1, 2 }; 

var result = Backtracking.Backtracking.PermuteUnique(nums2);

foreach (var list in result)
{
    Console.Write("[");
    foreach (var var in list)
    {
        Console.Write($"{var}, ");
    }
    Console.WriteLine("]");
}