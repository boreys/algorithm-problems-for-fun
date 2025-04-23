Solution sol = new Solution();

int target = 11;
int[] nums = { 1, 1, 1, 1, 1, 1, 1, 1 };
int expected = 0;

var result = sol.MinSubArrayLen(target, nums);
Console.WriteLine($"Result: {result}, expected: {expected}");

public class Solution
{
    public int MinSubArrayLen(int target, int[] nums)
    {
        int minLen = nums.Length + 1;
        int start = 0;
        int end = 0;
        int sum = 0;

        while(end < nums.Length)
        {
            sum += nums[end];
            end += 1;

            while(sum >= target)
            {
                int len = end - start;
                if(len < minLen)
                {
                    minLen = len;
                }
                sum -= nums[start];
                start += 1;
            }
        }

        if (minLen == nums.Length + 1) return 0;

        return minLen;
    }

    public int MinSubArrayLen_BruteForce(int target, int[] nums)
    {
        int minLen = nums.Length;
        int[] sums = new int[nums.Length + 1];
        sums[0] = 0;

        for(int i = 1; i < sums.Length; i++)
        {
            sums[i] = sums[i - 1] + nums[i - 1];
        }

        if (sums[sums.Length - 1] < target) return 0;

        for(int i = 0; i < sums.Length; i++)
        {
            for(int k = i + 1; k < sums.Length; k++)
            {
                int sum = sums[k] - sums[i];
                if(sum >= target)
                {
                    int len = k - i;
                    if(len < minLen)
                    {
                        minLen = len;
                    }
                }
            }
        }

        return minLen;
    }
}