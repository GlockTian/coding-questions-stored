public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int start = 0;
        int end = 0;         
        int n = 1;
        HashSet<char> window = new HashSet<char>();
        if(String.IsNullOrEmpty(s)){
            return 0;
        }
        
        if(String.IsNullOrWhiteSpace(s)){
            return 1;
        }
        
        while(end < s.Length){
            char c = s[end];
            if(window.Contains(c)){
                start = start+1;
                end = start;
                window.Clear();
            }else{
                window.Add(c);
                end++;
            }
            if(n< end-start ){
                n = end-start;
            }
        }
        return n;
    }
}