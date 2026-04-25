using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace hafta5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool devammi = true;
            while (devammi == true)
        { 
            string DosyaAdi;

            



            Console.WriteLine("Yapmak istediğiniz işlemi seçiniz");
            int islem = Convert.ToInt32(Console.ReadLine());
                if (islem==0)
                {
                    devammi = false;
                    Console.WriteLine("Program Kapatılıyor...");
                    


                }
                else
                    {
                    Console.WriteLine("Dosya Adını Giriniz");
                    DosyaAdi = Console.ReadLine();
                    DosyaAdi += ".txt";

                    switch (islem)
                    {

                        case 1:
                            #region Dosya Oluşturma

                            if (!File.Exists(DosyaAdi))
                            {

                                File.WriteAllText(DosyaAdi, $"{DosyaAdi} Dosyası:");

                            }
                            else
                            {
                                Console.WriteLine("Bu isimde bir dosya zaten var.");
                                Console.WriteLine("Dosyaya ekleme yapmak ister misiniz? (evet/hayır)");

                                if (Console.ReadLine() == "evet")
                                {
                                    Console.WriteLine("Eklencek şeyleri yazınız");
                                    string eklencek = Console.ReadLine();
                                    eklencek = "\n" + eklencek;
                                    File.AppendAllText(DosyaAdi, eklencek);
                                }
                            }
                            #endregion
                            break;
                        case 2:
                            #region Dosya Okuma
                            string dosyaIcerigi;
                            List<string> dosyadakiSatirlar = File.ReadLines(DosyaAdi).ToList();
                            for (int i = 0; i < dosyadakiSatirlar.Count; i++)
                            {
                                Console.WriteLine(dosyadakiSatirlar[i]);
                                Console.WriteLine("---------------------------------------");
                            }
                            #endregion
                            break;
                        case 3:
                            #region Dosya Silme
                            Console.WriteLine("Dosya silinecek, onaylıyor musunuz? (evet/hayır)");
                            string silinsinMi = Console.ReadLine();

                            if ((File.Exists(DosyaAdi)) && (silinsinMi == "evet"))
                            {
                                File.Delete(DosyaAdi);
                            }
                            else
                            {
                                Console.WriteLine("Dosya Yok");
                            }
                                #endregion
                                break;
                        case 4:
                            #region Dosya Yazma(sw)
                            using (StreamWriter swYazici = new StreamWriter(DosyaAdi, true)) //true varsa var olan dosyadakiler silinmeden üstüne yazılır
                            {
                                Console.WriteLine("Metin Gir");
                                string metin = Console.ReadLine();
                                swYazici.WriteLine(metin);
                            }
                            #endregion
                            break;
                        case 5:
                            #region Dosya Okuma(sr)
                            if (File.Exists(DosyaAdi))
                            {
                                using (StreamReader srOku = new StreamReader(DosyaAdi))
                                {
                                    string yazi;
                                    Console.WriteLine("--------------------");
                                    while ((yazi = srOku.ReadLine()) != null)
                                    {

                                        Console.WriteLine($"{yazi}");
                                    }
                                }
                            }
                            else
                            {

                                Console.WriteLine("Dosya Yok");
                            }
                            #endregion
                            break;
                    }
                  }
        }
              

        }
    }
}