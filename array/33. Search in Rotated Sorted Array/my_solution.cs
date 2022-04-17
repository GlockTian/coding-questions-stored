public class Solution {
    public int Search(int[] nums, int target) {
        // Carefully consider the scenario
        int left = 0;
        int right = nums.Length-1;
        if(nums[left]==target){
            return left;
        }
        if(nums[right]==target){
            return right;
        }
        while (left<right){
            int mid = (left+right)/2;

            if(nums[left]==target){
                return left;
            }
            if(nums[right]==target){
                return right;
            }
            if(nums[mid]==target){
                return mid;
            }
            
            if(target<nums[left] && target>nums[right]){
                return -1;
            }
            
            if(nums[mid]>nums[left]){
                // the cliff is on the right of mid
                if(target>nums[mid]){
                    // because everything smaller is after mid
                    left=mid+1;
                }else{
                    if(target<nums[left]){
                        left=mid+1;
                    }else{
                        right=mid-1;
                    }
                }
            }else{
                // the cliff is on the left of mid
                if(target<nums[mid]){
                    // because everything smaller is before mid
                    right=mid-1;
                }else{
                    if(target<nums[left]){
                        left=mid+1;
                    }else{
                        right=mid-1;
                    }
                }
            }
        }
        return -1;
    }
}