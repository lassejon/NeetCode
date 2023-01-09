using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;

namespace LinkedList;

 public class ListNode<T> {
     public T val;
     public ListNode<T> next;
     public ListNode(T val = default!, ListNode<T> next = null) {
         this.val = val;
         this.next = next;
     }
 }

public class Node<T> {
    public T val;
    public Node<T> next;
    public Node<T> random;
    
    public Node(T _val) {
        val = _val;
        next = null;
        random = null;
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
    
    private static int FindCycleIndex(this int[] nums)
    {
        var fastPointer = 0;
        var slowPointer = 0;

        while (fastPointer != slowPointer)
        {
            fastPointer = nums[fastPointer];
            fastPointer = nums[fastPointer];
            slowPointer = nums[slowPointer];
        }

        var startPointer = 0;

        while (slowPointer != startPointer)
        {
            startPointer = nums[startPointer];
            slowPointer = nums[slowPointer];
        }

        return nums[slowPointer];
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

        if (length == n)
        {
            return head.next;
        }
        
        prev = head;
        var nodeIndexToRemove = length - n - 1;
        var i = 0;
        while (prev != null)
        {
            var current = prev.next;
            if (i == nodeIndexToRemove)
            {
                prev.next = current.next;
                break;
            }

            prev = current;
            i++;
        }

        return head;
    }
    
    public static Node<int> CopyRandomList(Node<int> head)
    {
        var oldToCopy = new Dictionary<Node<int>, Node<int>>();

        var cur = head;
        while (cur != null)
        {
            oldToCopy[cur] = new Node<int>(cur.val);
            cur = cur.next;
        }

        cur = head;

        var i = 0;
        Node<int> result = null;
        while (cur != null)
        {
            var copy = oldToCopy[cur];
            copy.next = oldToCopy[cur.next];
            copy.random = oldToCopy[cur.random];
            
            if (i == 0)
            {
                result = copy;
            }

            cur = cur.next;
            i++;
        }

        return result;
    }
    
    public static int FindDuplicate(int[] nums) 
    {
        var fastPointer = 0;
        var slowPointer = 0;

        while (fastPointer != slowPointer)
        {
            fastPointer = nums[fastPointer];
            fastPointer = nums[fastPointer];
            slowPointer = nums[slowPointer];
        }

        var startPointer = 0;

        while (slowPointer != startPointer)
        {
            startPointer = nums[startPointer];
            slowPointer = nums[slowPointer];
        }

        return nums[slowPointer];
    }
    
    private static ListNode<int> AddTwoNumbersBetter(ListNode<int> l1, ListNode<int> l2)
    {
        var carry = 0;

        var prev = new ListNode<int>();
        var result = prev;
        while (l1 != null || l2 != null || carry != 0)
        {
            if(l1 != null)
            {
                carry = l1.val;
                l1 = l1.next;
            }

            if(l2 != null)
            {
                carry = l2.val;
                l2 = l2.next;
            }

            var res= Math.DivRem(carry, 10, out carry);

            var current = new ListNode<int>(res);

            prev.next = current;
            prev = current;
        }

        return result;
    }

    public static ListNode<int> AddTwoNumbers(ListNode<int> l1, ListNode<int> l2)
    {
        var carry = 0;
        var result = new ListNode<int>();

        var i = 0;
        var prev = new ListNode<int>();
        while (l1 != null || l2 != null)
        {
            var res = 0;
            if (l1 != null)
            {
                res += l1.val;
                l1 = l1.next;

            }

            if (l2 != null)
            {
                res += l2.val;
                l2 = l2.next;
            }

            if (res > 9)
            {
                carry = 1;
                res -= 10;
            }
            else
            {
                carry = 0;
            }

            prev.next = new ListNode<int>(res);
            prev = prev.next;
            
            if (i == 0)
            {
                result = prev;
                i++;
            }
        }

        prev.next = carry != 0 ? new ListNode<int>(carry) : null;

        return result;
    }
    
    public static bool HasCycle(ListNode<int>? head)
    {
        var current = head;
        var hashSet = new HashSet<ListNode<int>>();
        
        while (current is { })
        {
            if (hashSet.Contains(current))
            {
                return true;
            }
            
            hashSet.Add(current);
            current = current.next;
        }

        return false;
    }
}