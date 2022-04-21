public class Solution
{
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        IList<IList<int>> list = new List<IList<int>>();
        // Arrays.sort(nums); // not necessary
        Backtrack(list, new List<int>(), new HashSet<int>(), new HashSet<String>(), nums);
        return list;
    }

    public void Backtrack(IList<IList<int>> res, IList<int> temp, HashSet<int> tempIndex, HashSet<String> explored, int[] nums)
    {
        if (temp.Count == nums.Length)
        {
            res.Add(new List<int>(temp));
            return;
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (tempIndex.Contains(i))
            {
                continue;
            }

            temp.Add(nums[i]);

            String rep = string.Join(";", temp);
            if (explored.Contains(rep))
            {
                temp.RemoveAt(temp.Count - 1);
                continue;
            }

            explored.Add(rep);

            HashSet<int> newTempIndex = new HashSet<int>(tempIndex);
            newTempIndex.Add(i);
            Backtrack(res, temp, newTempIndex, explored, nums);
            temp.RemoveAt(temp.Count - 1);
        }
    }
}