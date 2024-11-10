using System;
using System.Collections.Generic;

public class LinkedListNode
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int ProductQuantity { get; set; }
    public LinkedListNode Next { get; set; }
}
public class Queue
{
    private LinkedListNode head;
    private LinkedListNode tail;

    public void Enqueue(int id, string name, int quantity)
    {
        LinkedListNode newNode = new LinkedListNode { ProductId = id, ProductName = name, ProductQuantity = quantity };
        if (tail == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
        }
    }

    public void Dequeue()
    {
        if (head != null)
        {
            head = head.Next;
            if (head == null)
            {
                tail = null;
            }
        }
    }

    public LinkedListNode Search(int id)
    {
        LinkedListNode current = head;
        while (current != null)
        {
            if (current.ProductId == id)
            {
                return current;
            }
            current = current.Next;
        }
        return null;
    }

    public List<LinkedListNode> GetProducts()
    {
        List<LinkedListNode> products = new List<LinkedListNode>();
        LinkedListNode current = head;
        while (current != null)
        {
            products.Add(current);
            current = current.Next;
        }
        return products;
    }

    public void SortByQuantity()
    {
        List<LinkedListNode> products = GetProducts();
        products.Sort((x, y) => x.ProductQuantity.CompareTo(y.ProductQuantity));

        head = products[0];
        LinkedListNode current = head;
        for (int i = 1; i < products.Count; i++)
        {
            current.Next = products[i];
            current = current.Next;
        }
        current.Next = null;
        tail = current;
    }
}
public class Stack
{
    private LinkedListNode top;

    public void Push(int id, string name, int quantity)
    {
        LinkedListNode newNode = new LinkedListNode { ProductId = id, ProductName = name, ProductQuantity = quantity };
        newNode.Next = top;
        top = newNode;
    }

    public void Pop()
    {
        if (top != null)
        {
            top = top.Next;
        }
    }

    public LinkedListNode Search(int id)
    {
        LinkedListNode current = top;
        while (current != null)
        {
            if (current.ProductId == id)
            {
                return current;
            }
            current = current.Next;
        }
        return null;
    }

    public List<LinkedListNode> GetProducts()
    {
        List<LinkedListNode> products = new List<LinkedListNode>();
        LinkedListNode current = top;
        while (current != null)
        {
            products.Add(current);
            current = current.Next;
        }
        return products;
    }

    public void SortByQuantity()
    {
        List<LinkedListNode> products = GetProducts();
        products.Sort((x, y) => x.ProductQuantity.CompareTo(y.ProductQuantity));

        top = products[0];
        LinkedListNode current = top;
        for (int i = 1; i < products.Count; i++)
        {
            current.Next = products[i];
            current = current.Next;
        }
        current.Next = null;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Queue productQueue = new Queue();
        Stack productStack = new Stack();
        bool isQueue = true;

        Console.WriteLine("Linked list Kuyruk(1) mi Stack(2) mi olsun?");
        int listType = int.Parse(Console.ReadLine());

        if (listType == 1)
        {
            isQueue = true;
            Console.WriteLine("Kuyruk seçildi.");
        }
        else if (listType == 2)
        {
            isQueue = false;
            Console.WriteLine("Stack seçildi.");
        }
        else
        {
            Console.WriteLine("Geçersiz seçim.");
            return;
        }

        while (true)
        {
            Console.WriteLine("İşlem seçin:");
            Console.WriteLine("1. Ekle");
            Console.WriteLine("2. Sil");
            Console.WriteLine("3. Ara");
            Console.WriteLine("4. Listele");
            Console.WriteLine("5. Sırala ve Göster");
            Console.WriteLine("0. Çıkış");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 0)
            {
                break;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Ürün ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Ürün Adı: ");
                    string name = Console.ReadLine();
                    Console.Write("Ürün Miktarı: ");
                    int quantity = int.Parse(Console.ReadLine());

                    if (isQueue)
                    {
                        productQueue.Enqueue(id, name, quantity);
                    }
                    else
                    {
                        productStack.Push(id, name, quantity);
                    }
                    break;
                case 2:
                    if (isQueue)
                    {
                        productQueue.Dequeue();
                    }
                    else
                    {
                        productStack.Pop();
                    }
                    break;
                case 3:
                    Console.Write("Aranacak Ürün ID: ");
                    int searchId = int.Parse(Console.ReadLine());
                    LinkedListNode result = isQueue ? productQueue.Search(searchId) : productStack.Search(searchId);
                    if (result != null)
                    {
                        Console.WriteLine($"Ürün Bulundu: {result.ProductName}, Miktar: {result.ProductQuantity}");
                    }
                    else
                    {
                        Console.WriteLine("Ürün bulunamadı.");
                    }
                    break;
                case 4:
                    List<LinkedListNode> products = isQueue ? productQueue.GetProducts() : productStack.GetProducts();
                    Console.WriteLine("Ürün Listesi:");
                    foreach (LinkedListNode product in products)
                    {
                        Console.WriteLine($"ID: {product.ProductId}, Adı: {product.ProductName}, Miktar: {product.ProductQuantity}");
                    }
                    break;
                case 5:
                    if (isQueue)
                    {
                        productQueue.SortByQuantity();
                    }
                    else
                    {
                        productStack.SortByQuantity();
                    }

                    List<LinkedListNode> sortedProducts = isQueue ? productQueue.GetProducts() : productStack.GetProducts();
                    Console.WriteLine("Sıralı Ürün Listesi:");
                    foreach (LinkedListNode product in sortedProducts)
                    {
                        Console.WriteLine($"ID: {product.ProductId}, Adı: {product.ProductName}, Miktar: {product.ProductQuantity}");
                    }
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim.");
                    break;
            }
        }
    }
}
