using System.Linq;

Solution sol = new Solution();
int[] nums = { 23, 2, 4, 6, 6 };
int k = 7;

var val = sol.CheckSubarraySum(nums, k);
Console.WriteLine($"Result: {val}");

val = sol.CheckSubarraySumBruteForce(nums, k);
Console.WriteLine($"Brute force Result: {val}");

public class Solution
{
    public bool CheckSubarraySum(int[] nums, int k)
    {
        Dictionary<int, int> seenPrefix = new Dictionary<int, int>();
        seenPrefix.Add(0, -1);

        int sum = 0;
        for(int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            int mod = sum % k;
            if(seenPrefix.ContainsKey(mod))
            {
                if((i - seenPrefix[mod]) >= 2)
                {
                    return true;
                }
            }
            else
            {
                seenPrefix.Add(mod, i);
            }
            
        }
        return false;
    }

    public bool CheckSubarraySumBruteForce(int[] nums, int k)
    {
        int[] sums = new int[nums.Length + 1];
        sums[0] = 0;

        for(int i = 1; i < sums.Length; i++)
        {
            sums[i] = sums[i - 1] + nums[i - 1];   
        }

        for(int start = 0; start < sums.Length; start++)
        {
            for (int end = start + 1; end < sums.Length; end++)
            {
                int diff = sums[end] - sums[start];
                if ((end - start) >= 2 && (diff  % k) == 0) return true;
            }
        }
        return false;
    }
}