/**
 * Definition for an interval.
 * public class Interval {
 *     public int start;
 *     public int end;
 *     public Interval() { start = 0; end = 0; }
 *     public Interval(int s, int e) { start = s; end = e; }
 * }
 */
public class Solution {
    public int MinMeetingRooms(Interval[] intervals) {
        if(intervals == null || intervals.Length < 1){
            return 0;
        }
        Array.Sort(intervals, (a, b) => a.start.CompareTo(b.start));
        List<Node> rooms = new List<Node>();
        foreach(Interval meeting in intervals){
            Schedule(meeting, rooms);
        }
        return rooms.Count;
    }
    void Schedule(Interval meeting, List<Node> rooms){
        bool added = false;
        for (int i = 0; i < rooms.Count; i++){
            Node node = rooms[i];
            added = Add(ref node, meeting);
            if(added){
                rooms[i] = node;
                break;
            }
        }
        if(!added){
            rooms.Add(new Node { Value = meeting });
        }
    }
    bool Add(ref Node head, Interval meeting){
        bool success = false;
        if(meeting.end <= head.Value.start){
            Node newnode = new Node();
            newnode.Value = meeting;
            newnode.Next = head;
            head = newnode;
            newnode.Prev = head;
            return true;
        }
        Node ptr = head;
        while(ptr != null){
            if(ptr.Value.end <= meeting.start){
                if (ptr.Next != null && meeting.end <= ptr.Next.Value.start)
                {
                    Node newnode = new Node();
                    newnode.Value = meeting;
                    newnode.Next = ptr.Next;
                    newnode.Prev = ptr;
                    ptr.Next = newnode;
                    if (ptr.Next != null)
                    {
                        ptr.Next.Prev = newnode;
                    }
                    success = true;
                    break;
                }
                if(ptr.Next == null){
                    Node newnode = new Node();
                    newnode.Value = meeting;
                    newnode.Next = null;
                    newnode.Prev = ptr;
                    ptr.Next = newnode;
                    success = true;
                    break;
                }
            }else{
                break;
            }
            ptr = ptr.Next;
        }
        return success;
    }
}
public class Node{
    public Interval Value;
    public Node Next;
    public Node Prev;
}