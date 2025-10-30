using System.Collections;
using System.Collections.Generic;
using CS_DemoCollections.Collections;

namespace CS_DemoCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ArrayListDemo();
            //StackDemo();
            //QueueDemo();
            //HashTableDemo();
            //GenericListDemo();
            //GenericStackDemo();
            //GenericQueueDemo();
            //GenericDictionaryDemo();
            //Console.WriteLine( );
            //Console.WriteLine();
            //GenericSortedDictionaryDemo();

            MyList<int> myList = new MyList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Insert(1, 4);
            Console.WriteLine("MyList Contents:");
            foreach (int obj in myList)
            {
                Console.WriteLine(obj);
            }
            myList.Remove(4);
            Console.WriteLine("\nAfter Removal:");
            foreach (int obj in myList)
            {
                Console.WriteLine(obj);
            }

            //Access element by index is not supported in MyList
            Console.WriteLine($"Element at index 2: {myList[2]}");

            //Count of Elements
            Console.WriteLine($"Total Items in MyList: {myList.Count}");


            Console.WriteLine("Program Completed. Press Any key to exit...");
            Console.ReadKey();
        }

        static void ArrayListDemo()
        {

            ArrayList list = new ArrayList();

            //Add Elements
            list.Add(1);
            list.Add(2);
            list.Add("Apple");
            list.Add(3.1412f);
            list.Add(true);
            LoopOnCollection(list);

            //Insert at a specific index
            list.Insert(2, "Banana");

            LoopOnCollection(list);

            //Remove an element by value
            list.Remove("Apple");
            LoopOnCollection(list);

            //Access element by index
            Console.WriteLine($"\nElement at index [3]: {list[3]}");

            //Count of Elements
            Console.WriteLine($"Total Items: {list.Count}");

            static void LoopOnCollection(ArrayList list)
            {
                foreach (object obj in list)
                {
                    Console.WriteLine(obj);
                }
            }
        }

        static void GenericListDemo()
        {

            List<int> list = new List<int>();

            //Add Elements
            list.Add(1);
            list.Add(2);
            //list.Add("Apple");
            //list.Add(3.1412f);
            //list.Add(true);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            LoopOnCollection(list);

            //Insert at a specific index
            //list.Insert(2, "Banana");
            list.Insert(2, 10);

            LoopOnCollection(list);

            //Remove an element by value
            //list.Remove("Apple");
            list.Remove(2);
            LoopOnCollection(list);

            //Access element by index
            Console.WriteLine($"\nElement at index [3]: {list[3]}");

            //Count of Elements
            Console.WriteLine($"Total Items: {list.Count}");

            static void LoopOnCollection(List<int> list)
            {
                foreach (int obj in list)
                {
                    Console.WriteLine(obj);
                }
            }
        }

        static void StackDemo()
        {
            //Create the stack
            Stack stack = new Stack();
            stack.Push("First");
            stack.Push(100);
            stack.Push(3.1412f);
            stack.Push(true);

            //Display stack contents
            Console.WriteLine("Stack Elements:");
            foreach (object obj in stack)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine();

            //Peek at the top item
            Console.WriteLine($"\nTop item: {stack.Peek()}");

            //Pop an item
            Console.WriteLine($"\nPopped Item: {stack.Pop()}");

            //Display the remaining elements
            foreach (object obj in stack)
            {
                Console.WriteLine(obj);
            }
        }

        static void GenericStackDemo()
        {
            //Create the stack
            Stack<int> stack = new Stack<int>();
            //stack.Push("First");
            stack.Push(100);
            //stack.Push(3.1412f);
            //stack.Push(true);
            stack.Push(200);
            stack.Push(300);
            stack.Push(400);
            stack.Push(500);

            //Display stack contents
            Console.WriteLine("Stack Elements:");
            foreach (int obj in stack)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine();

            //Peek at the top item
            Console.WriteLine($"\nTop item: {stack.Peek()}");

            //Pop an item
            Console.WriteLine($"\nPopped Item: {stack.Pop()}");

            //Display the remaining elements
            foreach (int obj in stack)
            {
                Console.WriteLine(obj);
            }
        }

        static void QueueDemo()
        {
            //Create queue
            Queue queue = new Queue();

            //Enqueue elements
            queue.Enqueue("Task 1");
            queue.Enqueue(100);
            queue.Enqueue(3.1412f);
            queue.Enqueue(true);

            Console.WriteLine("Queue contents:");
            foreach(object obj in queue)
            {
                Console.WriteLine(obj);
            }

            //Peek at the front item
            Console.WriteLine($"\nFront item: {queue.Peek()}");

            //Dequeue an item
            Console.WriteLine($"\nDequeued item: {queue.Dequeue()}");

            //Display remaining items
            Console.WriteLine("\nRemaining queue items:");
            foreach (object obj in queue)
            {
                Console.WriteLine(obj);
            }
            
        }

        static void GenericQueueDemo()
        {
            //Create queue
            Queue<string> queue = new Queue<string>();

            //Enqueue elements
            queue.Enqueue("Task 1");
            queue.Enqueue("Task 2");
            queue.Enqueue("Task 3");
            queue.Enqueue("Task 4");

            Console.WriteLine("Queue contents:");
            foreach (string obj in queue)
            {
                Console.WriteLine(obj);
            }

            //Peek at the front item
            Console.WriteLine($"\nFront item: {queue.Peek()}");

            //Dequeue an item
            Console.WriteLine($"\nDequeued item: {queue.Dequeue()}");

            //Display remaining items
            Console.WriteLine("\nRemaining queue items:");
            foreach (string obj in queue)
            {
                Console.WriteLine(obj);
            }

        }

        static void HashTableDemo()
        {
            //Create HashTable
            Hashtable ht = new Hashtable();
            ht.Add("Name", "James");
            ht.Add("Age", 35);
            ht.Add("Location", "Pune");
            ht.Add("IsActive", true);

            //Display all key-value pairs
            Console.WriteLine("HashTable Contents: ");
            foreach (object key in ht.Keys)
            {
                Console.WriteLine($"{key}: {ht[key]}");
            }
        }

        static void GenericDictionaryDemo()
        {
            //Create Dictionary
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Name", "James");
            dict.Add("Age", "35");
            dict.Add("Location", "Pune");
            dict.Add("IsActive", "true");

            //Display all key-value pairs
            Console.WriteLine("Dictionary Contents: ");
            foreach (string key in dict.Keys)
            {
                Console.WriteLine($"{key}: {dict[key]}");
            }
        }

        static void GenericSortedDictionaryDemo()
        {
            //Create SortedDictionary
            SortedDictionary<string, string> dict = new SortedDictionary<string, string>();
            dict.Add("Name", "James");
            dict.Add("Age", "35");
            dict.Add("Location", "Pune");
            dict.Add("IsActive", "true");

            //Display all key-value pairs
            Console.WriteLine("Dictionary Contents: ");
            foreach (string key in dict.Keys)
            {
                Console.WriteLine($"{key}: {dict[key]}");
            }
        }
    }
}
