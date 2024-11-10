using System;

public class HashtabloLinearProbing
{
    private int[] hashtablo; // Hash tablosunu temsil eden dizi.
    private int size; // Hash tablosunun boyutu.

    public HashtabloLinearProbing(int size)
    {
        this.size = size; // Hash tablosunun boyutunu sınıfın boyutuna atıyoruz.
        hashtablo = new int[size]; // Boyutu belirtilen hash tablosu dizisini oluşturuyoruz.
        for (int i = 0; i < size; i++)
        {
            hashtablo[i] = -1; // Hash tablosunu başlangıçta boş (-1) ile dolduruyoruz.
        }
    }

    public void Insert(int key)
    {
        int hashIndex = key % size; // Division metodunu kullanarak hash index hesaplıyoruz.

        // Çakışma çözümü için linear probing (doğrusal araştırma) kullanıyoruz.
        while (hashtablo[hashIndex] != -1)
        {
            hashIndex = (hashIndex + 1) % size; // Çakışma durumunda sonraki indeksi kontrol ediyoruz.
        }
        hashtablo[hashIndex] = key; // Anahtarı hash tablosuna yerleştiriyoruz.
    }


}

class Program
{
    static void Main()
    {


        Console.ReadKey();
    }
}
