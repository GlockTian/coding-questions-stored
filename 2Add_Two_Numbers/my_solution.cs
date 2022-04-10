/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode lres = new ListNode();
        int carryOver = 0;
        ListNode res = lres;

        
        // iterate through both l1 and l2, untill one of them exhausted
        while(true){
            res.val = l1.val+l2.val+carryOver;
            if(res.val>9){
                res.val=res.val-10;
                carryOver = 1;
            }else{
                carryOver = 0;
            }

            if(l1.next==null||l2.next==null)
                break;
            
            l1 = l1.next;
            l2 = l2.next;
            var nextRes = new ListNode();
            res.next = nextRes;
            res = nextRes;
        }
        
        // if l1 still have more, add them to the result nodes
        while(l1.next!=null){
            l1 = l1.next;
            var nextRes = new ListNode();
            res.next = nextRes;
            res = nextRes;
            res.val = l1.val+carryOver;
            if(res.val>9){
                res.val=res.val-10;
                carryOver = 1;
            }else{
                carryOver = 0;
            }
        }
        
        // if l2 still have more, add them to the result nodes
        while(l2.next!=null){
            l2 = l2.next;
            var nextRes = new ListNode();
            res.next = nextRes;
            res = nextRes;
            res.val = l2.val+carryOver;
            if(res.val>9){
                res.val=res.val-10;
                carryOver = 1;
            }else{
                carryOver = 0;
            }
        }
        
        // we might have carry-over bit
        if(carryOver == 1){
            var nextRes = new ListNode();
            res.next = nextRes;
            res = nextRes;
            res.val=1;
        }
        
        return lres;
    }
}