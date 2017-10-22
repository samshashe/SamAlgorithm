using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewQuestions
{
    class DoubleLinkedList
    {
        static void Main(string[] args)
        {
            //LinkedList<int> a=new LinkedList<int>();
            MyDList x = new MyDList();
            x.addLast(6);
            x.addLast(5);
            x.addLast(3);
            x.addLast(1);
            //x.addLast(8);
            //x.addLast(4);
            //x.addLast(7);
            //x.addLast(3);
            //x.addLast(2);
            x.displayList();
            Console.WriteLine();
            //x.reverseList();
            //x.displayList();
            
            //x.sortList();

            
            x.delete(3);
            //x.deleteFirst();
            //x.insertBefore(23);
            //x.insertBefore(43);
            //x.addLast(37);
            //Console.WriteLine();
            x.displayList();

            Console.ReadKey();
        }
    }
    class MyDList
    {
        DNode head;
        public MyDList()
        {
            head = null;
        }
        public void addLast(int elem)
        {
            if (head == null)
            {
                DNode newDNode = new DNode(elem, null,null);
                head = newDNode;
            }
            else
            {
                DNode current = head;
                while (current.Next != null)
                    current = current.Next;
                DNode newDNode = new DNode(elem, null,current);
                current.Next = newDNode;
            }

        }
        public void delete(int elem)
        {
            if(head.Element == elem)
            {
                head = head.Next;
            }
            DNode current = head;
            while (current.Next != null)
            {
                if (current.Element == elem)
                {
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                    break;
                }
                current = current.Next;
            }
            // handle if last element
            if (current.Next == null && current.Element == elem)
            {
                current.Previous.Next = null;
            }
        }
        public void sortList()
        {
            DNode hold = head.Next;
            DNode curr = head.Next;
            while (hold != null)
            {
                while (curr != null)
                {
                    if (hold.Element < curr.Element)
                    {
                        int temp = hold.Element;
                        hold.Element = curr.Element;
                        curr.Element = temp;
                    }
                    curr = curr.Next;
                }
                hold = hold.Next;
                curr = head;
            }
        }
        public void reverseList()
        {
            if (head == null) return;
            DNode current = head;
            DNode temp = null;
            DNode nextcurrent = null;
            while (current!= null)
            {
                nextcurrent = current.Next;
  
                temp=current.Previous;
                current.Previous=current.Next;
                current.Next=temp;

                current = nextcurrent;
            }
            head = temp;
            

        }
        public void insertBefore(int elem)
        {
            DNode xDNode = new DNode(elem, head,null);
            head.Previous = xDNode;
            head = xDNode;
        }
        public void deleteFirst()
        {
            head = head.Next;
        }
        public void displayList()
        {
            DNode iterate = head;
            while (iterate != null)
            {

                Console.WriteLine(iterate.Element);
                iterate = iterate.Next;

            }
        }
    }
    class DNode
    {
        private DNode next;
        private DNode previous;
        private int element;
        public DNode(int element, DNode next,DNode previous)
        {
            this.Element = element;
            this.next = next;
            this.previous = previous;
        }
        public DNode Next
        {
            get { return next; }
            set { next = value; }
        
        }
        public DNode Previous
        {
            get { return previous; }
            set { previous = value; }
        }
        public int Element
        {
            get { return element; }
            set { element = value; }
        }
    }
}
