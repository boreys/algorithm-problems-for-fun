/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    //runtime: O(n + m) (where n is length of l1, m is length of l2)
    //space complexity: O(n+m)
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode root = new ListNode(0);
        ListNode ptr = root;
        int carryOver = 0;
        int sum = 0;
        int val;
        while(l1 != null || l2 != null){
            sum = carryOver;
            if(l1 != null){
                sum += l1.val;
                l1 = l1.next;
            }
            if(l2 != null){
                sum += l2.val;
                l2 = l2.next;
            }
            carryOver = sum / 10;
            val = sum % 10;
            ptr.next = new ListNode(val);
            ptr = ptr.next;
        }
        if(carryOver != 0){
            ptr.next = new ListNode(carryOver);
        }
        return root.next;
    }
    public ListNode AddTwoNumbersOld(ListNode l1, ListNode l2) {
        ListNode a = l1;
        ListNode b = l2;
        ListNode result = null;
        ListNode ptr = null;
        int sum = 0;
        int carryover = 0;
        int number = 0;
        while(a != null && b != null){
            sum = a.val + b.val + carryover;
            number = sum % 10;
            carryover = sum / 10;
            if(result == null){
                result = new ListNode(number);
                ptr = result;
            }else{
                ptr.next = new ListNode(number);
                ptr = ptr.next;
            }
            b = b.next;
            a = a.next;
        }
        while(a != null){
            sum = a.val + carryover;
            number = sum % 10;
            carryover = sum / 10;
            if (result == null)
            {
                result = new ListNode(number);
                ptr = result;
            }
            else
            {
                ptr.next = new ListNode(number);
                ptr = ptr.next;
            }
            a = a.next;
        }
        while (b != null)
        {
            sum = b.val + carryover;
            number = sum % 10;
            carryover = sum / 10;
            if (result == null)
            {
                result = new ListNode(number);
                ptr = result;
            }
            else
            {
                ptr.next = new ListNode(number);
                ptr = ptr.next;
            }
            b = b.next;
        }
        if(carryover != 0){
            ptr.next = new ListNode(carryover);
        }
        return result;
    }
}