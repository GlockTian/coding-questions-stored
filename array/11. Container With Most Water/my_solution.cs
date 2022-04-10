public class Solution {
    public int MaxArea(int[] height) {
        int i = 0;
        int j = height.Length-1;
        int leftMax = height[i];        
        int rightMax = height[j];
        
        int sum = (j-i)*Math.Min(leftMax,rightMax);
        
        while(i<j){
            if(leftMax<rightMax){
                i++;
                if(leftMax<height[i]){
                    leftMax=height[i];
                }
            }else{
                j--;
                if(rightMax<height[j]){
                    rightMax=height[j];
                }
            }
            int newSum =(j-i)*Math.Min(leftMax,rightMax);
            if(sum<newSum){
                sum = newSum;
            }
        }
        return sum;
    }
}