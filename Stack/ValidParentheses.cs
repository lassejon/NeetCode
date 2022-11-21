namespace Stack;

public class ValidParentheses
{
    public static bool IsValid(string s) {
        if (s.Length % 2 != 0)
        {
            return false;
        }
        
        for (var i = 1; i < s.Length; i += 2)
        {
            if (s[i] == ')' && s[i - 1] == '(')
            {
                continue;
            }
            if (s[i] == ']' && s[i - 1] == '[')
            {
                continue;
            }
            if (s[i] == '}' && s[i - 1] == '{')
            {
                continue;
            }

            return false;
        }

        return true;
    }
}