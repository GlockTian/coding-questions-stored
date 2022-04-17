public class Solution {
    public int RemoveElement(int[] nums, int val) {
        int actualNum = 0;
        int rightIndex = nums.Length-1;
        // might be better to just use two pointers which have less codes.
        for(int i = 0; i<nums.Length; i++){
            if(rightIndex<actualNum){
                break;
            }
            while(nums[i]==val){
                nums[i] = nums[rightIndex];
                nums[rightIndex] = -1;
                rightIndex--;
            }
            if(nums[i]!=-1){
                actualNum++;
            }
        }
        return actualNum;
    }
    public int RemoveElementWithTwoPointers(int[] nums, int val) {
        int actualNum = 0;
        int rightIndex = nums.Length-1;
        while(rightIndex>=actualNum){
            if(nums[actualNum]==val){
                nums[actualNum] = nums[rightIndex];
                nums[rightIndex] = -1;
                rightIndex--;
            }else{
                actualNum++;
            }
        }
        return actualNum;
    }
}