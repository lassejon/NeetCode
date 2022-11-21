using System.Text.RegularExpressions;

namespace TwoPointers;

public static class Palindrome
{
    public static bool IsValid(string s)
    {
        var leftPointer = 0;
        var rightPointer = s.Length - 1;

        while (leftPointer < rightPointer)
        {
            while (!char.IsLetterOrDigit(s[leftPointer])){
                leftPointer++;
            }
            
            while (!char.IsLetterOrDigit(s[rightPointer])){
                rightPointer--;
            }

            if (char.ToLower(s[leftPointer]) != char.ToLower(s[rightPointer]))
            {
                return false;
            }

            leftPointer++;
            rightPointer--;
        }

        return true;
    }
}