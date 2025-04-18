int[] nums = { 3, 3, 4, 3, 0 };
int k = 3;
double expected = 3.33333;
Solution sol = new Solution();
var result = sol.FindMaxAverage(nums, k);
Console.WriteLine($"Result: {result}, expected: {expected}");


public class Solution
{
    public double FindMaxAverage(int[] nums, int k)
    {
        double max = 0;
        int stop = k;
        //calculate the first window
        double sum = 0;
        double avg = 0;
        for(int i = 0; i < nums.Length && i < k; i++)
        {
            sum += nums[i];
        }

        avg = sum / k;
        max = avg;

        for(int i=k;i<nums.Length; i++)
        {
            avg -= (double)nums[i - k] / k;
            avg += (double)nums[i] / k;
            max = Math.Max(max, avg);
        }

        return max;
    }

    public double FindMaxAverageBruteForce(int[] nums, int k)
    {
        double max = Int32.MinValue;//handle edge case => [-1]
        for (int i = 0; i < nums.Length; i++)
        {
            double sum = 0;
            for (int j = i; j < i + k && j < nums.Length; j++)
            {
                sum += nums[j];
            }
            max = Math.Max(max, sum / k);
            if (i >= nums.Length - k)
            {
                break;
            }
        }
        return max;
    }
}