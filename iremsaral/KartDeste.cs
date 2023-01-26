using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iremsaral
{
    class KartDeste
    {
        Kartlar[] Ozel = new Kartlar[3];
        Kartlar[] kart = new Kartlar[18];
        string[] Renkler = { "K", "M", "S" };
        int[] Numaralar = { 1, 2, 3, 4, 5, };
        int k = 0;
        public void diz()
        {
            //Deste oluşturulur.

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    kart[k] = new Kartlar();
                    kart[k].renk = Renkler[i];
                    kart[k].numara = Numaralar[j];
                    k++;
                }
            }
            int c = 0;
            for (int h = 0; h < 3; h++)
            {
                Ozel[c] = new Kartlar();
                Ozel[c].renk = "Rd";
                Ozel[c].numara = Numaralar[h];
                c++;
            }
        }

        public void Kontrol()
        {
            Console.WriteLine("Deste:");
            //Deste dogru olustumu kontol ederiz.
            for (int i = 0; i < 15; i++)
            {
                kart[i].BilgiYaz();
            }
            for (int j = 0; j < 3; j++)
            {
                Ozel[j].BilgiYaz();
            }
        }
        public void Karıstır()
        {
            Random rnd = new Random();
            //Deste karıstırılır.
            for (int i = 0; i < 15; i++)
            {
                int a = rnd.Next(0, 15);
                Kartlar gecici = kart[i];
                kart[i] = kart[a];
                kart[a] = gecici;

            }
        }

        //Çekilen kart sayısı=çks
        int çks = 0;
        public Kartlar kartçek()
        {
            return kart[çks++];
        }
        //Çekilen ozel kart sayısı
        int oks = 0;
        public Kartlar ozelkç()
        {
            return Ozel[oks++];
        }
    }
}
