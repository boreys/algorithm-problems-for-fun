
ListNode node1 = new ListNode(1);
ListNode node2 = new ListNode(2);
ListNode node3 = new ListNode(3);
ListNode node4 = new ListNode(4);
ListNode node5 = new ListNode(5);

node1.next = node2;
node2.next = node4;
node3.next = node4;
node4.next = node5;

ListNode nodeB1 = new ListNode(1);
ListNode nodeB2 = new ListNode(3);
ListNode nodeB3 = new ListNode(4);
nodeB1.next = nodeB2;
nodeB2.next = nodeB3;

Solution sol = new Solution();
var result = sol.MergeTwoLists(node1, nodeB1);

Console.WriteLine($"Middle found at node value: {getString(result)}");

string getString(ListNode node)
{
    string str = "";
    ListNode head = node;
    while(head != null)
    {
        str += head.val + " -> ";
        head = head.next;
    }

    return str;
}

public class Solution
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if(list1 == null)
        {
            return list2;
        }

        if (list2 == null) return list1;

        ListNode head = list1;

        ListNode first = list1;
        ListNode second = list2;

        if (list1.val > list2.val)
        {
            head = list2;
            first = list2;
            second = list1;
        }

        while(first != null && second != null)
        {
            while(first.next != null && first.next.val < second.val)
            {
                first = first.next;
            }
            ListNode tmp = first.next;
            first.next = second;
            second = tmp;
            first = first.next;
        }

        return head;
    }
}

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x)
    {
        val = x;
        next = null;
    }
}