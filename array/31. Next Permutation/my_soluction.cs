public class Solution{
    public void NextPermutation(int[] nums) {
        int i = nums.Length - 2;
        while (i >= 0 && nums[i + 1] <= nums[i]) {
            i--;
        }
        if (i >= 0) {
            int j = nums.Length - 1;
            while (nums[j] <= nums[i]) {
                j--;
            }
            swap(nums, i, j);
        }
        reverse(nums, i + 1);
    }
    
    private void reverse(int[] nums, int start) {
        int i = start, j = nums.Length - 1;
        while (i < j) {
            swap(nums, i, j);
            i++;
            j--;
        }
    }

    private void swap(int[] nums, int i, int j) {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}

public class SolutionFirst {
    public void NextPermutation(int[] nums) {
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