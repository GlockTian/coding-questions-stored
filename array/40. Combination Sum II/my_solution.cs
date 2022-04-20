public class Solution
{
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        // expanded node, and the sum is smaller than the target
        // tuple(SelectedCandidates, index of last selected candidate, current sum)
        Stack<Tuple<IList<int>, int, int>> stack = new Stack<Tuple<IList<int>, int, int>>();
        IList<IList<int>> res = new List<IList<int>>();
        Array.Sort(candidates);
        HashSet<String> explored = new HashSet<String>();

        for (int i = 0; i < candidates.Length; i++)
        {
            int curr = candidates[i];
            IList<int> expandedElement = new List<int> { curr };
            String rep = string.Join(";", expandedElement);

            if (explored.Contains(rep))
                continue;

            explored.Add(rep);

            if (curr < target)
            {
                stack.Push(new Tuple<IList<int>, int, int>(expandedElement, i, curr));
            }
            else if (curr == target)
            {
                res.Add(expandedElement);
            }
        }

        // a depth first search through the state tree
        while (stack.Count != 0)
        {
            Tuple<IList<int>, int, int> currentTuple = stack.Pop();
            IList<int> current = currentTuple.Item1;
            int lastIndex = currentTuple.Item2 + 1;
            int sum = currentTuple.Item3;

            for (int i = lastIndex; i < candidates.Length; i++)
            {
                IList<int> temp = new List<int>(current);
                int curr = candidates[i];
                int nextSum = curr + sum;
                temp.Add(curr);
                String rep = string.Join(";", temp);
                if (explored.Contains(rep))
                    continue;

                explored.Add(rep);

                if (nextSum < target)
                {
                    stack.Push(new Tuple<IList<int>, int, int>(temp, i, nextSum));
                }
                else if (nextSum == target)
                {
                    res.Add(temp);
                }
            }
        }

        return res;
    }
}