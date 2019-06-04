public class Solution
{
    public IList<IList<int>> GetFactors(int n)
    {
        List<IList<int>> result = new List<IList<int>>();
        if(n < 2){
            return result;
        }
        FactorsHelper(n, result, new List<int>(), 1, 2);
        return result;
    }
    void FactorsHelper(int n, List<IList<int>> result, List<int> chosen, int product, int factor)
    {
        if (n == product)
        {
            result.Add(new List<int>(chosen));
        }
        else if(product < n)
        {
            for(int i = factor; i <= n / 2; i++)
            {
                //choose
                chosen.Add(i);

                //explore
                FactorsHelper(n, result, chosen, product * i, i);

                //un-choose
                chosen.RemoveAt(chosen.Count - 1);
            }
        }
    }
}