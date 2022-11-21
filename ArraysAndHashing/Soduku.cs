namespace ArraysAndHashing;

public class Soduku
{
    public bool IsValid(char[][] board)
    {
        const int subBoxesPerRow = 3;
        
        var columnHashSets = new HashSet<char>[board.Length].Select(h => new HashSet<char>()).ToArray();
        var subBoxesHashSets = new HashSet<char>[subBoxesPerRow].Select(h => new HashSet<char>[subBoxesPerRow].Select(hs => new HashSet<char>()).ToArray()).ToArray();
        
        for (var row = 0; row < board.Length; row++)
        {
            var rowHashSet = new HashSet<char>();

            for (var col = 0; col < board.Length; col++)
            {
                var cellValue = board[row][col];

                // Check for empty space
                if (cellValue == '.')
                {
                    continue;
                }
                // Check row
                if (rowHashSet.Contains(cellValue))
                {
                    return false;
                }
                rowHashSet.Add(cellValue);
                
                // Check column
                if (columnHashSets[col].Contains(cellValue))
                {
                    return false;
                }
                columnHashSets[col].Add(cellValue);
                
                // Check sub-boxes
                var subBoxRow = row / subBoxesPerRow;
                var subBoxColumn = col / subBoxesPerRow;
                if (subBoxesHashSets[subBoxRow][subBoxColumn].Contains(cellValue))
                {
                    return false;
                }
                subBoxesHashSets[subBoxRow][subBoxColumn].Add(cellValue);
            }
        }

        return true;
    }
}