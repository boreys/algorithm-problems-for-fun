public class Solution {
    //runtime: O(n), space complexity: O(1)
    public void ReverseWords(char[] str) {
        if(str == null || str.Length < 1){
            return;
        }
        int start = 0;
        int end = str.Length - 1;
        reverse(str, start, end);
        start = 0;
        int stop = str.Length;
        
        for(int i=0;i<stop;i++){
            if(str[i] == ' '){
                end = i - 1;
                reverse(str, start, end);
                start = i + 1;
            }
        }
        reverse(str, start, stop - 1);
    }
    void reverse(char[] str, int start, int end){
        char tmp;
        while(start < end){
            tmp = str[start];
            str[start] = str[end];
            str[end] = tmp;
            start++;
            end--;
        }
    }
}