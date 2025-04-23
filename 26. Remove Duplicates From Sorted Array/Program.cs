int[] nums = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
int expected = 5;
string exStr = "[0,1,2,3,4...";

Solution sol = new Solution();

int result = sol.RemoveDuplicates(nums);
int[] arr = nums.Take(result).ToArray();
Console.WriteLine($"Result: {result}, array: [{string.Join(",", arr)}], expected: {expected}, array: {exStr}");

public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        int counter = 1;
        int prev = nums[0];
        int pos = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] != prev)
            {
                counter += 1;
                nums[pos++] = nums[i];
            }
            prev = nums[i];
        }
        return counter;
    }
}