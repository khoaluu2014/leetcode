namespace leetcode
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Node(int _val)
    {
        public int val = _val;
        public Node next = null;
        public Node random = null;
    }

    public class LinkedList
    {
        public void ReorderList(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            ListNode second = slow.next;
            ListNode prev = null;
            slow.next = null;

            while (second != null)
            {
                ListNode tmp = second.next;
                second.next = prev;
                prev = second;
                second = tmp;
            }

            ListNode first = head;
            second = prev;
            while (second != null)
            {
                ListNode tmp1 = first.next;
                ListNode tmp2 = second.next;
                first.next = second;
                second.next = tmp1;
                first = tmp1;
                second = tmp2;
            }
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode dummy = new ListNode(0, head);
            ListNode slow = dummy,
                fast = head;

            for (int i = 0; i < n; i++)
            {
                fast = fast.next;
            }
            while (fast != null)
            {
                slow = slow.next;
                fast = fast.next;
            }

            slow.next = slow.next.next;
            return dummy.next;
        }

        public Node copyRandomList(Node head)
        {
            Dictionary<Node, Node> copy = new Dictionary<Node, Node>();

            Node cur = head;
            while (cur != null)
            {
                Node newNode = new Node(cur.val);
                copy[cur] = newNode;
                cur = cur.next;
            }

            cur = head;
            while (cur != null)
            {
                Node newNode = copy[cur];
                newNode.next = cur.next == null ? null : copy[cur.next];
                newNode.random = cur.random == null ? null : copy[cur.random];
                cur = cur.next;
            }

            return head == null ? null : copy[head];
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode ans = new ListNode();
            ListNode cur = ans;

            int carry = 0;
            while (l1 != null || l2 != null || carry != 0)
            {
                int v1 = (l1 != null) ? l1.val : 0;
                int v2 = (l2 != null) ? l2.val : 0;
                int val = v1 + v2 + carry;
                carry = val / 10;
                val = val % 10;
                cur.next = new ListNode(val);
                cur = cur.next;
                l1 = (l1 != null) ? l1.next : null;
                l2 = (l2 != null) ? l2.next : null;
            }

            return ans.next;
        }

        public bool HasCycle(ListNode head)
        {
            ListNode slow = head,
                fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow.Equals(fast))
                    return true;
            }
            return false;
        }

        public int FindDuplicate(int[] nums)
        {
            int slow = 0,
                fast = 0;

            while (true)
            {
                slow = nums[slow];
                fast = nums[nums[fast]];
                if (slow == fast)
                {
                    break;
                }
            }

            int slow2 = 0;
            while (true)
            {
                slow2 = nums[slow2];
                slow = nums[slow];
                if (slow == slow2)
                {
                    break;
                }
            }

            return slow;
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            ListNode MergeList(ListNode l1, ListNode l2)
            {
                ListNode sorted = new ListNode();
                ListNode current = sorted;

                while (l1 != null && l2 != null)
                {
                    if (l1.val <= l2.val)
                    {
                        current.next = l1;
                        l1 = l1.next;
                    }
                    else if (l2.val < l1.val)
                    {
                        current.next = l2;
                        l2 = l2.next;
                    }
                    current = current.next;
                }
                if (l1 != null)
                {
                    current.next = l1!;
                }
                if (l2 != null)
                {
                    current.next = l2!;
                }
                return sorted.next;
            }
            if (lists.Length == 0)
            {
                return null;
            }
            while (lists.Length > 1)
            {
                ListNode[] mergedLists = new ListNode[(lists.Length + 1) / 2];
                for (int i = 0; i < lists.Length; i += 2)
                {
                    ListNode? l1 = lists[i];
                    ListNode? l2 = (i + 1 < lists.Length) ? lists[i + 1] : null;
                    mergedLists[i / 2] = MergeList(l1, l2);
                }
                lists = mergedLists;
            }
            return lists[0];
        }
    }

    public class Node1
    {
        public int Key { get; set; }
        public int Val { get; set; }
        public Node1? Prev { get; set; }
        public Node1? Next { get; set; }

        public Node1(int key, int val)
        {
            Key = key;
            Val = val;
            Prev = null;
            Next = null;
        }
    }

    public class LRUCache
    {
        private int cap;
        private Dictionary<int, Node1> cache;
        private Node1? left;
        private Node1? right;

        public LRUCache(int capacity)
        {
            cap = capacity;
            cache = new Dictionary<int, Node1>();
            left = new Node1(0, 0);
            right = new Node1(0, 0);
            left.Next = right;
            right.Prev = left;
        }

        private void Remove(Node1 node)
        {
            Node1 prev = node.Prev!;
            Node1 next = node.Next!;
            prev.Next = next;
            next.Prev = prev;
        }

        private void Insert(Node1 node)
        {
            Node1 prev = right.Prev;
            prev.Next = node;
            node.Prev = prev;
            node.Next = right;
            right.Prev = node;
        }

        public int Get(int key)
        {
            if (cache.ContainsKey(key))
            {
                Node1 node = cache[key];
                Remove(node);
                Insert(node);
                return node.Val;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (cache.ContainsKey(key))
            {
                Remove(cache[key]);
            }

            Node1 node = new Node1(key, value);
            cache[key] = node;
            Insert(node);

            if (cache.Count > cap)
            {
                Node1 lru = left.Next;
                Remove(lru);
                cache.Remove(lru.Key);
            }
        }
    }
}
