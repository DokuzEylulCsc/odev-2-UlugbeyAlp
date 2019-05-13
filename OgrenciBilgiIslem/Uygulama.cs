using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace OgrenciBilgiIslem
{
    public class Uygulama
    {
        private Universite uni;
        public void Basla()
        {
            string uniismi;
            Console.WriteLine("Universite ismi giriniz");
            uniismi = Console.ReadLine();
            Console.Clear();
            uni = new Universite(uniismi);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<book genre='programming'> <title>ADO.NET Programming</title> </book>");
            XmlNode root = xmlDoc.DocumentElement;
            Menu();
        }
        public void Menu()
        {
            int choice = -1;
            Console.Clear();
            Console.WriteLine("Menu:\n");
            Console.WriteLine("1.Universiteye fakulte ekle");
            Console.WriteLine("2.Bir fakulteye bolum ekle");
            Console.WriteLine("3.Bir bolume ders ac");
            Console.WriteLine("4.Bir bolumdeki dersi kapat");
            Console.WriteLine("5.Bir bolume ogrenci kaydi yap");
            Console.WriteLine("6.Bir bolumden ogrenci kaydini sil");
            Console.WriteLine("7.Bir bolume ogretim uyesi ata");
            Console.WriteLine("8.Bir bolumden ogretim uyesini sil");
            Console.WriteLine("9.Bir derse ogretim uyesi ata");
            Console.WriteLine("10.Bir dersin ogretim uyesini degistir");
            Console.WriteLine("11.Bir derse ogrenci ekle");
            Console.WriteLine("12.Bir dersten ogrenci sil");
            Console.WriteLine("13.Universiteyi kaydet");
            Console.WriteLine("0.Uygulamadan cik");
            choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch(choice)
            {
                case 0:
                    System.Environment.Exit(0);
                    break;
                case 1:
                    Console.WriteLine("Fakulte ismi giriniz:");
                    string fakulteismi = Console.ReadLine();
                    uni.FakulteEkle(fakulteismi);
                    Console.WriteLine("Menuye donmek icin 1 giriniz");
                    int i1 = Convert.ToInt32(Console.ReadLine());
                    if (i1 == 1) { Menu(); }
                    else { System.Environment.Exit(0); }
                    break;
                case 2:
                    uni.FakulteleriListele();
                    Console.WriteLine("Fakulte seciniz");
                    string fa2 = Console.ReadLine();
                    Console.WriteLine("Bolum ismi giriniz");
                    string bo2 = Console.ReadLine();
                    uni.FakulteAra(fa2).BolumEkle(bo2);
                    Console.WriteLine("Menuye donmek icin 1 giriniz");
                    int i2 = Convert.ToInt32(Console.ReadLine());
                    if (i2 == 1) { Menu(); }
                    else { System.Environment.Exit(0); }
                    break;
                case 3:
                    uni.FakulteleriListele();
                    Console.WriteLine("Fakulte seciniz");
                    string fa3 = Console.ReadLine();
                    uni.FakulteAra(fa3).BolumleriListele();
                    Console.WriteLine("Bolum seciniz");
                    string bo3 = Console.ReadLine();
                    uni.FakulteAra(fa3).BolumAra(bo3).DersleriListele();
                    Console.WriteLine("Ders ismini giriniz");
                    string de3 = Console.ReadLine();
                    Console.WriteLine("Ders sube sayisini giriniz");
                    int ds3 = Convert.ToInt32(Console.ReadLine());
                    uni.FakulteAra(fa3).BolumAra(bo3).DersEkle(de3,ds3);
                    Console.WriteLine("Menuye donmek icin 1 giriniz");
                    int i3 = Convert.ToInt32(Console.ReadLine());
                    if (i3 == 1) { Menu(); }
                    else { System.Environment.Exit(0); }
                    break;
                case 4:
                    uni.FakulteleriListele();
                    Console.WriteLine("Fakulte seciniz");
                    string fa4 = Console.ReadLine();
                    uni.FakulteAra(fa4).BolumleriListele();
                    Console.WriteLine("Bolum seciniz");
                    string bo4 = Console.ReadLine();
                    uni.FakulteAra(fa4).BolumAra(bo4).DersleriListele();
                    Console.WriteLine("Ders ismini giriniz");
                    string de4 = Console.ReadLine();
                    uni.FakulteAra(fa4).BolumAra(bo4).DersSil(de4);
                    Console.WriteLine("Menuye donmek icin 1 giriniz");
                    int i4 = Convert.ToInt32(Console.ReadLine());
                    if (i4 == 1) { Menu(); }
                    else { System.Environment.Exit(0); }
                    break;
                case 5:
                    uni.FakulteleriListele();
                    Ogrenci ogrenci5;
                    Console.WriteLine("Fakulte seciniz");
                    string fa5 = Console.ReadLine();
                    uni.FakulteAra(fa5).BolumleriListele();
                    Console.WriteLine("Bolum seciniz");
                    string bo5 = Console.ReadLine();
                    uni.FakulteAra(fa5).BolumAra(bo5).DersleriListele();
                    uni.FakulteAra(fa5).BolumAra(bo5).OgrencileriListele();
                    Console.WriteLine("Ogrenci ismini giriniz");
                    string ogis5 = Console.ReadLine();
                    Console.WriteLine("Ogrenci soyadini giriniz");
                    string ogso5 = Console.ReadLine();
                    first: Console.WriteLine("Ogrenci Numarasini giriniz");
                    int ogno5 = Convert.ToInt32(Console.ReadLine());
                    if(uni.FakulteAra(fa5).BolumAra(bo5).OgrenciAra(ogno5) != null)
                    {
                        Console.WriteLine("Ayni numarali baska bir ogrenci bulunmaktadir tekrar deneyiniz");
                        goto first;
                    }
                    Console.WriteLine("Ogrencinin seviyesini giriniz:\n1.Lisans 2.Yuksek Lisans 3.Doktora");
                    int sevi = Convert.ToInt32(Console.ReadLine());
                    if(sevi==2)
                    {
                        ogrenci5 = new YuksekLisans(ogis5, ogso5, ogno5);
                    }
                    else if(sevi==3)
                    {
                        ogrenci5 = new Doktora(ogis5, ogso5, ogno5);
                    }
                    else
                    {
                        ogrenci5 = new Lisans(ogis5, ogso5, ogno5);
                    }
                    uni.FakulteAra(fa5).BolumAra(bo5).OgrenciEkle(ogrenci5);
                    Console.WriteLine("\nMenuye donmek icin 1 giriniz");
                    int i5 = Convert.ToInt32(Console.ReadLine());
                    if (i5 == 1) { Menu(); }
                    else { System.Environment.Exit(0); }
                    break;
                case 6:
                    uni.FakulteleriListele();
                    Ogrenci ogrenci6;
                    Console.WriteLine("Fakulte seciniz");
                    string fa6 = Console.ReadLine();
                    uni.FakulteAra(fa6).BolumleriListele();
                    Console.WriteLine("Bolum seciniz");
                    string bo6 = Console.ReadLine();
                    uni.FakulteAra(fa6).BolumAra(bo6).DersleriListele();
                    uni.FakulteAra(fa6).BolumAra(bo6).OgrencileriListele();
                    Console.WriteLine("Menu:\n1.Ogrenciyi isim ve soyisim kullanarak silmek\n2.Ogrenciyi numarasini kullanarak silmek");
                    int c6 = Convert.ToInt32(Console.ReadLine());
                    if(c6==1)
                    {
                        Console.WriteLine("Ogrenci ismini giriniz");
                        string ogis6 = Console.ReadLine();
                        Console.WriteLine("Ogrenci soyadini giriniz");
                        string ogso6 = Console.ReadLine();
                        ogrenci6 = uni.FakulteAra(fa6).BolumAra(bo6).OgrenciAra(ogis6, ogso6);
                        uni.FakulteAra(fa6).BolumAra(bo6).OgrenciSil(ogrenci6);
                    }
                    else if(c6==2)
                    {
                        Console.WriteLine("Ogrenci Numarasini giriniz");
                        int ogno6 = Convert.ToInt32(Console.ReadLine());
                        ogrenci6 = uni.FakulteAra(fa6).BolumAra(bo6).OgrenciAra(ogno6);
                        uni.FakulteAra(fa6).BolumAra(bo6).OgrenciSil(ogrenci6);
                    }
                    Console.WriteLine("\nMenuye donmek icin 1 giriniz");
                    int i6 = Convert.ToInt32(Console.ReadLine());
                    if (i6 == 1) { Menu(); }
                    else { System.Environment.Exit(0); }
                    break;
                case 7:
                    uni.FakulteleriListele();
                    Console.WriteLine("Fakulte seciniz");
                    string fa7 = Console.ReadLine();
                    uni.FakulteAra(fa7).BolumleriListele();
                    Console.WriteLine("Bolum seciniz");
                    string bo7 = Console.ReadLine();
                    Console.WriteLine("Ogretim uyesi ismi seciniz");
                    string ois7 = Console.ReadLine();
                    Console.WriteLine("Ogretim uyesi soyadi seciniz");
                    string oso7 = Console.ReadLine();
                    uni.FakulteAra(fa7).BolumAra(bo7).OgretimElemaniEkle(ois7,oso7);
                    Console.WriteLine("\nMenuye donmek icin 1 giriniz");
                    int i7 = Convert.ToInt32(Console.ReadLine());
                    if (i7 == 1) { Menu(); }
                    else { System.Environment.Exit(0); }
                    break;
                case 8:
                    uni.FakulteleriListele();
                    OgretimElemanlari oge8;
                    Console.WriteLine("Fakulte seciniz");
                    string fa8 = Console.ReadLine();
                    uni.FakulteAra(fa8).BolumleriListele();
                    Console.WriteLine("Bolum seciniz");
                    string bo8 = Console.ReadLine();
                    Console.WriteLine("Ogretim uyesi ismi seciniz");
                    string ois8 = Console.ReadLine();
                    Console.WriteLine("Ogretim uyesi soyadi seciniz");
                    string oso8 = Console.ReadLine();
                    oge8 = uni.FakulteAra(fa8).BolumAra(bo8).OgretimElemaniAra(ois8, oso8);
                    uni.FakulteAra(fa8).BolumAra(bo8).OgretimElemaniSil(oge8);
                    Console.WriteLine("\nMenuye donmek icin 1 giriniz");
                    int i8 = Convert.ToInt32(Console.ReadLine());
                    if (i8 == 1) { Menu(); }
                    else { System.Environment.Exit(0); }
                    break;
                case 9:
                    uni.FakulteleriListele();
                    OgretimElemanlari oge9;
                    Console.WriteLine("Fakulte seciniz");
                    string fa9 = Console.ReadLine();
                    uni.FakulteAra(fa9).BolumleriListele();
                    Console.WriteLine("Bolum seciniz");
                    string bo9 = Console.ReadLine();
                    uni.FakulteAra(fa9).BolumAra(bo9).DersleriListele();
                    Console.WriteLine("Ders seciniz");
                    string de9 = Console.ReadLine();
                    Console.WriteLine("Ogretim uyesi ismi giriniz");
                    string ois9 = Console.ReadLine();
                    Console.WriteLine("Ogretim uyesi soyadi giriniz");
                    string oso9 = Console.ReadLine();
                    oge9 = uni.FakulteAra(fa9).BolumAra(bo9).OgretimElemaniAra(ois9, oso9);
                    uni.FakulteAra(fa9).BolumAra(bo9).DersAra(de9).OgretimElemaniEkle(oge9);
                    Console.WriteLine("\nMenuye donmek icin 1 giriniz");
                    int i9 = Convert.ToInt32(Console.ReadLine());
                    if (i9 == 1) { Menu(); }
                    else { System.Environment.Exit(0); }
                    break;
                case 10:
                    uni.FakulteleriListele();
                    OgretimElemanlari oge10;
                    Console.WriteLine("Fakulte seciniz");
                    string fa10 = Console.ReadLine();
                    uni.FakulteAra(fa10).BolumleriListele();
                    Console.WriteLine("Bolum seciniz");
                    string bo10 = Console.ReadLine();
                    uni.FakulteAra(fa10).BolumAra(bo10).DersleriListele();
                    Console.WriteLine("Ders seciniz");
                    string de10 = Console.ReadLine();
                    Console.WriteLine("Ogretim uyesi ismi giriniz");
                    string ois10 = Console.ReadLine();
                    Console.WriteLine("Ogretim uyesi soyadi giriniz");
                    string oso10 = Console.ReadLine();
                    oge10 = uni.FakulteAra(fa10).BolumAra(bo10).OgretimElemaniAra(ois10, oso10);
                    uni.FakulteAra(fa10).BolumAra(bo10).DersAra(de10).OgretimElemaniEkle(oge10);
                    Console.WriteLine("\nMenuye donmek icin 1 giriniz");
                    int i10 = Convert.ToInt32(Console.ReadLine());
                    if (i10 == 1) { Menu(); }
                    else { System.Environment.Exit(0); }
                    break;
                case 11:
                    uni.FakulteleriListele();
                    Ogrenci ogrenci11;
                    Console.WriteLine("Fakulte seciniz");
                    string fa11 = Console.ReadLine();
                    uni.FakulteAra(fa11).BolumleriListele();
                    Console.WriteLine("Bolum seciniz");
                    string bo11 = Console.ReadLine();
                    uni.FakulteAra(fa11).BolumAra(bo11).DersleriListele();
                    Console.WriteLine("Ders seciniz");
                    string de11 = Console.ReadLine();
                    
                    Console.WriteLine("Ogrenci ismini giriniz");
                    string ogis11 = Console.ReadLine();
                    Console.WriteLine("Ogrenci soyadini giriniz");
                    string ogso11 = Console.ReadLine();
                    second: Console.WriteLine("Ogrenci Numarasini giriniz");
                    int ogno11 = Convert.ToInt32(Console.ReadLine());
                    if (uni.FakulteAra(fa11).BolumAra(bo11).DersAra(de11).OgrenciAra(ogno11) != null)
                    {
                        Console.WriteLine("Ayni numarali baska bir ogrenci bulunmaktadir tekrar deneyiniz");
                        goto second;
                    }
                    Console.WriteLine("Ogrencinin subesini giriniz");
                    int sube11 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ogrencinin seviyesini giriniz:\n1.Lisans 2.Yuksek Lisans 3.Doktora");
                    int sevi11 = Convert.ToInt32(Console.ReadLine());
                    if (sevi11 == 2)
                    {
                        ogrenci11 = new YuksekLisans(ogis11, ogso11, ogno11);
                    }
                    else if (sevi11 == 3)
                    {
                        ogrenci11 = new Doktora(ogis11, ogso11, ogno11);
                    }
                    else
                    {
                        ogrenci11 = new Lisans(ogis11, ogso11, ogno11);
                    }
                    uni.FakulteAra(fa11).BolumAra(bo11).DersAra(de11).OgrenciEkle(ogrenci11);
                    uni.FakulteAra(fa11).BolumAra(bo11).DersAra(de11).OgrencileriListele();
                    Console.WriteLine("\nMenuye donmek icin 1 giriniz");
                    int i11 = Convert.ToInt32(Console.ReadLine());
                    if (i11 == 1) { Menu(); }
                    else { System.Environment.Exit(0); }
                    break;
                case 12:
                    uni.FakulteleriListele();
                    Ogrenci ogrenci12;
                    Console.WriteLine("Fakulte seciniz");
                    string fa12 = Console.ReadLine();
                    uni.FakulteAra(fa12).BolumleriListele();
                    Console.WriteLine("Bolum seciniz");
                    string bo12 = Console.ReadLine();
                    uni.FakulteAra(fa12).BolumAra(bo12).DersleriListele();
                    Console.WriteLine("Ders seciniz");
                    string de12 = Console.ReadLine();
                    uni.FakulteAra(fa12).BolumAra(bo12).DersAra(de12).OgrencileriListele();
                    Console.WriteLine("Menu:\n1.Ogrenciyi isim ve soyisim kullanarak silmek\n2.Ogrenciyi numarasini kullanarak silmek");
                    int c12 = Convert.ToInt32(Console.ReadLine());
                    if (c12 == 1)
                    {
                        Console.WriteLine("Ogrenci ismini giriniz");
                        string ogis12 = Console.ReadLine();
                        Console.WriteLine("Ogrenci soyadini giriniz");
                        string ogso12 = Console.ReadLine();
                        ogrenci12 = uni.FakulteAra(fa12).BolumAra(bo12).DersAra(de12).OgrenciAra(ogis12, ogso12);
                        uni.FakulteAra(fa12).BolumAra(bo12).DersAra(de12).OgrenciSil(ogrenci12);
                    }
                    else if (c12 == 2)
                    {
                        Console.WriteLine("Ogrenci Numarasini giriniz");
                        int ogno12 = Convert.ToInt32(Console.ReadLine());
                        ogrenci12 = uni.FakulteAra(fa12).BolumAra(bo12).DersAra(de12).OgrenciAra(ogno12);
                        uni.FakulteAra(fa12).BolumAra(bo12).DersAra(de12).OgrenciSil(ogrenci12);
                    }
                    Console.WriteLine("\nMenuye donmek icin 1 giriniz");
                    int i12 = Convert.ToInt32(Console.ReadLine());
                    if (i12 == 1) { Menu(); }
                    else { System.Environment.Exit(0); }
                    break;
                case 13:
                    Deserialize();
                    Serialize(uni);
                    Console.WriteLine("\nMenuye donmek icin 1 giriniz");
                    int i13 = Convert.ToInt32(Console.ReadLine());
                    if (i13 == 1) { Menu(); }
                    else { System.Environment.Exit(0); }
                    break;
                default:
                    Console.WriteLine("Yanlış sayi girdiniz tekrar deneyin");
                    Menu();
                    break;
            }
        }
        static void Serialize(Universite deu)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(Universite));

            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, deu);
                    xml = sww.ToString();
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.LoadXml(xml);
                    xdoc.Save("universite.xml");
                }

            }
        }

        static Universite Deserialize()
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(Universite));
            Universite deu = null;
            string path = "universite.xml";
            using (StreamReader reader = new StreamReader(path))
            {
                deu = (Universite)xsSubmit.Deserialize(reader);

            }
            return deu;
        }
    }
}
