
using System;

namespace YemekTarifUygulama.Utils
{
    public static class ConsoleMenü
    {
        public static void Goster()
        {
            Console.WriteLine("\n1 - Tarif Ekle");
            Console.WriteLine("2 - Tarif Sil");
            Console.WriteLine("3 - Tarifleri Listele");
            Console.WriteLine("0 - Çıkış\n");
            Console.Write("Seçiminiz: ");
        }
    }
}
