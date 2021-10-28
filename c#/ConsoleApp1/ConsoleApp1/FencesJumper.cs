using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    /// <summary>
    /// Task description:
    /// You are playing a game where your character jumps over fences. To win he needs to reach the finish line, in our case it meansto get to the last index of the array
    /// The value in the array means how many fences the caracter must step over.Your task is to swap the cells in the array in places so that the hero can jump to the end position
    /// Output true if it is possible to win the game, otherwise - false
    /// Input: fences - array of jump length values. The character starts with index 0
    /// Output: Bool - is it possible to win
    /// Example: fences = [0, 2, 4, 1, 6, 2]
    /// GetResult(fences) = True
    /// Explaination: swap the cells in places this way: [1, 4, 2, 0, 6, 2]. The hero jumped from the 0th index to the 1st (because fences[0]=1), then he jumped from index 1 to 5 (fences[1]=4) 5 is the last index of the array - he won.
    /// </summary>
    class FencesJumper
    {
        public static bool GetResult(List<int> fences)
        {
            // Write your code here...
            var goalPosition = fences.Count() - 1;
            var coursors = new List<int>();
            for (var i = 0; i < fences.Count(); i++)
            {
                InitCursors(coursors, i);
                foreach (var s in GetSums(fences, coursors))
                {
                    if (s == goalPosition)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static void InitCursors(List<int> cursors, int n)
        {
            cursors.Clear();
            for (var i = 0; i <= n; i++)
            {
                cursors.Add(i);
            }
        }

        //Moves cursor index
        private static bool MoveCursors(List<int> cursors, int fencesLength)
        {
            var maxFencesIndex = fencesLength - 1;
            for (var i = cursors.Count() - 1; i >= 0; i--)
            {
                if (MoveCursor(cursors, i, maxFencesIndex))
                {
                    return true;
                }
            }

            return false;
        }

        //Moves cursor value
        private static bool MoveCursor(List<int> cursors, int CursorIndex, int maxFencesIndex)
        {
            var revertedCursorIndex = cursors.Count() - 1 - CursorIndex;
            if (cursors[CursorIndex] < maxFencesIndex - revertedCursorIndex)
            {
                cursors[CursorIndex] = cursors[CursorIndex] + 1;
                //reset values of the descendant cursors
                for (var i = CursorIndex + 1; i < cursors.Count(); i++)
                {
                    cursors[i] = cursors[i - 1] + 1;
                }
                return true;
            }
            return false;
        }

        private static IEnumerable<int> GetSums(List<int> fences, List<int> cursors)
        {
            yield return GetSum(fences, cursors);
            while (MoveCursors(cursors, fences.Count()))
            {
                yield return GetSum(fences, cursors);
            }
        }

        private static int GetSum(List<int> fences, List<int> cursors)
        {
            var sum = 0;
            foreach (var i in cursors)
            {
                sum += fences[i];
            }
            return sum;
        }

        public static void RunCode()
        {
            // Entrypoint to debug your function
            GetResult(new List<int>() { 0, -1, 2, 2, 4, 8 });
            GetResult(new List<int>() { 1, 0, 3 });
            GetResult(new List<int>() { 2, -1, 0, 2 });
            GetResult(new List<int>() { 0, 2, 4, 1, 6, 2 });
        }
    }
}

