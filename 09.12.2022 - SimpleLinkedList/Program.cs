using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._12._2022___SimpleLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NodeList<string> myList = new NodeList<string> ("0");
            myList.AddLast("2");
            myList.AddLast("5");
            myList.AddLast("9");
            myList.AddLast("16");
            myList.PrintLoop();
            Console.WriteLine("Вывод чётных чисел:\n");
            myList.Loop(x =>
            {
                try
                {
                    if (int.Parse(x.ToString()) % 2 == 0)
                    {
                        Console.WriteLine(x + " - чётное число");
                    }
                }
                catch
                {
                }
            });
            Console.WriteLine("\nВывод всего списка:\n");
            myList.Loop(x => Console.Write(" " + x));
            Console.WriteLine("\n" + myList);
            Console.WriteLine("Работает foreach:");
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"В нашем списке {myList.ToString()}" +
                $" содержится {myList.Count} записей");
            Console.ReadKey();
        }
    }
    class Node <T> // Звено односвязной цепочки
    {
        public T Data { get; set; }
        public Node(T data)
        {
            Data = data;
        }
        public Node <T> Next { get; set; }
    }
    class NodeList <T> : /*IEnumerable,*/ IEnumerator <T> // Односвязная цепочка
    {
        public int Count
        {
            get
            {
                int count = 0;
                Node<T> current = Head;
                while (current.Next != null)
                {
                    count++;
                    current = current.Next;
                }
                return count + 1;
            }
        }
        int position = -1;
        public bool MoveNext()
        {
            if (position < this.Count - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }
        public object Current
        {
            get
            {
                if (position == -1 || position >= this.Count)
                {
                    throw new Exception("Некорректный индекс элемента");
                }
                else
                {
                    return position;
                }

            }

        }
        public void Reset()
        {
            position = -1;
        }
        public int Length
        {
            get
            {
                int length = 0;
                Node<T> current = Head;
                while (current != null)
                {
                    length++;
                    current = current.Next;
                }
                return length;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public Node<T> Head; // Ссылочной тип, Head - ссылка

        T IEnumerator<T>.Current => throw new NotImplementedException();

        public NodeList(T headData)
        {
            //new Node(headData);
            Head = new Node<T>(headData);
        }
        public void AddLast(T data)
        {
            Node<T> current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node<T>(data);
        }
        public void PrintLoop()
        {
            Node<T> current = Head;
            //while (current.Next != null)
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
        public void Loop(Action<object> action)
        {
            Node<T> current = Head;
            while (current != null)
            {
                action(current.Data);
                current = current.Next;
            }
        }

        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
    }

}
