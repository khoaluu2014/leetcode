from typing import Optional
# Definition for singly-linked list.
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next
class Solution:
    def removeNthFromEnd(self, head: Optional[ListNode], n: int) -> Optional[ListNode]:
        fast = slow = head
        prev = None

        #Move fast forward n times
        for _ in range(n):
            fast = fast.next
        
        if not fast:
            return head.next
        #While fast exist or fast is not the end of the list
        #Move slow to catch up with fast
        #This will leave slow at len(List) - n
        #Move prev to trail behind slow
        while fast.next:
            fast = fast.next
            slow = slow.next
        
        slow.next = slow.next.next
        return head
        
        


