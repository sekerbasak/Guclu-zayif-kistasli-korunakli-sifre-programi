/****************************************************************************
**					      SAKARYA UNIVERSITESI
**			     BILGISAYAR VE BILISIM BILIMLERI FAKULTESI
**		             BILGISAYAR MUHENDISLIGI BOLUMU
**			     PROGRAMLAMAYA GIRIS DERSI BAHAR DONEMİ ODEV1
**
**
**			    	ODEV NUMARASI.... : ODEV1                 en son işlem burda yapıldı....!
**				    OGRENCI ADI.......: BASAK SEKER
**				    OGRENCI NUMARASI..: B211210028
**				    DERS GRUBU........: A
**
**
**
**
**
****************************************************************************/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev1
{
    class Program
    {
        static void Main(string[] args)
        {
            //kullanacağım tanımları yazdım..
            string sifre;
            int sifre_uzunlugu;
            
            bool kontrol = true; // bazı durumların kontrolü  için gerekli.. örneğin space varsa false dönecek..


            Console.WriteLine("\n" + "\n" + "\t" + "\t" + "--------------------ŞİFRE PROGRAMINA HOŞGELDİNİZ------------------");


            do
            {

                int bharf_sayac = 0;
                int kharf_sayac = 0;
                int rakam_sayac = 0;
                int sembol_sayac = 0;
                int puan = 0;


                Console.Write("\n" + "\n" + " En Az 9 Karakterli Ve Boşluk Bulunmayan Şifreyi Girin : ");
                sifre = Console.ReadLine();


                char[] sifre_dizisi = sifre.ToCharArray(); //kullanıcıdan string türünde şifre alındı fakat kontrol için char dizisi gerekli..char dizisine döndürdüm
                sifre_uzunlugu = sifre.Length; //şifre uzunluğunu ".Length" fonksiyonuyla buldum koşullarda kullanacağım zaman pratiklik olacak


                if (sifre_uzunlugu == 9) //şifre tam 9 karakterliyse bunu özel olarak ekrana yazdırmak istedim..güçlülük puanına da +10 puan ekledim..
                {
                    Console.WriteLine("\n" + "     Tam 9 karakterli şifre!!        " + "\n");

                    puan += 10;
                }
                 



                foreach (var karakter in sifre_dizisi) //foreach döngüsüyle sifre_dizizi adlı dizimizi tek tek tarayacağız..
                {
                    if (sifre_uzunlugu < 9)
                    {
                        Console.WriteLine("\n" + "Şifre uzunluğu en az 9 karakterli olmalı..Yeni bir şifre giriniz..");
                       // Console.Clear(); sayaclar sıfırlanmıyordu önce konsol ekranını temizliyim dedim sonra sayaçları içerde tanımlayınca sorunu çözdüm..:) 

                        kontrol = false;
                        break;

                    }
                    else if (karakter == ' ')  //taranan karakter boşluk karakteriyse kontrol false döndürür döngüden çıkar..
                    {
                        Console.WriteLine("\n" + "Şifrede Boşluk Bulunamaz..Lütfen Geçerli Bir Şifre Giriniz.." + "\n");
                       // Console.Clear();

                        kontrol = false;
                        break;

                    }


                    else if (char.IsUpper(karakter)) //eğer karakterimiz büyük harf ise bloğun içine girer..
                    {
                        bharf_sayac++; //büyük harf sayacı 1 artar

                        if (bharf_sayac <= 2 && bharf_sayac > 0) //sayac 0 ile 2 arasında ise bloğun içine girsin. sayac=0 olursa şifrede en az bir büyük harf koşulu sağlanmamış olur..2den büyük olabilir fakat güçlülük puanına etkisi olmaz..
                        {
                            puan += 10;
                        }
                        else
                        {
                            puan += 0;
                        }

                    }



                    else if (char.IsLower(karakter))//eğer karakterimiz küçük harf ise bloğun içine girer..
                    {
                        kharf_sayac++; //küçük harf sayacı 1 artar


                        if (kharf_sayac <= 2 && kharf_sayac > 0) //sayac 0 ile 2 arasında ise bloğun içine girsin. sayac=0 olursa şifrede en az bir küçük harf koşulu sağlanmamış olur..2den büyük olabilir fakat güçlülük puanına etkisi olmaz..
                        {
                            puan += 10;
                        }
                        else
                        {
                            puan += 0;
                        }


                    }

                    else if (char.IsDigit(karakter))//eğer karakterimiz rakam ise bloğun içine girer..
                    {
                        rakam_sayac++;//rakam sayacı 1 artar


                        if (rakam_sayac <= 2 && rakam_sayac > 0) //sayac 0 ile 2 arasında ise bloğun içine girsin. sayac=0 olursa şifrede en az bir rakam koşulu sağlanmamış olur..2den büyük olabilir fakat güçlülük puanına etkisi olmaz..
                        {
                            puan += 10;
                        }
                        else
                        {
                            puan += 0;
                        }

                    }


                    else // if'lerin hiçbiri çalışmazsa demek ki karakter semboldür...bu bloğun içine girer
                    {
                        sembol_sayac++; //sembol sayacı 1 artar
                        puan += 10;//puanı sembol sayısınca 10 puan arttırır..sınırlama yok
                    }



                }


                if (sifre_uzunlugu >= 9 && kontrol == true)//eğer şifre uzunluğu>= 9 ve karakterlerde space karakteri kullanılmamışsa bloğun içine girsin

                {

                    Console.Write("\n" + "Şifredeki Büyük Harf Sayısı: " + bharf_sayac);

                    Console.Write("\n" + "Şifredeki Küçük Harf Sayısı: " + kharf_sayac);        //şifredeki karakterlerin ne olduğunu sayıca ekrana yazdırdım..

                    Console.Write("\n" + "Şifredeki Rakam Sayısı: " + rakam_sayac);

                    Console.Write("\n" + "Şifredeki Sembol Sayısı: " + sembol_sayac + "\n");


                    if (bharf_sayac == 0) //şifrede büyük harf kullanılmamışsa kullanıcıya hatayı belirtip kontrol bool ile döngüden çıkarttım
                    {
                        Console.WriteLine("\n" + "Şifrede en az bir büyük harf olmalıdır..Şifre geçersiz..Tekrar Deneyiniz.." + "\n");
                        Console.ReadLine();
                        break;

                    }
                    if (kharf_sayac == 0)//şifrede küçük harf kullanılmamışsa kullanıcıya hatayı belirtip kontrol bool ile döngüden çıkarttım
                    {
                        Console.WriteLine("\n" + "Şifrede en az bir küçük harf olmalıdır..Şifre geçersiz..Tekrar Deneyiniz.." + "\n");
                        Console.ReadLine();
                        break;

                    }
                    if (rakam_sayac == 0)//şifrede rakam kullanılmamışsa kullanıcıya hatayı belirtip kontrol bool ile döngüden çıkarttım
                    {
                        Console.WriteLine("\n" + "Şifrede en az bir rakam olmalıdır..Şifre geçersiz..Tekrar Deneyiniz.." + "\n");
                        Console.ReadLine();
                        break;

                    }
                    if (sembol_sayac == 0)//şifrede sembol kullanılmamışsa kullanıcıya hatayı belirtip kontrol bool ile döngüden çıkarttım
                    {
                        Console.WriteLine("\n" + "Şifrede en az bir sembol olmalıdır..Şifre geçersiz..Tekrar Deneyiniz.." + "\n");
                        Console.ReadLine();
                        break;

                    }




                    if (!(bharf_sayac == 0) && !(kharf_sayac == 0) && !(rakam_sayac == 0) && !(sembol_sayac == 0))//eğer şifre kurallarına uyulmuşsa bloğun içine girsin..
                    {
                        Console.WriteLine("\n" + "\n" + "Şİfre Güçlüğü Puanı: " + puan); //şifre güçlüğü puanını ekrana yazdırsın

                        if (puan > 90)//şifre puanı 90dan büyükse bildiriyi ekrana yazdırdım
                        {
                            Console.WriteLine("\n" + "ŞİFRENİZ GÜÇLÜ....ŞİFRE BAŞARIYLA OLUŞTURULDU!!");
                            Console.ReadLine();
                            break;
                        }

                        else if (puan >= 70 && puan <= 90)
                        {
                            Console.WriteLine("\n" + "ŞİFRE YETERİNCE GÜVENLİ....ŞİFRE BAŞARIYLA OLUŞTURULDU!!");
                            Console.ReadLine();
                            break;
                        }
                        else if (puan < 70)//burda özel bir durum var...şifre kurallarına uygun olmasına rağmen güç puanı yetersiz olduğu için şifre girin seçeneğine bir daha yönettim kontrol bool ile..
                        {

                            Console.WriteLine("\n" + "ŞİFRENİZ YETERİNCE GÜVENLİ DEĞİL, LÜTFEN YENİ BİR ŞİFRE OLUŞTURUNUZ.." + "\n" + "\n");
                            kontrol = false;


                        }
                    }


                }

            } while (!(sifre_uzunlugu >= 9 & !(kontrol = true)));






        }
    }
}
