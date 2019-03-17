/**
 * Definition for singly-linked list with a random pointer.
 * public class RandomListNode {
 *     public int label;
 *     public RandomListNode next, random;
 *     public RandomListNode(int x) { this.label = x; }
 * };
 */
public class Solution {
    public RandomListNode CopyRandomList(RandomListNode head) {
        if(head == null){
            return null;
        }
        RandomListNode newHead = new RandomListNode(head.label);
        newHead.next = head.next;
        newHead.random = head.random;
        
        RandomListNode ptr = head.next;
        RandomListNode newptr = newHead;
        Dictionary<int, RandomListNode> dict = new Dictionary<int, RandomListNode>();
        dict[head.label] = newHead;
        while(ptr != null){
            newptr.next = new RandomListNode(ptr.label);
            newptr.next.next = ptr.next;
            dict[ptr.label] = newptr.next;
            
            newptr = newptr.next;
            ptr = ptr.next;
        }
        ptr = head;
        newptr = newHead;
        while(ptr != null){
            if(ptr.random != null){
                newptr.random = dict[ptr.random.label];
            }
            ptr = ptr.next;
            newptr = newptr.next;
        }
        return newHead;
    }
}