using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA_Yemektarifi_ödev.Models;




namespace CA_Yemektarifi_ödev.Repostory.Concretes
{
    public class Concreat : IYemekTarifiRepostory
    {
        private readonly Abstract _context;

        

        public Concreat()
        {
            _context = new Abstract();
        }

        public void Ekle(YemekTarifi tarif)
        {
           
            
        }

        public void Sil(int id)
        {
            
        }

        

        public YemekTarifi Getir(int Id)
        {
            Console.WriteLine("tarifler listeleniyo");

        }
    }
}
