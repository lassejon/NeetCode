using System.Data;

namespace LinkedList;

 public class ListNode {
     public int val;
     public ListNode next;
     public ListNode(int val=0, ListNode next=null) {
         this.val = val;
         this.next = next;
     }
 }

public class Solution {
    public ListNode ReverseList(ListNode head)
    {
        if (head == null) { return null; }
        
        ListNode prev = null;
        while (head != null)
        {
            var temp = head.next;
            head.next = prev;
            prev = head;
            head = temp;
        }

        return prev;
    }
    
    public ListNode ReverseListRecursive(ListNode head)
    {
        if (head.next == null) { return head; }
        
        
        head.next.next = head;
        
        return head.next;
    }
    
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode result = null;

        var current = result;
        while (list1 != null && list2 != null)
        {
            if (list1.val <= list2.val)
            {
                current = list1;
                list1 = list1.next;
            }
            else
            {
                current = list2;
                list2 = list2.next;
            }

            current = current.next;
        }

        return result;
    }
}