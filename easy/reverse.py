from typing import Optional

#Definition for singly-linked list.
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next
class Solution:
    def reverseList(self, head: Optional[ListNode]) -> Optional[ListNode]:
        # Iterative way
        # prev = None
        # next = None
        # current = head
        # if not head:
        #     return head

        # while current != None:
        #     next = current.next
        #     current.next = prev
        #     prev = current
        #     current = next
        # return prev
        
        # Recursive way
        if not head or not head.next:
            return head
        
        new_head = self.reverseList(head.next)
        head.next.next = head
        head.next = None
        return new_head

def main():
    sol = Solution()
    head = ListNode(val=1, next = 
                    ListNode(val = 2, next = 
                             ListNode(val = 3, next = 
                                      ListNode(val = 4, next = 
                                               ListNode(val = 5, next = None)))))
if __name__ == "__main__":
    main()