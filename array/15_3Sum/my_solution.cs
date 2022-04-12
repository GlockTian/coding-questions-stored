public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        if (nums.Length < 3)
        {
            return new List<IList<int>>();
        }
        Array.Sort(nums);

        IList<IList<int>> res = new List<IList<int>>();

        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (i - 1 >= 0 && nums[i] == nums[i - 1])
            {
                continue;
            }
            int l = i + 1;
            int r = nums.Length - 1;
            while (l < r && l < nums.Length && r < nums.Length)
            {
                if (nums[i] + nums[l] + nums[r] > 0)
                {
                    r--;
                    // don't check whether it is the same as the previous one
                }
                else if (nums[i] + nums[l] + nums[r] < 0)
                {
                    l++;
                    // don't check whether it is the same as the previous one
                }
                else
                {
                    res.Add(new List<int> { nums[i], nums[l], nums[r] });
                    l++;
                    r--;

                    // only check if it has already been put in the results
                    while (l < r && l < nums.Length && nums[l] == nums[l - 1]) l++;
                    while (r + 1 < nums.Length && r >= 0 && nums[r] == nums[r + 1]) r--;
                }
            }
        }
        return res;
    }
}