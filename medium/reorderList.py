from typing import Optional

# Definition for singly-linked list.
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next
class Solution:
    def reorderList(self, head: Optional[ListNode]) -> None:
        """
        Do not return anything, modify head in-place instead.
        """
        middle, end = head, head
        while end and end.next:
            middle = middle.next
            end = end.next.next
        reverse_head, reverse_next = None, None
        while middle:
            reverse_next = middle.next
            middle.next = reverse_head
            reverse_head = middle
            middle = reverse_next
        current = head
        while reverse_head:
            next_node = current.next
            current.next = reverse_head
            current = reverse_head
            reverse_head = next_node
        
        if current:
            current.next = None
