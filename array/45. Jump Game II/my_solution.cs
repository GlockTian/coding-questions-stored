public class Solution
{

    // a bfs search algorithm but dynamic programming is better
    public int JumpBFS(int[] nums)
    {
        Queue<(int pos, int step)> queue = new Queue<(int pos, int step)>();

        queue.Enqueue((0, 0));
        if (nums.Length == 1)
        {
            return 0;
        }

        // pos and step, don't enqueue, if we already know a shorter path to the pos;
        Dictionary<int, int> dict = new Dictionary<int, int>();

        while (queue.Count != 0)
        {
            (int pos, int step) current = queue.Dequeue();

            if (current.pos + nums[current.pos] >= nums.Length - 1)
            {
                return current.step + 1;
            }
            else
            {
                for (int i = 1; i <= nums[current.pos]; i++)
                {
                    if (dict.ContainsKey(current.pos + i))
                    {
                        if (dict[current.pos + i] > current.step + 1)
                        {
                            queue.Enqueue((current.pos + i, current.step + 1));
                            dict[current.pos + i] = current.step + 1;
                        }
                    }
                    else
                    {
                        queue.Enqueue((current.pos + i, current.step + 1));
                        dict[current.pos + i] = current.step + 1;
                    }
                }
            }
        }
        return -1;
    }


    // dynamic programming
    public int JumpDoubleFor(int[] nums)
    {
        // to know the shortest step to position i
        // we ask the previous position: i-1, i-2, i-3, i-4.... 0, whether they can reach i and select the lowest steps + 1
        int[] steps = new int[nums.Length];

        steps[0] = 0;

        for (int i = 1; i < nums.Length; i++)
        {
            int minimunStep = Int32.MaxValue;
            for (int j = 0; j < i; j++)
            {
                if (j + nums[j] >= i && steps[j] + 1 < minimunStep)
                {
                    minimunStep = steps[j] + 1;
                }
            }
            steps[i] = minimunStep;
        }
        return steps[nums.Length - 1];
    }

    public int Jump(int[] nums)
    {
        int curEnd = 0;
        int cufFarthest = 0;
        int jumpStep = 0;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            // Farthest pos the players can jump to based on the explored pos
            cufFarthest = Math.Max(cufFarthest, nums[i] + i);
            if (i == curEnd)
            {
                jumpStep++;
                curEnd = cufFarthest;// player has jump to curEnd
            }
            if (curEnd >= nums.Length - 1) break;
        }
        return jumpStep;
    }
}