using System;

class Program
{
    static void Main()
    {
        int[] hashTable = new int[100];
        int[] keys = new int[100];
        Random rand = new Random();

      
        for (int i = 0; i < hashTable.Length; i++)
        {
            hashTable[i] = -1;
        }

       
        for (int i = 0; i < keys.Length; i++)
        {
            keys[i] = rand.Next(1, 1000);
        }

        
        foreach (int key in keys)
        {
            QuadraticProbingInsert(hashTable, key);
        }

        
        Console.WriteLine("");
        Console.WriteLine("Quadratic Probing ile Hash Tablosu:");
        Console.WriteLine("");
        for (int i = 0; i < hashTable.Length; i++)
        {
            if (hashTable[i] != -1)
            {
                Console.WriteLine($"Index: {i}, Key: {hashTable[i]}");
            }
        }
        Console.ReadKey();
    }

    static void QuadraticProbingInsert(int[] hashTable, int key)
    {
        int tableSize = hashTable.Length;
        int index = key % tableSize;
        int originalIndex = index;
        int i = 1;

        while (hashTable[index] != -1)
        {
            index = (originalIndex + i * i) % tableSize;
            i++;
            if (i == tableSize)
            {
                Console.WriteLine("Hata: Hash tablosu doldu ve çakışmalar çözülemiyor.");
                return;
            }
        }
        hashTable[index] = key;
    }
}
