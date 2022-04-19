public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        // expanded node, and the sum is smaller than the target
        Stack<Tuple<IList<int>,int>> stack = new Stack<Tuple<IList<int>,int>>();
        IList<IList<int>> res = new List<IList<int>>();
        Dictionary<int,int> mapCandidateToIndex = new Dictionary<int,int>();               
        
        for(int i = 0;i<candidates.Length;i++)
        {
            int curr = candidates[i];
            if(curr<target){
                IList<int> expandedElement = new List<int>{curr};
                stack.Push(new Tuple<IList<int>,int>(expandedElement,curr));
            }else if(curr==target){
                res.Add(new List<int>{curr});
            }
            mapCandidateToIndex.Add(curr,i);
        }
        
        // a depth first search through the state tree
        while(stack.Count!=0){
            Tuple<IList<int>,int> currentTuple = stack.Pop();           
            IList<int> current = currentTuple.Item1;

            int sum = currentTuple.Item2;
            
            int lastValue = current[current.Count-1];
            int lastIndex = mapCandidateToIndex[lastValue];
            
            for(int i=lastIndex;i<candidates.Length;i++)
            {
                IList<int> temp = new List<int>(current);
                int curr = candidates[i];
                int nextSum = curr+sum;
                temp.Add(curr);

                if(nextSum<target){
                    stack.Push(new Tuple<IList<int>,int>(temp,nextSum));
                }else if(nextSum==target){
                    res.Add(temp);
                }
            }
        }
        return res;
    }
}