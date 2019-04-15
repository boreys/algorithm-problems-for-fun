public class Solution
{
    //runtime: O(log(m+n)), memory: O(1)
    public double FindMedianSortedArrays(int[] A, int[] B)
    {
        if (A.Length > B.Length)
        {
            int[] tmp = A;
            A = B;
            B = tmp;
        }
        int len1 = A.Length;
        int len2 = B.Length;
        int half = (len1 + len2 + 1) / 2;
        int left = 0, i, j;
        int right = len1;
        double maxLeft = 0, minRight = 0;
        while (left <= right)
        {
            i = (left + right) / 2;
            j = half - i;
            if (i >= 0 && i < len1 && A[i] < B[j - 1])
            {
                left = i + 1;
            }
            else if (i > 0 && B[j] < A[i - 1])
            {
                right = i - 1;
            }
            else
            {
                if(i == 0)
                {
                    maxLeft = B[j-1];
                }else if(j == 0)
                {
                    maxLeft = A[i-1];
                }
                else
                {
                    maxLeft = Math.Max(A[i - 1], B[j - 1]);
                }
                if((len1 + len2)%2 != 0)
                {
                    minRight = maxLeft;
                    break;
                }
                if(i == len1)
                {
                    minRight = B[j];
                }else if(j == len2)
                {
                    minRight = A[i];
                }
                else
                {
                    minRight = Math.Min(A[i], B[j]);
                }
                break;
            }
        }

        return (maxLeft + minRight) / 2;
    }
}