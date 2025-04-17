int[] arr = { -1, -1, 1 };

Solution sol = new Solution();
int k = 0;
var result = sol.SubarraySum(arr, k);
Console.WriteLine($"Result: {result}");

result = sol.SubarraySumBrutforce2(arr, k);

Console.WriteLine($"Brute force Result: {result}");

public class Solution
{
    //brute force approach to get it done
    public int SubarraySumBrutforce(int[] nums, int k)
    {
        int count = 0;
        for(int i = 0;i < nums.Length; i++)
        {
            int sum = 0;
            for(int j = i; j < nums.Length; j++)
            {
                sum += nums[j];
                if (k == sum)
                {
                    count += 1;
                }
            }
        }
        return count;
    }

    //another approach of brute force
    public int SubarraySumBrutforce2(int[] nums, int k)
    {
        int count = 0;
        int[] sums = new int[nums.Length + 1];
        sums[0] = 0;
        for (int i = 1; i <= nums.Length; i++)
        {
            sums[i] = sums[i - 1] + nums[i - 1];
        }

        for (int start = 0; start < nums.Length; start++)
        {
            for (int end = start + 1; end <= nums.Length; end++)
            {
                int diff = sums[end] - sums[start];
                if (diff == k)
                    count++;
            }
        }
        return count;
    }

    public int SubarraySum(int[] nums, int k)
    {
        int count = 0;
        Dictionary<int, int> dict = new Dictionary<int, int>();
        int sum = 0;
        dict[0] = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            int diff = sum - k;
            if (dict.ContainsKey(diff))
            {
                count += dict[diff];
            }

            if(dict.ContainsKey(sum))
            {
                int val = dict[sum] + 1;
                dict[sum] = val;
            }
            else
            {
                dict[sum] = 1;
            }
        }
        return count;
    }
    
}