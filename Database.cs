using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

class Database
{
    private string connectionString =
        "Server=localhost;Database=nottakipsistemi;Uid=root;Pwd=;";
    public void NotEkle(string ad, string ders, int notu)
    {
        try
        {
            using (MySqlConnection baglanti = new MySqlConnection(connectionString))
            {
                baglanti.Open();

                string sorgu = "INSERT INTO Notlar (Ad, Ders, Notu) VALUES (@ad, @ders, @notu)";
                MySqlCommand komut = new MySqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@ad", ad);
                komut.Parameters.AddWithValue("@ders", ders);
                komut.Parameters.AddWithValue("@notu", notu);

                komut.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Not eklenirken hata oluştu!");
            Logger.LogYaz(ex.Message);
        }
    }

    public List<NotKaydi> NotlariGetir()
    {
        List<NotKaydi> liste = new List<NotKaydi>();

        try
        {
            using (MySqlConnection baglanti = new MySqlConnection(connectionString))
            {
                baglanti.Open();

                string sorgu = "SELECT * FROM Notlar";
                MySqlCommand komut = new MySqlCommand(sorgu, baglanti);
                MySqlDataReader reader = komut.ExecuteReader();

                while (reader.Read())
                {
                    liste.Add(new NotKaydi
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Ad = reader["Ad"].ToString(),
                        Ders = reader["Ders"].ToString(),
                        Notu = Convert.ToInt32(reader["Notu"])
                    });
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Listeleme sırasında hata oluştu!");
            Logger.LogYaz(ex.Message);
        }

        return liste;
    }

    public void NotSil(int id)
    {
        try
        {
            using (MySqlConnection baglanti = new MySqlConnection(connectionString))
            {
                baglanti.Open();

                string sorgu = "DELETE FROM Notlar WHERE Id=@id";
                MySqlCommand komut = new MySqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@id", id);
                komut.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Silme sırasında hata oluştu!");
            Logger.LogYaz(ex.Message);
        }
    }
    
    }

