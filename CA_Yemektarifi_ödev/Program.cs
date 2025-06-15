using CA_Yemektarifi_ödev.Models;
using CA_Yemektarifi_ödev.Repostory;
using CA_Yemektarifi_ödev.Repostory.Concretes;
using YemekTarifUygulama.Utils;

namespace CA_Yemektarifi_ödev
{
    class Program
    {
        public static void Main(string[] args)
        {


        }
    }



}



 //Scaffold-DbContext "server=FEYZALAPTOP\SQLEXPRESS01;database=yemek sitesi;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models




class Program:Concreat
{
    static void Main()
    {
        var repo = new IYemekTarifiRepostory();
        int secim;

        do
        {
            ConsoleMenü.Goster();
            secim = Convert.ToInt32(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    Console.Write("Yemek Adı: ");
                    string ad = Console.ReadLine();
                    Console.Write("Tarif: ");
                    string tarif = Console.ReadLine();

                    repo.Ekle(new YemekTarifi
                    {
                        YemekAdı = ad,
                        Tarif = tarif,
                        YükleyenKullanıcıId = 1 // örnek
                    });

                    Console.WriteLine("Tarif eklendi");
                    break;

                case 2:
                    Console.Write("Silinecek ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    repo.Sil(id);
                    Console.WriteLine(" tarif silindi.");
                    break;

                case 3:
                    var liste = repo.Listele();
                    foreach (var t in liste)
                        Console.WriteLine( $"{t.Id} - {t.YemekAdı}: {t.Tarif}");//ilk başta hata vermiyodu anlamadım.
                    break;

                case 0:
                    Console.WriteLine("Çıkılıyor");
                    break;

                default:
                    Console.WriteLine(" Geçersiz seçim");
                    break;
            }

        } while (secim != 0);
    }
}
