public class Solution {
    public void NextPermutation(int[] nums) {
        // can be improved
        int lastAscIndex = -1;// find the first index that is the last ascending part of the int array
        int rightMostIndex = -1;// the index of the value to replace lastAscIndex
        int rightMostValue = 101;
        for(int i = 0; i<nums.Length; i++){
            if(i<nums.Length-1&&nums[i+1]>nums[i]){
                lastAscIndex = i;
                rightMostIndex = -1;
                rightMostValue = 101;
            }
            if(lastAscIndex!=-1&&nums[i]>nums[lastAscIndex]&&nums[i]<rightMostValue){
                rightMostIndex = i;
                rightMostValue = nums[i];
            }
        }
        
        if(lastAscIndex!=-1){
            if(rightMostIndex!=-1){
                int temp = nums[rightMostIndex];
                nums[rightMostIndex] =nums[lastAscIndex];
                nums[lastAscIndex] = temp;
                Array.Sort(nums,lastAscIndex+1,nums.Length-lastAscIndex-1);
            }
        }else{
            Array.Reverse(nums);
        }
    }
}