// See https://aka.ms/new-console-template for more information

using ArraysAndHashing;

var board = new char[9][];
board[0] = new char[]{'.','8','7','6','5','4','3','2','1'};
board[1] = new char[] { '2', '.', '.', '.', '.', '.', '.', '.', '.' };
board[2] = new char[] { '3', '.', '.', '.', '.', '.', '.', '.', '.' };
board[3] = new char[] { '4', '.', '.', '.', '.', '.', '.', '.', '.' };
board[4] = new char[] { '5', '.', '.', '.', '.', '.', '.', '.', '.' };
board[5] = new char[] { '6', '.', '.', '.', '.', '.', '.', '.', '.' };
board[6] = new char[] { '7', '.', '.', '.', '.', '.', '.', '.', '.' };
board[7] = new char[] { '8', '.', '.', '.', '.', '.', '.', '.', '.' };
board[8] = new char[] { '9', '.', '.', '.', '.', '.', '.', '.', '.' };
Console.WriteLine(new Soduku().IsValid(board));