public class RandomizedSet {
    List<int> list;
    Dictionary<int,int> data;
    Random rnd = new Random();
    /** Initialize your data structure here. */
    public RandomizedSet() {
        list = new List<int>();
        data = new Dictionary<int,int>();
    }
    
    /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
    public bool Insert(int val) {
        if(data.ContainsKey(val)){
            return false;
        }
        list.Add(val);
        int index = list.Count - 1;
        data[val] = index;
        return true;
    }
    
    /** Removes a value from the set. Returns true if the set contained the specified element. */
    public bool Remove(int val) {
        if(list.Count == 0 || !data.ContainsKey(val)){
            return false;
        }
        int index = data[val];
        if(index == list.Count -1){
            list.RemoveAt(index);
            data.Remove(val);
            return true;
        }
        
        int lastElement = list[list.Count - 1];
        data[lastElement] = index;
        list[index] = lastElement;
        list.RemoveAt(list.Count - 1);
        data.Remove(val);
        return true;
    }
    
    /** Get a random element from the set. */
    public int GetRandom() {
        return list[rnd.Next(list.Count)];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */