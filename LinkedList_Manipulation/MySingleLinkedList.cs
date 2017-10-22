using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewQuestions
{
    class MySingleLinkedList
    {
        static void Main1(string[] args)
        {
            MyList x = new MyList();
            x.AddLast(1);
            x.AddLast(5);
            x.AddLast(5);
            x.AddLast(5);
            x.AddLast(1);
            x.AddLast(9);
            x.displayList();
            //x.deleteAllOccurences2(5);
            //x.displayMiddle();
            //Console.WriteLine("nth===============>"+x.FindLastNthElement(10));
            //x.SortedInsert(122);
            //x.SortedDeleteBefore(4);
            //x.displayLastFive();
            x.SortList();
            //x.reverseList();
            //Node insertNode = new Node(4,null);
            //x.InsertNode(insertNode);
            //x.displayList();
            //x.DeleteLast();
            //x.deleteFirst();
            //x.InsertBeginning(23);
            //x.InsertBeginning(43);
            //x.addLast(37);
            //x.displayMiddle();
            //Console.WriteLine();
            //x.dispalyLastFive2();
            x.displayList();

            Console.ReadKey();
        }
    }
    class MyList
    {
        Node head;
        public MyList()
        {
            head = null;
        }
        public void InsertBeginning(int elem)
        {
            Node xNode = new Node(elem, head);
            head = xNode;
        }
        public void AddLast(int elem)
        {
            Node newNode = new Node(elem, null);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                    current = current.Next;
                current.Next = newNode;
            }

        }
        public void deleteFirst()
        {
            if (head != null)
                head = head.Next;
        }
        public void DeleteLast()
        {
            if (head == null || head.Next == null)
            {
                head = null;
                return;
            }
            Node current = head, previous = head;
            while (current.Next != null)
            {
                previous = current;
                current = current.Next;
            }
            previous.Next = null;

        }
        public void displayList()
        {
            Node iterate = head;
            while (iterate != null)
            {
                Console.WriteLine(iterate.Element);
                iterate = iterate.Next;
            }
            Console.WriteLine("================================================");
        }
        public void displayLastFive()
        {
            Node x1, x2, x3, x4, x5;
            x1 = x2 = x3 = x4 = null;
            x5 = head;
            while (x5.Next != null)
            {
                x1 = x2;
                x2 = x3;
                x3= x4;
                x4 = x5;
                x5 = x5.Next;
            }
            while(x1!=null)
            {
                Console.WriteLine(x1.Element);
                x1 = x1.Next;
            }
        }
        public void dispalyLastFive2()
        {
            Node fast = head;
            Node slow = head;
            for (int i = 0; i < 5; i++)
            {
                if (fast != null)
                    fast = fast.Next;
                else
                {
                    Console.WriteLine("Elements are less than five");
                    return;
                }
            }
            while(slow!=null)
            {
                if (fast != null)
                    fast = fast.Next;
                else
                {
                    Console.WriteLine(slow.Element);
                }
                slow = slow.Next;
            }
        }
        public  int FindLastNthElement( int n)
        {
            if (n<1)
            {
                throw new Exception("index n can't be less than 1");
            }
            Node fast = head;
            Node slow = head;
            int i = 0;
            while (i < n && fast != null)
            {
                i++;
                fast = fast.Next;
            }
            if (i < n)
            {
                //either we throw Exception or display a note
                throw new Exception("index n can't be greater that the size of the linked list");
            }
            else
            {
                while (fast != null)
                {
                    fast = fast.Next;
                    slow = slow.Next;
                   
                }
            }
            return slow.Element;
        }
        public void deleteAllOccurences1(int elem)
        {
            if (head == null)
                return;
            Node current = head;
            while (current.Next != null)
            {
                if (head.Element == elem)
                {
                    current = head = head.Next;
                    continue;
                }
                if (current.Next.Element == elem)
                    current.Next = current.Next.Next;
                else
                    current = current.Next;
            }
            //if all are the same handle last
            if (head.Element == elem)
                head = head.Next;
        }
        public void deleteAllOccurences2(int elem)
        {
            // tested works
            if (head == null)
                return;
            
            while (head.Element == elem)
            {
                head = head.Next;
            }
            Node current = head;

            while (current.Next != null  )
            {
                if (current.Next.Element == elem)
                {
                    current.Next = current.Next.Next;
                }
                else
                {
                    current = current.Next;
                }
            }
        }
        public void SortList()
        {
            Node hold=head;
            Node curr=head;
            while(hold!=null )
            {
                while(curr!=null)
                {
                    if(hold.Element<curr.Element)
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
        public void SortList2()
        {
            Node current = head;
            Node outerCurrent = head;
            Node previous = null;
            while (outerCurrent.Next != null)
            {
                while (current.Next != null)
                {
                    Node nextNode = current.Next;

                    if (current.Element > nextNode.Element)
                    {   
                        current.Next = nextNode.Next;
                        nextNode.Next = current;
                        if (previous == null)
                            head = nextNode;
                        else 
                            previous.Next = nextNode;

                        current = nextNode;
                    }
                    previous = current;
                    current = current.Next;
                }
                current = head;
                previous = null;
                outerCurrent = outerCurrent.Next;

            }
        }
        public void reverseList()
        {

            Node t1,t2,t3;
            t1 = null;
            t2 = head;
            t3 = head.Next;
            while (t3!= null)
            {
                t2.Next = t1;

                t1 = t2;
                t2 = t3;
                t3 = t3.Next;
            }
            t2.Next = t1;
            head = t2;
           
        }
        public void SortedInsert(int data)
        {
            Node newNode = new Node(data);
            if (head == null || head.Element > data)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null && current.Next.Element < data)
                    current = current.Next;
                newNode.Next = current.Next;
                current.Next = newNode;
            }

        }
        
        //inserts Node in a sorted list
        public void InsertNode( Node nd)
        {
            
            if (head == null || (head.Element > nd.Element))
            {
                Console.WriteLine("sam");
                nd.Next = head;
                head = nd;
            }
            else
            {
                Node current = head;
                while (current.Next != null && current.Next.Element < nd.Element)
                    current = current.Next;
                nd.Next = current.Next;
                current.Next = nd;
            }
        }
        public void displayMiddle()
        {
            if (head == null) return;
            Node slow = head;
            Node fast = head.Next;
            int count = 1;
            while (fast != null)
            {
                fast = fast.Next; count++;
                if (fast != null)
                {
                    fast = fast.Next;
                    slow = slow.Next;
                    count++;
                }
                
            }
            string middle = slow.Element.ToString();
            if (count % 2 == 0)
                middle = slow.Element.ToString() + " AND " + slow.Next.Element.ToString(); 
            Console.WriteLine("Middle element= "+middle);

        }
        public void SortedDeleteBefore(int data)
        {
            if(head == null )
                return;
            Node current = head,previous=head;
            while (current.Next != null && current.Next.Element!=data)
            {
                previous=current;
                current = current.Next;
            }
            if (current.Next != null)
            {
                if (current == head)
                    head = current.Next;
                else
                    previous.Next = current.Next;
            }
        }
        /*unsafe void DeleteBefore(Node* head, int finddata)
        {
            if (head == null)
                return;
            Node* current = head;
            Node* previous = head;
            while (current->Next != null && current->Next->Element != finddata)
            {
                previous = current;
                current = current->Next;
            }
            if (current->Next != null)
                previous->Next = current->Next;
        }
        */

        //unsafe bool DeleteNth(int n)
        //{ 
        //  Node *current, *previous;
        //  int count=0;
        //  previous = NULL;/*for first node there is no previous*/
        //  for (current = head; current != NULL && count<n ;count++) 
        //  {
        //     previous = current;
        //     current = current->getNext();
        //  }
        //  if (current!=NULL) 
        //  {   /* Found it. */ 
        //      if (previous == NULL) 
        //      {
        //        /* Fix beginning pointer. */
        //        head = current->getNext();
        //      } 
        //      else 
        //      {
        //         previous->setNext(current->getNext());
        //      }
              
        //      delete current;  /* Deallocate the node. */
        //      return true;   /* Done searching. */
        //   }

        //  return false;  /* index is greater than total number of elements */
        //}

    }

    class Node
    {
        private Node next;
        private int element;
        public Node(int element):this(element,null)
        {
            
        }
        public Node(int element,Node next)
        {
            this.element = element;
            this.next = next;
        }
        public Node Next
        {
            get { return next; }
            set { next = value; }
        }
        public int Element
        {
            get { return element; }
            set { element = value; }
        }
    }
}
