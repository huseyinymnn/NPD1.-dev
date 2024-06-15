/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					2021-2022 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........:1.Ödev
**				ÖĞRENCİ ADI............:Hüseyin Yaman
**				ÖĞRENCİ NUMARASI.......:B201210034
**                         DERSİN ALINDIĞI GRUP...:1-A
****************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ndp_odev
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Lutfen olusturmak istediginiz sifreyi giriniz: ");
            string sifre = Console.ReadLine();
            int minimumUzunluk = 9; //minimum uzunluk belirtimiştir.
            char bosluk = ' ';      //boşluk karakterinin kontrol için belirtilmiştir.
            int genelPuan = 0;      //genel puan aldığı şifrenin güvenilirliğini belirleyecek değişkendir. 
            int buyukHarfSayısı = Metotlar.BuyukHarf(sifre);    //büyük harf sayısının tutulduğu değişkendir.
            int kucukHarfSayısı = Metotlar.KucukHarf(sifre);    //küçük harf sayısının tutulduğu değişkendir.       
            int rakamSayısı = Metotlar.Rakam(sifre);            //rakam saysının tutulduğu değişkendir. 
            int ozelKarakterSayısı = Metotlar.OzelKarakter(sifre);      //özel karakter sayısının tutulduğu değişkendir.
            
            
            //boşluk içeriyorsa, 9 karakterden küçükse ve büyük harf/küçük harf/rakam/özel karakter sayısı sıfır ise while döngüsüne girecektir.
            while (sifre.Contains(bosluk) || sifre.Length<minimumUzunluk || Metotlar.BuyukHarf(sifre) == 0 || Metotlar.KucukHarf(sifre) == 0 || Metotlar.Rakam(sifre) == 0 || Metotlar.OzelKarakter(sifre) == 0)
            {
                //boşluk içerdiğini belirtecek olan if bloğu
                if (sifre.Contains(bosluk))
                {
                    Console.WriteLine("Şifreniz boşluk içermemeli!");
                    Console.Write("Lütfen bosluk icermeyen bir sifre giriniz: ");
                    sifre = Console.ReadLine();
                }

                //şifrenin 9 karakterden küçük olduğunu belirtecek olan if bloğu
                if(sifre.Length<minimumUzunluk)
                {
                    Console.WriteLine("Lütfen en az 9 karakter uzunluğuna sahip bir şifre oluşturunuz!");
                    Console.Write("Lütfen oluşturmak istediğiniz şifreyi giriniz: ");
                    sifre = Console.ReadLine();
                }

                //büyük harf/küçük harf/rakam/özel karakter sayılarından herhangi biri sıfır ise bunu belirtecek olan if bloğu
                if (Metotlar.BuyukHarf(sifre) == 0 || Metotlar.KucukHarf(sifre) == 0 || Metotlar.Rakam(sifre) == 0 || Metotlar.OzelKarakter(sifre) == 0)
                {
                    Console.WriteLine("9 karakterden uzun şifrelerde büyük harf / küçük harf / rakam / özel karakter sayılarından herhangi biri sıfır olamaz!");
                    Console.Write("Yeni bir şifre oluşturunuz: ");
                    sifre = Console.ReadLine();

                }
            }

           
            //şifre 9 karakter ve üzerindeyse puanlamanın yapılması için kontrolü sağlayan if bloğu
            if (sifre.Length >= minimumUzunluk)
            { 
                //şifre 9 karaktere eşit ise 10 puan eklenmesini sağlayan if bloğu
                if (sifre.Length == minimumUzunluk)
                {
                    genelPuan += 10;
                }

                //şifredekide büyük harf sayısına verilecek puanı ekleyen for döngüsü
                for (int i = 1; i <= buyukHarfSayısı; i++)
                {
                    //2'den fazla büyük harfe puan verilmemesi for döngüsünden çıkması için  kullanılan  if bloğu
                    if (i == 3)
                    {
                        break;
                    }
                    genelPuan += 10;

                }

                //şifredekide küçük harf sayısına verilecek puanı ekleyen for döngüsü
                for (int j = 1; j <= kucukHarfSayısı; j++)
                {
                    //2'den fazla küçük harfe puan verilmemesi için for döngüsünden çıkması için  kullanılan  if bloğu
                    if (j == 3)
                    {
                        break;
                    }

                    genelPuan += 10;
                }

                //şifredekide rakam sayısına verilecek puanı ekleyen for döngüsü
                for (int k = 1; k <= rakamSayısı; k++)
                {
                    //2'den fazla rakama  puan verilmemesi için for döngüsünden çıkmayı sağlayan   if bloğu
                    if (k == 3)
                    {
                        break;
                    }

                    genelPuan += 10;
                }

                //şifredekide özel karakter sayısına verilecek puanı ekleyen for döngüsü
                for (int m = 1; m <= ozelKarakterSayısı; m++)
                {
                    genelPuan += 10;

                }               
            }
          
            //Puanlamadan sonra genel puan 70'e eşit veya 90'dan küçükse çalışacak if bloğu
            if (genelPuan >= 70 && genelPuan < 90)
            {
                Console.WriteLine("Şifre kabul edildi! Şifrenizin güvenlik puanı: " + genelPuan+ " Şifrenizin içeriği: ");
                Console.WriteLine("Büyük harf sayısı: " + Metotlar.BuyukHarf(sifre));
                Console.WriteLine("Küçük harf sayısı: " + Metotlar.KucukHarf(sifre));
                Console.WriteLine("Rakam sayısı: " + Metotlar.Rakam(sifre));
                Console.WriteLine("Özel karakter sayısı: " + Metotlar.OzelKarakter(sifre));
            }
           
            //Puanlamadan sonra genel puan 90'a eşit veya büyükse çalışacak if bloğu
            else if (genelPuan >= 90)
            {   
                //genel puanın 100'den büyük olması halinde 100 olarak yazdırılmasını sağlayan if bloğu
                if(genelPuan>90)
                { genelPuan = 100;
                }

                Console.WriteLine("Şifreniz kabul edildi ve güçlü! Şifrenizin güvenlik puanı: " + genelPuan+ " Şifrenizin içeriği: ");
                Console.WriteLine("Büyük harf sayısı: " + Metotlar.BuyukHarf(sifre));
                Console.WriteLine("Küçük harf sayısı: " + Metotlar.KucukHarf(sifre));
                Console.WriteLine("Rakam sayısı: " + Metotlar.Rakam(sifre));
                Console.WriteLine("Özel karakter sayısı: " + Metotlar.OzelKarakter(sifre));
            }

            //Puanlamadan sonra genel puan 70'den küçük ise çalışacak while bloğu
            while (genelPuan < 70)
            {
                Console.WriteLine("Şifreniz kabul edilemez! Şifrenizin güvenlik puanı 70'den küçük." + "Şifrenizin içeriği:");
                Console.WriteLine("Büyük harf sayısı: " + Metotlar.BuyukHarf(sifre));
                Console.WriteLine("Küçük harf sayısı: " + Metotlar.KucukHarf(sifre));
                Console.WriteLine("Rakam sayısı: " + Metotlar.Rakam(sifre));
                Console.WriteLine("Özel karakter sayısı: " + Metotlar.OzelKarakter(sifre));
                Console.Write("Yeni bir şifre giriniz: ");
                sifre = Console.ReadLine();
                genelPuan = 0;


                //Yeni oluşturulan şifre boşluk içeriyorsa, 9 karakterden küçükse ve büyük harf/küçük harf/rakam/özel karakter sayısı sıfır ise while döngüsüne girecektir.
                while (sifre.Contains(bosluk) || sifre.Length < minimumUzunluk || Metotlar.BuyukHarf(sifre) == 0 || Metotlar.KucukHarf(sifre) == 0 || Metotlar.Rakam(sifre) == 0 || Metotlar.OzelKarakter(sifre) == 0)
                {
                    //boşluk içerdiğini belirtecek olan if bloğu
                    if (sifre.Contains(bosluk))
                    {
                        Console.WriteLine("Şifreniz boşluk içermemeli!");
                        Console.Write("Lütfen bosluk icermeyen bir sifre giriniz: ");
                        sifre = Console.ReadLine();
                    }

                    //şifrenin 9 karakterden küçük olduğunu belirtecek olan if bloğu
                    if (sifre.Length < minimumUzunluk)
                    {
                        Console.WriteLine("Lütfen en az 9 karakter uzunluğuna sahip bir şifre oluşturunuz!");
                        Console.Write("Lütfen oluşturmak istediğiniz şifreyi giriniz: ");
                        sifre = Console.ReadLine();
                    }

                    //büyük harf/küçük harf/rakam/özel karakter sayılarından herhangi biri sıfır ise bunu belirtecek olan if bloğu
                    if (Metotlar.BuyukHarf(sifre) == 0 || Metotlar.KucukHarf(sifre) == 0 || Metotlar.Rakam(sifre) == 0 || Metotlar.OzelKarakter(sifre) == 0)
                    {
                        Console.WriteLine("9 karakterden uzun şifrelerde büyük harf / küçük harf / rakam / özel karakter sayılarından herhangi biri sıfır olamaz!");
                        Console.Write("Yeni bir şifre oluşturunuz: ");
                        sifre = Console.ReadLine();

                    }
                }

                //şifre 9 karakter ve üzerindeyse puanlamanın yapılması için kontrolü sağlayan if bloğu
                if (sifre.Length >= minimumUzunluk)
                {
                    //şifre 9 karaktere eşit ise 10 puan eklenmesini sağlayan if bloğu
                    if (sifre.Length == minimumUzunluk)
                    {
                        genelPuan += 10;
                    }

                    //şifredekide büyük harf sayısına verilecek puanı ekleyen for döngüsü
                    for (int i = 1; i <= buyukHarfSayısı; i++)
                    {
                        //2'den fazla büyük harfe  puan verilmemesi için for döngüsünden çıkmayı sağlayan   if bloğu
                        if (i == 3)
                        {
                            break;
                        }

                        genelPuan += 10;
                    }

                    //şifredeki küçük harf sayısına verilecek puanı ekleyen for döngüsü
                    for (int j = 1; j <= kucukHarfSayısı; j++)
                    {
                        //2'den fazla küçük harfe  puan verilmemesi için for döngüsünden çıkmayı sağlayan   if bloğu
                        if (j == 3)
                        {
                            break;
                        }
                        genelPuan += 10;

                    }
                    
                    //şifredeki rakam sayısına verilecek puanı ekleyen for döngüsü
                    for (int k = 1; k <= rakamSayısı; k++)
                    {
                        //2'den fazla rakama  puan verilmemesi için for döngüsünden çıkmayı sağlayan   if bloğu
                        if (k == 3)
                        {
                            break;
                        }

                        genelPuan += 10;
                    }

                    //şifredekide özel karakter sayısına verilecek puanı ekleyen for döngüsü
                    for (int m = 1; m <= ozelKarakterSayısı; m++)
                    {
                        genelPuan += 10;
                    }                 
                }

                //Puanlamadan sonra genel puan 70'e eşit veya 90'dan küçükse çalışacak if bloğu
                if (genelPuan >= 70 && genelPuan < 90)
                {
                    Console.WriteLine("Şifre kabul edildi! Şifrenizin güvenlik puanı: " + genelPuan + " Şifrenizin içeriği: ");
                    Console.WriteLine("Büyük harf sayısı: " + Metotlar.BuyukHarf(sifre));
                    Console.WriteLine("Küçük harf sayısı: " + Metotlar.KucukHarf(sifre));
                    Console.WriteLine("Rakam sayısı: " + Metotlar.Rakam(sifre));
                    Console.WriteLine("Özel karakter sayısı: " + Metotlar.OzelKarakter(sifre));
                }

                //Puanlamadan sonra genel puan 90'a eşit veya büyükse çalışacak if bloğu
                else if (genelPuan >= 90)
                {
                    //genel puanın 100'den büyük olması halinde 100 olarak yazdırılmasını sağlayan if bloğu
                    if (genelPuan>90)
                    {
                        genelPuan = 100;
                    }

                    Console.WriteLine("Şifreniz kabul edildi ve güçlü! Şifrenizin güvenlik puanı: " + genelPuan + "Şifrenizin içeriği: ");
                    Console.WriteLine("Büyük harf sayısı: " + Metotlar.BuyukHarf(sifre));
                    Console.WriteLine("Küçük harf sayısı: " + Metotlar.KucukHarf(sifre));
                    Console.WriteLine("Rakam sayısı: " + Metotlar.Rakam(sifre));
                    Console.WriteLine("Özel karakter sayısı: " + Metotlar.OzelKarakter(sifre));
                }

            }

            Console.ReadKey();
        }
    
    }
}

static class Metotlar
{
    public static int BuyukHarf(string s)
    {
        string girilenSifre = s; 
        int buyukHarfSayisi = 0;
        string buyukHarfler = "QWERTYUIOPĞÜASDFGHJKLŞİZXCVBNMÖÇ";
        char[] array = buyukHarfler.ToCharArray();
        
        //şifrenin karakter sayısı kadar dönecek olan for döngüsü
        for (int i = 0; i < girilenSifre.Length; i++)
        {   
            //büyükHarfler dizisinin büyüklüğü kadar dönecek olan for döngüsü
            for (int j = 0; j < array.Length; j++)
                
                //eğer girilenSifre'nin i. karakteri ile buyukHarfler dizisindeki j. karakter aynı ise büyük harf sayısı bir artacaktır.
                if (girilenSifre[i] == array[j])
                {
                    buyukHarfSayisi++;
                }

        }

        return buyukHarfSayisi;
    }

    public static int KucukHarf(string s)
    {
        string girilenSifre = s;
        int kucukHarfSayisi = 0;
        string kucukHarfler = "qwertyuıopğüasdfghjklşizxcvbnmöç";
        char[] kucukharfDizi = kucukHarfler.ToCharArray();

        //şifrenin karakter sayısı kadar dönecek olan for döngüsü
        for (int i = 0; i < girilenSifre.Length; i++)
        {
            //kücükHarfler dizisinin büyüklüğü kadar dönecek olan for döngüsü
            for (int j = 0; j < kucukharfDizi.Length; j++)

                //eğer girilenSifre'nin i. karakteri ile kücükHarfler dizisindeki j. karakter aynı ise küçük harf sayısı bir artacaktır.
                if (girilenSifre[i] == kucukharfDizi[j])
                {
                    kucukHarfSayisi++;
                }

        }
        return kucukHarfSayisi;

    }

    public static int Rakam(string s)
    {
        string girilenSifre = s;
        int rakamSayisi = 0;
        string rakamlar = "0123456789";
        char[] rakamlarDizi = rakamlar.ToCharArray();

        //şifrenin karakter sayısı kadar dönecek olan for döngüsü
        for (int i = 0; i < girilenSifre.Length; i++)
        {
            //rakamlar dizisinin büyüklüğü kadar dönecek olan for döngüsü
            for (int j = 0; j < rakamlarDizi.Length; j++)

                //eğer girilenSifre'nin i. karakteri ile rakamlar dizisindeki j. karakter aynı ise rakam sayısı bir artacaktır.
                if (girilenSifre[i] == rakamlarDizi[j])
                {
                    rakamSayisi++;
                }
        }
        return rakamSayisi;

    }

    public static int OzelKarakter(string s)
    {
        string girilenSifre = s;
        int ozelKarakterSayisi;
        int toplamHarf = girilenSifre.Length;
        ozelKarakterSayisi = toplamHarf - (BuyukHarf(s) + KucukHarf(s) + Rakam(s));

        return ozelKarakterSayisi;
    }

}
