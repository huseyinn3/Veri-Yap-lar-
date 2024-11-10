using System;
using System.Collections.Generic;

class Program
{
    static Queue<string> highPriority = new Queue<string>();
    static Queue<string> mediumPriority = new Queue<string>();
    static Queue<string> lowPriority = new Queue<string>();

    static void Main()
    {

        EnqueueCustomer("Müşteri1", 1);
        EnqueueCustomer("Müşteri2", 2);
        EnqueueCustomer("Müşteri3", 3);
        EnqueueCustomer("Müşteri4", 1);
        EnqueueCustomer("Müşteri5", 2);

   
        Console.WriteLine("Kuyruktaki Müşteriler:");
        DisplayQueue();

    
        Console.WriteLine("\nİşleme Alınan Müşteriler:");
        DequeueAndDisplay();
        DequeueAndDisplay();
        DequeueAndDisplay();
        DequeueAndDisplay();
        DequeueAndDisplay();
        Console.ReadKey();
    }

    static void EnqueueCustomer(string customer, int priority)
    {
      
        if (priority == 1)
        {
            highPriority.Enqueue(customer);
        }
        else if (priority == 2)
        {
            mediumPriority.Enqueue(customer);
        }
        else if (priority == 3)
        {
            lowPriority.Enqueue(customer);
        }
        else
        {
            Console.WriteLine("Geçersiz öncelik seviyesi");
        }
    }

    static void DequeueAndDisplay()
    {
   
        string customer = DequeueCustomer();
        Console.WriteLine("İşleme Alınıyor: " + customer);
    }

    static string DequeueCustomer()
    {
   
        if (highPriority.Count > 0)
        {
            return highPriority.Dequeue();
        }
        else if (mediumPriority.Count > 0)
        {
            return mediumPriority.Dequeue();
        }
        else if (lowPriority.Count > 0)
        {
            return lowPriority.Dequeue();
        }
        else
        {
            return "Kuyrukta müşteri yok";
        }
    }

    static void DisplayQueue()
    {
   
        foreach (var customer in highPriority)
        {
            Console.WriteLine("Yüksek Öncelikli: " + customer);
        }
        foreach (var customer in mediumPriority)
        {
            Console.WriteLine("Orta Öncelikli: " + customer);
        }
        foreach (var customer in lowPriority)
        {
            Console.WriteLine("Düşük Öncelikli: " + customer);
        }
    }
}
