public class LRUCache {
    Dictionary<int,Node> data;
    int capacity;
    int size;
    Node head;
    Node tail;
    public LRUCache(int capacity) {
        this.capacity = capacity;
        size = 0;
        data = new Dictionary<int,Node>();
        head = new Node();
        tail = new Node();
    }
    
    public int Get(int key) {
        if(!data.ContainsKey(key)){
            return -1;
        }
        Node node = data[key];
        remove(node);
        append(node);
        return node.val;
    }
    
    public void Put(int key, int value) {
        Node node;
        if(data.ContainsKey(key)){
            node = data[key];
            node.val = value;
            remove(node);
        }else{
            if(size == capacity){
                removeOldest();
            }
            node = new Node();
            node.val = value;
            node.key = key;
        }
        append(node);
        data[key] = node;
    }
    void removeOldest(){
        Node node = tail.prev;
        data.Remove(node.key);
        remove(node);
    }
    void remove(Node node){
        node.prev.next = node.next;
        node.next.prev = node.prev;
        size--;
    }
    void append(Node node){
        if(size == 0){
            tail.prev = node;
            node.next = tail;
            head.next = node;
            node.prev = head;
        }else{
            node.next = head.next;
            head.next.prev = node;
            head.next = node;
            node.prev = head;
        }
        size++;
    }
}
class Node {
    public int key;
    public int val;
    public Node prev;
    public Node next;
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */