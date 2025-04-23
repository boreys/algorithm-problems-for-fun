int[] nums = { -1, 0 };
int target = -1;
int[] expected = { 1, 2 };
Solution sol = new Solution();

int[] result = sol.TwoSum(nums, target);

Console.WriteLine($"Result: [{string.Join(",",result)}], expected: [{string.Join(",",expected)}]");

public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        int left = 0;
        int right = numbers.Length - 1;
        while(left < right)
        {
            int sum = numbers[left] + numbers[right];
            if(sum == target)
            {
                return new int[] { left + 1, right + 1 };
            }
            if(sum > target)
            {
                right -= 1;
            }
            else
            {
                left += 1;
            }
        }
        return new int[]{ 0, 0};
    }
}