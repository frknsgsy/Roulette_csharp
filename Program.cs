using System.Data;

namespace rulet
{
    internal class Program
    {
        static void Main(string[] args)
        {
        //rulet
        back2:

            string hesapbakiye = @"C:\Users\Furkan\source\repos\rulet\ruletbakiye.txt";
            string hesapbakiye_ = File.ReadAllText(hesapbakiye);
            double bakiye = Convert.ToDouble(hesapbakiye_);
            Random rnd = new();
            int[] sayılar = [0, 27, 10, 25, 29, 12, 8, 19, 31, 18, 6, 21, 33, 16, 4, 23, 35, 14, 2, 0, 28, 9, 26, 30, 11, 7, 20, 32, 17, 5, 22, 34, 15, 3, 24, 36, 13, 1];
            int[] red = [27, 25, 12, 19, 18, 21, 16, 23, 14, 9, 30, 7, 32, 5, 34, 3, 36, 1];
            int[] black = [10, 29, 8, 31, 6, 33, 4, 35, 2, 28, 26, 11, 20, 17, 22, 15, 24, 13];
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Rulet masasına hoşgeldiniz. Lütfen bahis oynamak istediğiniz sayıyı giriniz.");
            int sec = Convert.ToInt32(Console.ReadLine());
            if (sec > 36 || sec < 0)
            {
                Console.WriteLine("Lütfen 0 ile 36 arası bir sayı seçiniz");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                goto back2;
            }
        back1:
            Console.WriteLine("Oynayacağınız bahis tutarını giriniz.");
            int bahis = Convert.ToInt32(Console.ReadLine());
            if (bahis > bakiye || bahis == 0)
            {
                Console.WriteLine($"1'e basarak bankaya gidebilir ya da bahisinizi 1 - {bakiye} arası yapabilirsiniz.");
                int tus = Convert.ToInt32(Console.ReadLine());
                if (tus == 1)
                {
                    Console.Clear();
                    double deneme=Convert.ToDouble(Banka(bakiye));
                    File.WriteAllText(hesapbakiye, Convert.ToString(deneme));
                    hesapbakiye_ = File.ReadAllText(hesapbakiye);
                    bakiye = Convert.ToDouble(hesapbakiye_);

                }
                Console.Clear();
                goto back1;
            }
            bakiye -= bahis;
            int gelen = 0;
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;
            Console.Clear();
            int dizim = rnd.Next(72, 144);
            for (int i = 0; i < dizim; i++)
            {
                if (i < 72) b = 100;
                else if (i <= 144) b = 200;
                Renk(d, red, black);
                Console.WriteLine("  " + d + "  ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("> ");
                Renk(c, red, black);
                Console.Write(c);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" <");
                Renk(sayılar[a], red, black);
                Console.WriteLine("  " + sayılar[a] + "  ");
                System.Threading.Thread.Sleep(b);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                gelen = c;
                d = c;
                c = sayılar[a];
                if (a == 37) a = 0;
                else a++;
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            string gelenrenk = " ";
            string secrenk = " ";
            for (int i = 0; i < red.Length; i++)
            {
                if (gelen == 0)
                {
                    gelenrenk = "green";
                }
                else if (gelen == red[i])
                {
                    gelenrenk = "red";
                }
                else if (gelen == black[i])
                {
                    gelenrenk = "black";
                }
                if (sec == 0)
                {
                    secrenk = "green";
                }
                else if (sec == red[i])
                {
                    secrenk = "red";
                }
                else if (sec == black[i])
                {
                    secrenk = "black";
                }
            }
            if (sec == gelen)
            {
                bahis *= 36;
                bakiye += bahis;
                File.WriteAllText(hesapbakiye, Convert.ToString(bakiye));
                Renk(gelen, red, black);
                Console.WriteLine(gelen);
                Renk(sec, red, black);
                Console.WriteLine(sec);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Kazandınız. Yeni bakiyeniz : " + bakiye);
            }
            else if (secrenk == gelenrenk)
            {
                bahis *= 2;
                bakiye += bahis;
                File.WriteAllText(hesapbakiye, Convert.ToString(bakiye));
                Renk(gelen, red, black);
                Console.WriteLine(gelen);
                Renk(sec, red, black);
                Console.WriteLine(sec);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Kazandınız. Yeni bakiyeniz : " + bakiye);
            }
            else
            {
                bahis = 0;
                bakiye += bahis;
                File.WriteAllText(hesapbakiye, Convert.ToString(bakiye));
                Renk(gelen, red, black);
                Console.WriteLine(gelen);
                Renk(sec, red, black);
                Console.WriteLine(sec);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Kaybettiniz. Yeni bakiyeniz : " + bakiye);
            }
        geri11:
            Console.WriteLine("Tekrar oynamak için 1'e, ATM'ye gitmek için 2'ye, Çıkış yapmak için 3'e basın.");
            int secim = Convert.ToInt32(Console.ReadLine());
            if (secim == 1)
            {
                Console.Clear();
                goto back2;
            }
            else if (secim == 2)
            {
                Console.Clear();
                File.WriteAllText(hesapbakiye, Convert.ToString(Banka(bakiye)));
                hesapbakiye_ = File.ReadAllText(hesapbakiye);
                bakiye = Convert.ToDouble(hesapbakiye_);
                goto geri11;
            }
            else 
            {
                Console.Clear();
                Console.WriteLine("Başarıyla çıkış yapıldı.İyi günler :)");
                Environment.Exit(1);
            }


        }
        static void Renk(int x, int[] a, int[] b)
        {
            if (x == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            for (int i = 0; i < 18; i++)
            {
                if (x == a[i])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (x == b[i])
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                }
            }
        }
        static double Banka(double bahis)
        {
            string hesapbakiye = @"C:\Users\Furkan\source\repos\rulet\atmbakiye.txt";
            string hesapbakiye_ = File.ReadAllText(hesapbakiye);
            double bakiye = Convert.ToDouble(hesapbakiye_);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        geri2:
            Console.WriteLine("ATM'ye hoşgeldiniz.");
            Console.WriteLine("Yapmak istediğiniz işlemi seçiniz;");
            Console.WriteLine("1 - Bakiye öğrenme");
            Console.WriteLine("2 - Para çek");
            Console.WriteLine("3 - Para yatır");
            Console.WriteLine("4 - Çıkış yap");
            string x = Console.ReadLine();
            Console.Clear();

            switch (x)
            {
                case "1":
                    Console.WriteLine("Bakyeniz = " + bakiye + "TL");
                back3:
                    Console.WriteLine("İşlem başarıyla gerçeklştirildi.Başka işlem yapmak ister misiniz?");
                    Console.WriteLine("1 ) Ana Menü");
                    Console.WriteLine("2 ) Çıkış");
                    int islem = Convert.ToInt32(Console.ReadLine());

                    if (islem == 1)
                    {
                        Console.WriteLine("Ana menüye dönüyorsunuz.");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        goto geri2;
                    }
                    else if (islem == 2)
                    {
                        Console.WriteLine("Çıkış yapıldı.İyi günler dileriz.");
                    }
                    else
                    {
                        Console.WriteLine("Hatalı işlem girdiniz. Lütfen tanımlı işlem giriniz.");
                        System.Threading.Thread.Sleep(1000);
                        goto back3;
                    }
                    break;
                case "2":
                geri1:
                    Console.WriteLine("Lütfen çekmek istediğiniz tutarı giriniz.");
                    double q = Convert.ToDouble(Console.ReadLine());
                    Console.Clear();
                    if (q > bakiye)
                    {
                        Console.WriteLine("Hesabınızda bulunan paradan fazlasını çekemezsiniz.");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        goto geri1;
                    }
                    else if (bakiye >= q)
                    {
                        bakiye -= q;
                        bahis += q;
                        File.WriteAllText(hesapbakiye, Convert.ToString(bakiye));
                        Console.WriteLine(q + " TL hesabınızdan çekilmiştir.Kalan bakiyeniz = " + bakiye + " TL");
                    }
                back4:
                    Console.WriteLine("İşlem başarıyla gerçeklştirildi.Başka işlem yapmak ister misiniz?");
                    Console.WriteLine("1 ) Ana Menü");
                    Console.WriteLine("2 ) Çıkış");
                    int islem1 = Convert.ToInt32(Console.ReadLine());

                    if (islem1 == 1)
                    {
                        Console.WriteLine("Ana menüye dönüyorsunuz.");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        goto geri2;
                    }
                    else if (islem1 == 2)
                    {
                        Console.WriteLine("Çıkış yapıldı.İyi günler dileriz.");
                    }
                    else
                    {
                        Console.WriteLine("Hatalı işlem girdiniz. Lütfen tanımlı işlem giriniz.");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        goto back4;
                    }


                    break;
                case "3":
                back8:
                    Console.WriteLine("Lütfen yatırmak istediğiniz tutarı giriniz");
                    double w = Convert.ToDouble(Console.ReadLine());
                    if (w > bahis)
                    {
                        Console.WriteLine("Lütfen bakiyenizden yüksek işlem yapmayınız.");
                        goto back8;
                    }
                    bahis -= w;
                    bakiye += w;
                    File.WriteAllText(hesapbakiye, Convert.ToString(bakiye));
                    Console.Clear();
                    Console.WriteLine("Başarıyla yüklendi.Yeni bakiyeniz = " + bakiye);
                back5:
                    Console.WriteLine("İşlem başarıyla gerçeklştirildi.Başka işlem yapmak ister misiniz?");
                    Console.WriteLine("1 ) Ana Menü");
                    Console.WriteLine("2 ) Çıkış");
                    int islem2 = Convert.ToInt32(Console.ReadLine());

                    if (islem2 == 1)
                    {
                        Console.WriteLine("Ana menüye dönüyorsunuz.");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        goto geri2;
                    }
                    else if (islem2 == 2)
                    {
                        Console.WriteLine("Çıkış yapıldı.İyi günler dileriz.");
                    }
                    else
                    {
                        Console.WriteLine("Hatalı işlem girdiniz. Lütfen tanımlı işlem giriniz.");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        goto back5;
                    }
                    break;
                case "4":
                    Console.WriteLine("Başarıyla çıkış yapıldı.İyi günler dileriz.");
                    break;
                default:
                    Console.WriteLine("Tanımsız bir işlem girdiniz.Lütfen geçerli bir işlem giriniz");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    goto geri2;
            }
            return bahis;


        }
    }
}