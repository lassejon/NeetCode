using System.Data;

namespace LinkedList;

 public class ListNode<T> {
     public T val;
     public ListNode<T> next;
     public ListNode(T val = default!, ListNode<T> next = null) {
         this.val = val;
         this.next = next;
     }
 }

public static class ListExtensions
{
    public static ListNode<T>? ToListNode<T>(this IEnumerable<T> list)
    {
        if (list.Count() == 0)
        {
            return null;
        }
        
        var head = new ListNode<T>(list.ElementAt(0));
        
        var prev = head;
        foreach (var i in list.Skip(1))
        {
            var current = new ListNode<T>(i);
            prev.next = current;
            prev = current;
        }

        return head;
    }
}

public class Solution {
    public static ListNode<int> ReverseList(ListNode<int> head)
    {
        if (head == null) { return null; }
        
        ListNode<int> prev = null;
        while (head != null)
        {
            var temp = head.next;
            head.next = prev;
            prev = head;
            head = temp;
        }

        return prev;
    }
    
    public static ListNode<int> ReverseListRecursive(ListNode<int> head)
    {
        if (head.next == null) { return head; }
        
        
        head.next.next = head;
        
        return head.next;
    }
    
    public static ListNode<int>? MergeTwoLists(ListNode<int>? list1, ListNode<int>? list2)
    {
        if (list1 == null)
        {
            return list2;
        }

        if (list2 == null)
        {
            return list1;
        }
        
        var result = list1.val <= list2.val ? list1 : list2;

        if (list1.val <= list2.val)
        {
            list1 = list1.next;
        }
        else
        {
            list2 = list2.next;
        }
        
        var current = result;
        while (list1 != null && list2 != null)
        {
            if (list1.val <= list2.val)
            {
                current.next = list1;
                list1 = list1.next;
            }
            else
            {
                current.next = list2;
                list2 = list2.next;
            }

            current = current.next;
        }

        current.next = list2 == null ? list1 : list2;

        return result;
    }

    public static ListNode<int> MergeLists(ListNode<int> left, ListNode<int> right)
    {
        if (left == null)
        {
            return right;
        }

        if (right == null)
        {
            return left;
        }

        var result = left;

        left = left.next;
        
        var current = result;
        var i = 1;
        while (left != null && right != null)
        {
            if (i % 2 == 0)
            {
                current.next = left;
                left = left.next;
            }
            else
            {
                current.next = right;
                right = right.next;
            }

            current = current.next;
            i++;
        }

        current.next = right == null ? left : right;

        return result;
    }
    
    public static void ReorderList(ListNode<int> head)
    {
        var slow = head;
        var fast = head.next;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        
        var secondHalf = ReverseList(slow.next);
        slow.next = null;

        head = MergeLists(head, secondHalf);
    }
    
    public static ListNode<int> RemoveNthFromEnd(ListNode<int> head, int n)
    {
        var prev = head;
        var length = 1;
        while (prev != null)
        {
            var current = prev.next;
            prev = current;
            length++;
        }
        
        prev = head;
        var nodeIndexToRemove = length - n;
        var i = 1;
        while (prev != null)
        {
            var current = prev.next;
            if (i == nodeIndexToRemove)
            {
                prev.next = current.next;
            }

            prev = current;
            i++;
        }

        return head;
    }
}