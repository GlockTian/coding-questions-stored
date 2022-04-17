public class Solution {
    public int[] SearchRange(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;
        int firstMid = BinarySearch(nums, target, left, right, true);

        if (firstMid == -1)
        {
            return new int[] { -1, -1 };
        }

        left = 0;
        right = nums.Length - 1;
        int lastMid = BinarySearch(nums, target, left, right, false);

        return new int[] { firstMid, lastMid };
    }

    private static int BinarySearch(int[] nums, int target, int left, int right, bool isFirstTarget)
    {
        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (nums[mid] > target)
            {
                right = mid - 1;
            }
            else if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                if (isFirstTarget && mid - 1 >= 0 && nums[mid - 1] == target)
                {
                    right = mid;
                    continue;
                }
                
                if(!isFirstTarget &&mid + 1 < nums.Length && nums[mid + 1] == target){
                    left = mid+1;
                    continue;
                }
                
                return mid;
            }
        }
        return -1;
    }
}