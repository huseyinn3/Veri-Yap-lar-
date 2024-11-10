using System;

public class Node
{
    public int Data;
    public Node Next;
}

public class CircularLinkedList
{
    private Node head = null;
    private Node tail = null;

    
    public void AddToEnd(int data)
    {
        Node newNode = new Node { Data = data };
        if (head == null)
        {
            head = newNode;
            tail = newNode;
            newNode.Next = head;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
            tail.Next = head;
        }
    }

    
    public void AddToBeginning(int data)
    {
        Node newNode = new Node { Data = data };
        if (head == null)
        {
            head = newNode;
            tail = newNode;
            newNode.Next = head;
        }
        else
        {
            newNode.Next = head;
            head = newNode;
            tail.Next = head;
        }
    }

    
    public void AddAtPosition(int data, int position)
    {
        Node newNode = new Node { Data = data };
        if (position == 0)
        {
            AddToBeginning(data);
        }
        else
        {
            Node temp = head;
            for (int i = 0; i < position - 1 && temp.Next != head; i++)
            {
                temp = temp.Next;
            }
            newNode.Next = temp.Next;
            temp.Next = newNode;
            if (temp == tail)
            {
                tail = newNode;
                tail.Next = head;
            }
        }
    }

    
    public void RemoveFromBeginning()
    {
        if (head == null) return;

        if (head == tail)
        {
            head = null;
            tail = null;
        }
        else
        {
            head = head.Next;
            tail.Next = head;
        }
    }

   
    public void RemoveFromEnd()
    {
        if (head == null) return;

        if (head == tail)
        {
            head = null;
            tail = null;
        }
        else
        {
            Node temp = head;
            while (temp.Next != tail)
            {
                temp = temp.Next;
            }
            temp.Next = head;
            tail = temp;
        }
    }

    
    public void RemoveAtPosition(int position)
    {
        if (head == null) return;

        if (position == 0)
        {
            RemoveFromBeginning();
        }
        else
        {
            Node temp = head;
            for (int i = 0; i < position - 1 && temp.Next != head; i++)
            {
                temp = temp.Next;
            }
            temp.Next = temp.Next.Next;
            if (temp.Next == head)
            {
                tail = temp;
            }
        }
    }

   
    public void Display()
    {
        if (head == null)
        {
            Console.WriteLine("Liste boş.");
            return;
        }

        Node temp = head;
        do
        {
            Console.Write(temp.Data + " -> ");
            temp = temp.Next;
        }
        while (temp != head);
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        CircularLinkedList list = new CircularLinkedList();
        int choice, data, position;

        do
        {
            Console.WriteLine("\nİşlemi seçin:");
            Console.WriteLine("1. Ekleme");
            Console.WriteLine("2. Baştan Ekleme");
            Console.WriteLine("3. İstenilen Sırada Ekleme");
            Console.WriteLine("4. Sondan Ekleme");
            Console.WriteLine("5. Silme");
            Console.WriteLine("6. Baştan Silme");
            Console.WriteLine("7. İstenilen Sırada Silme");
            Console.WriteLine("8. Sondan Silme");
            Console.WriteLine("9. Listeyi Göster");
            Console.WriteLine("0. Çıkış");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                case 4:
                    Console.Write("Eklenecek veriyi girin: ");
                    data = int.Parse(Console.ReadLine());
                    list.AddToEnd(data);
                    break;
                case 2:
                    Console.Write("Eklenecek veriyi girin: ");
                    data = int.Parse(Console.ReadLine());
                    list.AddToBeginning(data);
                    break;
                case 3:
                    Console.Write("Eklenecek veriyi girin: ");
                    data = int.Parse(Console.ReadLine());
                    Console.Write("Eklenecek sırayı girin: ");
                    position = int.Parse(Console.ReadLine());
                    list.AddAtPosition(data, position);
                    break;
                case 5:
                case 8:
                    list.RemoveFromEnd();
                    break;
                case 6:
                    list.RemoveFromBeginning();
                    break;
                case 7:
                    Console.Write("Silinecek sırayı girin: ");
                    position = int.Parse(Console.ReadLine());
                    list.RemoveAtPosition(position);
                    break;
                case 9:
                    list.Display();
                    break;
                case 0:
                    Console.WriteLine("Çıkış yapılıyor...");
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim.");
                    break;
            }
        }
        while (choice != 0);
        Console.ReadKey();

    }
   
}
