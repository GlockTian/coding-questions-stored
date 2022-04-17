public class Solution {
    public IList<IList<int>> FourSum(int[] nums, int target) {
        IList<IList<int>> res = new List<IList<int>>();

        if(nums.Length<4){
            return res;
        }
        Array.Sort(nums);
        for(int i = 0; i<nums.Length; i++){
            if(i>0&&nums[i]==nums[i-1]){
                continue;
            }
            for(int j=i+1;j<nums.Length;j++){
                if(j>i+1&&nums[j]==nums[j-1]){
                    continue;
                }   
                int start = j+1;
                int end = nums.Length-1;
                while(start<end){
                    int sum = nums[i]+nums[j]+nums[start]+nums[end];
                    if(sum<target){
                        start++;
                    }else if(sum>target){
                        end--;
                    }else{
                        res.Add(new List<int>{nums[i],nums[j],nums[start],nums[end]});
                        start++;
                        end--;
                        while(nums[start]==nums[start-1]&&start<end){
                            start++;
                        }
                        while(nums[end]==nums[end+1]&&start<end){
                            end--;
                        }
                    }
                }
            }
        }
        return res;
    }
}