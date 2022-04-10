public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        int[] sortedNum = (int[]) nums.Clone(); 
        Array.Sort(sortedNum);
        
        int i = 0;
        int j = nums.Length-1;
        while(i<j){
            int sum = sortedNum[i]+sortedNum[j];
            if(sum==target){
                return new int[] {Array.IndexOf(nums,sortedNum[i]),Array.LastIndexOf(nums,sortedNum[j])};
            }
            if(sum>target){
                j--;
            }else{
                i++;
            }
        }
         return new int[] {-2,-1};
    }
}