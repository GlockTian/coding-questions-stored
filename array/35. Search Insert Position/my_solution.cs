public class Solution {
    public int SearchInsert(int[] nums, int target) {
        int i = 0;
        int j = nums.Length-1;
        // binary search
        while(i<=j){
            int mid = (i+j)/2;
            if(nums[mid]>target)
            {
                j = mid-1;
            }
            else if(nums[mid]<target)
            {
                i = mid+1;
            }
            else
            {
               return mid;
            }
        }
        // if not found, then return the last left index
        return i;
    }
}