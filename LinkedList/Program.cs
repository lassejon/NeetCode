// // See https://aka.ms/new-console-template for more information
//
// using System.Threading.Channels;
// using LinkedList;
//
// var left = new List<int>() {1,2,4}.ToListNode();
// var right = new List<int>() {1,3,4}.ToListNode();
//
// var sol = Solution.MergeTwoLists(left, right);
//
// Console.WriteLine(sol);
//
// var head = new List<int> { 1,2,3,4 }.ToListNode();
// Solution.ReorderList(head);
//
// Console.WriteLine(head);
//
// var removeNthHead = new List<int>() { 1,2,3,4,5 }.ToListNode();
//
// var x = Solution.RemoveNthFromEnd(removeNthHead, 2);
//
// Console.WriteLine(x);

using LinkedList;

var input = new Input(
    new string[] {"LRUCache","put","put","get","put","get","put","get","get","get"},
    new [] { new[]{2}, new[]{1,1}, new[]{2, 2}, new[]{1}, new[]{3, 3}, new[]{2}, new[]{4,4}, new[]{1}, new[]{3}, new[]{4}});
var breakpoint = "";