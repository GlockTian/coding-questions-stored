public class Solution
{
    public IList<IList<int>> PermuteDFSBased(int[] nums)
    {
        IList<IList<int>> res = new List<IList<int>>();

        Stack<(IList<int> explored, IList<int> unexploredIndex)> stack = new Stack<(IList<int> explored, IList<int> unexploredIndex)>();

        IList<int> unexplored = new List<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            unexplored.Add(i);
        }

        for (int i = 0; i < nums.Length; i++)
        {
            IList<int> currentUnexplored = new List<int>(unexplored);
            currentUnexplored.Remove(i);
            stack.Push((new List<int> { nums[i] }, currentUnexplored));
        }

        while (stack.Count != 0)
        {
            (IList<int> explored, IList<int> unexploredIndex) = stack.Pop();

            if (unexploredIndex.Count == 0)
            {
                res.Add(explored);
            }

            foreach (int index in unexploredIndex)
            {
                IList<int> newExplored = new List<int>(explored);
                newExplored.Add(nums[index]);
                IList<int> currentUnexplored = new List<int>(unexploredIndex);
                currentUnexplored.Remove(index);
                stack.Push((newExplored, currentUnexplored));
            }
        }
        return res;
    }

    // backtracking based
    public IList<IList<int>> Permute(int[] nums)
    {
        IList<IList<int>> list = new List<IList<int>>();
        // Arrays.sort(nums); // not necessary
        Backtrack(list, new List<int>(), nums);
        return list;
    }

    private void Backtrack(IList<IList<int>> list, List<int> tempList, int[] nums)
    {
        if (tempList.Count == nums.Length)
        {
            list.Add(new List<int>(tempList));
        }
        else
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (tempList.Contains(nums[i])) continue; // element already exists, skip
                tempList.Add(nums[i]);
                Backtrack(list, tempList, nums);
                tempList.RemoveAt(tempList.Count - 1);
            }
        }
    }
}