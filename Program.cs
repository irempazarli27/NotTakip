using System;
using System.Collections.Generic;

class Program
{
    static Database db = new Database();

    static void Main(string[] args)
    {
        while (true)
        {
            Menu();
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    NotEkle();
                    break;

                case "2":
                    Listele();
                    break;

                case "3":
                    Sil();
                    break;

              

                case "0":
                    return;

                default:
                    Console.WriteLine("Hatalı seçim");
                    break;
            }

            Bekle();
        }
    }

    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("===== NOT TAKİP =====");
        Console.WriteLine("1- Not Ekle");
        Console.WriteLine("2- Listele");
        Console.WriteLine("3- Sil");
        Console.WriteLine("0- Çıkış");
        Console.Write("Seçim: ");
    }

    static void NotEkle()
    {
        Console.Write("Ad: ");
        string ad = Console.ReadLine();

        Console.Write("Ders: ");
        string ders = Console.ReadLine();

        Console.Write("Not: ");
        if (!int.TryParse(Console.ReadLine(), out int notu))
        {
            Console.WriteLine("Not sayı olmalı");
            return;
        }

        db.NotEkle(ad, ders, notu);
        Console.WriteLine("Eklendi");
    }

    static void Listele()
    {
        List<NotKaydi> liste = db.NotlariGetir();

        foreach (var n in liste)
        {
            Console.WriteLine($"{n.Id} | {n.Ad} | {n.Ders} | {n.Notu}");
        }
    }

    static void Sil()
    {
        Console.Write("Id: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
            return;

        db.NotSil(id);
        Console.WriteLine("Silindi");
    }



    static void Bekle()
    {
        Console.WriteLine("\nDevam için tuşa bas...");
        Console.ReadKey();
    }
}