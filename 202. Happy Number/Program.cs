int n = 7;
bool expected = true;

Solution sol = new Solution();
var result = sol.IsHappy(n);

Console.WriteLine($"Result: {result}, expected: {expected}");

public class Solution
{
    public bool IsHappy(int n)
    {
        int slow = getSumOfDigit(n);
        int fast = getSumOfDigit(getSumOfDigit(n));
        while(slow != 0)
        {
            slow = getSumOfDigit(slow);
            fast = getSumOfDigit(getSumOfDigit(fast));
            if(slow == fast)
            {
                break;
            }
        }
        return slow == 1;
    }

    int getSumOfDigit(int n)
    {
        int sum = 0;
        while(n > 0)
        {
            int digit = n % 10;
            sum += (digit * digit);
            n = n / 10;
        }

        return sum;
    }
}