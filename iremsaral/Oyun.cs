using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iremsaral
{
    class Oyun
    {
        KartDeste Destem = new KartDeste();
        //Her oyuncunun eli için ayrı kartlar tanımlarız.
        Kartlar[] O1 = new Kartlar[6];
        Kartlar[] O2 = new Kartlar[6];
        Kartlar[] O3 = new Kartlar[6];

        public void Baslayalım()
        {
            Destem.diz();
            Destem.Kontrol();
            Destem.Karıstır();
        }
        public void Dagıtım()
        {
            //Her oyuncunun 6 kez kart çekmesi sağlanaarak deste dagıtılır.
            for (int i = 0; i < 5; i++)
            {
                O1[i] = Destem.kartçek();
            }
            for (int j = 0; j < 5; j++)
            {
                O2[j] = Destem.kartçek();
            }
            for (int k = 0; k < 5; k++)
            {
                O3[k] = Destem.kartçek();
            }
            //özel kartlar dagıtılır.
            for (int l = 5; l < 6; l++)
            {
                O1[l] = Destem.ozelkç();
            }
            for (int m = 5; m < 6; m++)
            {
                O2[m] = Destem.ozelkç();
            }
            for (int n = 5; n < 6; n++)
            {
                O3[n] = Destem.ozelkç();
            }
        }

        public void ElYazdır()
        {
            Console.WriteLine("\n Oyuncu 1'in eli...");
            for (int i = 0; i < 6; i++)
            {
                O1[i].BilgiYaz();
            }
            Console.WriteLine("\n Oyuncu 2'nin eli...");
            for (int j = 0; j < 6; j++)
            {
                O2[j].BilgiYaz();
            }
            Console.WriteLine("\n Oyuncu 3'ün eli...");
            for (int k = 0; k < 6; k++)
            {
                O3[k].BilgiYaz();
            }
        }



        public void OyunAlanım()
        {
            Kartlar Ortadaki = new Kartlar();
            Console.WriteLine("Oyuna Hoşgeldiniz.");
            Console.WriteLine("Oyunu sırasında aşagıdaki kurallara oynamalısınız\nOyun esnnasında Büyük Küçük harflere dikkat etmelisiniz.\n Yerdeki kartın rengi veya numarasına uygun olan kartı atmalısınız.\n Elinizde uygun kart yoksa Rd kartınızı kullanabilirsiniz.\n Özel kartınızda kalmamışsa 'pas' seceneginizi kulanabilirsiniz. ");
            //Oyuna kimin başlıyacağını seçeriz.
            Random rnd = new Random();
            int s = rnd.Next(1, 4);
            Ortadaki.renk = "---";
            Ortadaki.numara = 0;
            Console.WriteLine(s + ". oyuncu oyuna başlayacak");
            if (s == 1)
            {
                El1(Ortadaki);
            }
            else if (s == 2)
            {
                El2(Ortadaki);
            }
            else
            {
                El3(Ortadaki);
            }

        }


        int k1 = 0;
        //oyuncu bir için atılan kart sayısı.
        public void El1(Kartlar ornek)
        {
            //Oyuna 1. Oyuncu Başlarsa
            if (ornek.renk == "---" && ornek.numara == 0)
            {
                Console.WriteLine("Başlangıç..\n Oyuncu 1 in sırası");
                for (int i = 0; i < 6; i++)
                {
                    O1[i].BilgiYaz();
                }
                Console.WriteLine("Renk:");
                string d = Console.ReadLine();
                if (d == "Rd")
                {
                    Console.WriteLine("Hata");
                    El1(ornek);
                }

                else
                {
                    Console.WriteLine("Numara:");
                    int b = Convert.ToInt32(Console.ReadLine());
                    //Atılmak istenen kart deste de var mı?
                    int c = 0;
                    for (int l = 0; l < 6; l++)
                    {
                        if (O1[l].renk == d && O1[l].numara == b)
                        {
                            c++;
                        }
                    }
                    if (c == 1)
                    {
                        ornek.renk = d;
                        ornek.numara = b;
                        //Ortaya atılan kartı sileriz.
                        for (int j = 0; j < 6; j++)
                        {
                            if (O1[j].renk == d && O1[j].numara == b)
                            {
                                O1[j].renk = "---";
                                O1[j].numara = 0;
                            }
                        }
                        Console.WriteLine("Ortaya atılan kart:");
                        ornek.BilgiYaz();
                        k1++;
                        El2(ornek);
                        c = 0;
                    }
                    else if (d == "pas")
                    {
                        Console.WriteLine("Sıranızı Kaybettiniz.");
                        ornek.renk = "---";
                        ornek.numara = 0;
                        El2(ornek);
                    }
                    else
                    {
                        Console.WriteLine("Lütfen elinizdeki kartlardan atınız.");
                        El1(ornek);
                    }
                }
            }
            //

            Console.WriteLine(" \n El 1:");
            for (int k = 0; k < 6; k++)
            {
                O1[k].BilgiYaz();
            }
            Console.WriteLine("Renk->");
            string a = Console.ReadLine();

            if (a == "Rd")
            {
                Console.WriteLine("K M S \n Yeni renginizi seçiniz->");
                string yeni = Console.ReadLine();
                if (yeni == "K" || yeni == "M" || yeni == "S")
                {
                    ornek.renk = yeni;
                    Console.WriteLine("Ortaya atılan kart 1:");
                    ornek.BilgiYaz();
                    k1++;
                    //kartı sileriz.
                    for (int j = 0; j < 6; j++)
                    {
                        if (O1[j].renk == "Rd" && O1[j].numara == 1)
                        {
                            O1[j].renk = "---";
                            O1[j].numara = 0;
                        }
                    }

                    if (k1 == 6)
                    {
                        Console.WriteLine("1. Oyuncu kazandı");

                    }
                    else if (k1 != 6)
                    {
                        El2(ornek);
                    }

                }

                else
                {
                    //Kırmızı mavı sarıdan baska renk seçilemez
                    Console.WriteLine("Hatalı Seçim");
                    El1(ornek);
                }
            }

            else if (a == "pas")
            {
                Console.WriteLine("Pas 1");
                El2(ornek);
            }
            else
            {
                Console.WriteLine("Numara->");
                int b = Convert.ToInt32(Console.ReadLine());

                if (a == ornek.renk || b == ornek.numara)
                {
                    ornek.renk = a;
                    ornek.numara = b;
                    Console.WriteLine("Ortaya Atılan kart 1:");
                    ornek.BilgiYaz();
                    k1++;
                    //kartı sileriz
                    for (int k = 0; k < 6; k++)
                    {
                        if (O1[k].renk == a && O1[k].numara == b)
                        {
                            O1[k].renk = "---";
                            O1[k].numara = 0;
                        }
                    }
                    //Eldeki kartlar biterse oyunu kazanır.
                    if (k1 == 6)
                    {
                        Console.WriteLine("1. Oyuncu kazandı");

                    }
                    else if (k1 != 6)
                    {
                        El2(ornek);
                    }
                }
                else
                {
                    Console.WriteLine("lütfen uygun bir kart seçiniz.");
                    El1(ornek);
                }
            }
        }



        int k2 = 0;

        public void El2(Kartlar yerdeki)
        {
            //Oyuna 2. oyuncu baslarsa
            if (yerdeki.renk == "---" && yerdeki.numara == 0)
            {
                Console.WriteLine("Eliniz:");
                for (int l = 0; l < 6; l++)
                {
                    O2[l].BilgiYaz();
                }
                Random o2 = new Random();
                int s2 = o2.Next(0, 6);
                if (O2[s2].renk == "Rd")
                {
                    Console.WriteLine("Ortaya özel kart atarak oyuna başlayamzsınız ");
                    El2(yerdeki);
                }
                else
                {
                    yerdeki.renk = O2[s2].renk;
                    yerdeki.numara = O2[s2].numara;
                    O2[s2].renk = "---";
                    O2[s2].numara = 0;
                    Console.WriteLine("Ortaya Atılan Kart 2:");
                    yerdeki.BilgiYaz();
                    El3(yerdeki);
                }
            }
            //Oyuncu 2 nin kartlarını yazdırır.
            //
            else
            {

                Console.WriteLine("\n El2:");
                for (int a = 0; a < 6; a++)
                {
                    O2[a].BilgiYaz();
                }
                for (int i = 0; i < 6; i++)
                {
                    if ((yerdeki.renk == O2[i].renk || yerdeki.numara == O2[i].numara) || (O2[i].renk == "Rd" &&O2[i].numara==2))
                    {
                        if (yerdeki.renk == O2[i].renk || yerdeki.numara == O2[i].numara)
                        {
                            yerdeki.renk = O2[i].renk;
                            yerdeki.numara = O2[i].numara;
                            //Atılan kartı sileriz.
                            O2[i].renk = "---";
                            O2[i].numara = 0;

                            Console.WriteLine("ortadaki kart 2:");
                            yerdeki.BilgiYaz();
                            k2++;
                            //Elindeki kartlar biterse oyun kazanır
                            if (k2 == 6)
                            {
                                Console.Clear();
                                Console.WriteLine("2. oyuncu kazandı.");
                                break;
                            }
                            else if (k2 != 6)
                            {
                                El3(yerdeki);
                            }
                        }

                        else if (O2[5].renk == "Rd")
                        {//elindeki renklere göre yerdeki kartın rengini değiştirir.
                            Random rnd = new Random();
                            int s = rnd.Next(0, 5);

                            if (O2[s].renk != "---")
                            {

                                string a = O2[s].renk;
                                yerdeki.renk = a;
                                //Atılan kartı sileriz.
                                O2[5].renk = "---";
                                O2[5].numara = 0;
                                Console.WriteLine(" RD2 kullanıldı. Ortadaki kart 2:");
                                yerdeki.BilgiYaz();
                                k2++;
                                if (k2 == 6)
                                {
                                    Console.Clear();
                                    Console.WriteLine("2. oyuncu kazandı.");
                                    break;
                                }
                                else if (k2 != 6)
                                {
                                    El3(yerdeki);
                                }
                            }
                            if (k2 == 5)
                            {//elinde sadece  özel kart kaldıysa rastgele bir renk seçer.
                                Random r = new Random();
                                int y = r.Next(0, 3);
                                if (y == 0)
                                {
                                    Console.Clear();
                                    yerdeki.renk = "M";
                                    Console.WriteLine(" RD2 kullanıldı. Ortadaki kart 2:");
                                    yerdeki.BilgiYaz();
                                    Console.WriteLine("2. oyuncu kazandı");
                                    break;
                                }
                                else if (y == 1)
                                {
                                    Console.Clear();
                                    yerdeki.renk = "K";
                                    Console.WriteLine(" RD2 kullanıldı. Ortadaki kart 2:");
                                    yerdeki.BilgiYaz();
                                    Console.WriteLine("2. oyuncu kazandı");
                                    break;
                                }
                                else if (y == 2)
                                {
                                    Console.Clear();
                                    yerdeki.renk = "S";
                                    Console.WriteLine(" RD2 kullanıldı. Ortadaki kart 2:");
                                    yerdeki.BilgiYaz();
                                   Console.WriteLine("2. oyuncu kazandı");
                                    break;
                                }
                            }
                        }
                    }
                 else   if ((yerdeki.renk != O2[i].renk || yerdeki.numara != O2[i].numara) && (O2[5].renk != "Rd" && O2[5].numara != 2))

                    {
                        if (k2 != 6)
                        {
                            Console.WriteLine("Pas 2.");
                            El3(yerdeki);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("2. Oyuncu kazandı");
                            break;
                        }
                    }
                }

            }
        }
        int k3 = 0;
        //3. oyuncu için atılan kart sayısı.
        public void El3(Kartlar atılan)
        {
            //Oyuna 3.Oyuncu Başlarsa
            if (atılan.renk == "---" && atılan.numara == 0)
            {
                Console.WriteLine("\n Eliniz 3:");
                for (int l = 0; l < 6; l++)
                {
                    O3[l].BilgiYaz();
                }
                Random o3 = new Random();
                int s3 = o3.Next(0, 6);
                if (O3[s3].renk == "Rd")
                {
                    Console.WriteLine("Özel kart atarak oyuna başlayamazsınız.");
                    El3(atılan);
                }
                else
                {
                    atılan.renk = O3[s3].renk;
                    atılan.numara = O3[s3].numara;
                    //ortaya atılan kart silinir
                    O3[s3].renk = "---";
                    O3[s3].numara = 0;

                    Console.WriteLine("Ortaya Atılan kart 3:");
                    atılan.BilgiYaz();
                    k3++;
                    El1(atılan);
                }
            }
            //
            //Oyuncu 3 ün kartlarını yazdırır.
            Console.WriteLine("\n El 3");
            for (int a = 0; a < 6; a++)
            {
                O3[a].BilgiYaz();
            }
            for (int i = 0; i < 6; i++)
            {
                if ((atılan.renk == O3[i].renk || atılan.numara == O3[i].numara) || (O3[i].renk == "Rd"&&O3[i].numara==3))
                {
                    if (atılan.renk == O3[i].renk || atılan.numara == O3[i].numara)
                    {
                        atılan.renk = O3[i].renk;
                        atılan.numara = O3[i].numara;
                        //Atılan kart silinir.
                        O3[i].renk = "---";
                        O3[i].numara = 0;
                        Console.WriteLine("Ortadaki kart3:");
                        atılan.BilgiYaz();

                        k3++;
                        if (k3 == 6)
                        {
                            Console.Clear();
                            Console.WriteLine("3. oyuncu kazandı");
                            break;
                        }
                        else if (k3 != 6)
                        {
                            El1(atılan);
                        }
                    }

                    if (O3[5].renk == "Rd" && O3[5].numara == 3)
                    {//Özel karta elindeki renklerden atar.
                        Random rnd = new Random();
                        int s = rnd.Next(0, 5);
                        if (O3[s].renk != "---")
                        {
                            string a = O3[s].renk;
                            atılan.renk = a;
                            //Atılan kart sileriz.
                            O3[5].renk = "---";
                            O3[5].numara = 0;
                            Console.WriteLine(" RD3 kullanıldı.Ortadaki kart 3:");
                            atılan.BilgiYaz();
                            k3++;
                            if (k3 == 6)
                            {
                                Console.Clear();
                                Console.WriteLine("3. oyuncu kazandı");
                                break;
                            }
                            else if (k3 != 6)
                            {
                                El1(atılan);
                            }

                        }//Elinde sadece Rd kaldı ise rastgele bir renk atar.
                        else if (k3 == 5)
                        {

                            Random r = new Random();
                            int y = r.Next(0, 3);
                            if (y == 0)
                            {
                                Console.Clear();
                                atılan.renk = "K";
                                Console.WriteLine(" RD3 kullanıldı.Ortadaki kart 3:");
                                atılan.BilgiYaz();
                                Console.WriteLine("3. oyuncu kazandı");
                                break;
                            }
                            else if (y == 1)
                            {
                                Console.Clear();
                                atılan.renk = "M";
                                Console.WriteLine(" RD3 kullanıldı.Ortadaki kart 3:");
                                atılan.BilgiYaz();
                                Console.WriteLine("3. oyuncu kazandı");
                                break;
                            }
                            else if (y == 2)
                            {
                                Console.Clear();
                                atılan.renk = "S";
                                Console.WriteLine(" RD3 kullanıldı.Ortadaki kart 3:");
                                atılan.BilgiYaz();
                                Console.WriteLine("3. oyuncu kazandı");
                                break;
                            }
                        }

                    }

                }
                //Pas3
            else  if ((atılan.renk != O3[i].renk || atılan.numara != O3[i].numara) && (O3[5].renk != "Rd" && O3[5].numara != 3))
                {
                    if (k3 != 6)
                    {
                        Console.WriteLine("Pas 3.");
                        El1(atılan);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("3.Oyuncu Kazandı");
                        break;
                    }
                }
            }


        }
    }
}
