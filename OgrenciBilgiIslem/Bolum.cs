using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;

namespace OgrenciBilgiIslem
{
    [Serializable]
    [XmlType(TypeName = "Bolum")]
    public class Bolum
    {
        private string name;
        private List<OgretimElemanlari> ogretimElemanlari;
        private List<Ogrenci> ogrenciler;
        private List<Ders> dersler;

        public Bolum() { }

        [XmlElement("Bolum Name")]
        public string Name { get { return name; } set { name = value; } }

        [XmlArray("Ogrenciler")]
        [XmlArrayItem("Ogrenci", typeof(Ogrenci))]
        public List<Ogrenci> Ogrenciler { get { return ogrenciler; } set { ogrenciler = value; } }

        [XmlArray("Ogretim Elemanlari")]
        [XmlArrayItem("Ogretim Elemanlari", typeof(OgretimElemanlari))]
        public List<OgretimElemanlari> OgretimElemanlari { get { return ogretimElemanlari; } set { ogretimElemanlari = value; } }

        [XmlArray("Dersler")]
        [XmlArrayItem("Ders", typeof(Ders))]
        public List<Ders> Ders { get { return dersler; } set { dersler = value; } }

        public Bolum(string name)
        {
            this.name = name;
            dersler = new List<Ders>();
            ogretimElemanlari = new List<OgretimElemanlari>();
            ogrenciler = new List<Ogrenci>();
        }

        public void DersEkle(string d,int ds)
        {
            dersler.Add(new Ders(d,ds));
        }

        public void DersSil(string d)
        {
            dersler.Remove(DersAra(d));
        }
        public Ders DersAra(string name)
        {
            Ders d = null;
            foreach (Ders a in dersler)
            {
                if (String.Equals(a.Name, name))
                {
                    d = a;
                }
            }
            if (d == null) { Console.WriteLine("Ders Bulunamadi"); }
            return d;
        }
        public void DersleriListele()
        {
            Console.WriteLine("Ders Listesi:\n");
            foreach (Ders d in dersler)
            {
                Console.WriteLine(d);
                Console.WriteLine("\n");
            }
        }

        public Ogrenci OgrenciAra(int no)
        {
            Ogrenci o = null;
            foreach (Ogrenci a in ogrenciler)
            {
                if (a.No == no)
                {
                    o = a;
                    break;
                }
            }
            if (o == null) { Console.WriteLine("Ogrenci Bulunamadi"); }
            return o;
        }

        public Ogrenci OgrenciAra(string name, string surname)
        {
            Ogrenci o = null;
            foreach (Ogrenci a in ogrenciler)
            {
                if (String.Equals(a.Name, name) && String.Equals(a.Surname, surname))
                {
                    o = a;
                    break;
                }
            }
            if (o == null) { Console.WriteLine("Ogrenci Bulunamadi"); }
            return o;
        }

        public void OgrenciEkle(Ogrenci o)
        {
            ogrenciler.Add(o);
        }

        public void OgrenciSil(Ogrenci o)
        {
            ogrenciler.Remove(o);
        }

        public void OgrencileriListele()
        {
            Console.WriteLine("Bolume Kayitli Ogrenci Listesi:\n");
            foreach (Ogrenci o in ogrenciler)
            {
                
                Console.WriteLine(o);
                Console.WriteLine("\n");
            }
        }

        public void OgretimElemaniEkle(string name,string surname)
        {
            ogretimElemanlari.Add(new OgretimElemanlari(name,surname));
        }
        public void OgretimElemaniSil(OgretimElemanlari o)
        {
            ogretimElemanlari.Remove(o);
        }
        public OgretimElemanlari OgretimElemaniAra(string name,string surname)
        {
            OgretimElemanlari o = null;
            foreach(OgretimElemanlari a in ogretimElemanlari)
            {
                if(String.Equals(a.Name,name) && String.Equals(a.Surname,surname))
                    {
                    o = a;
                    }
            }
            return o;
        }
        public void OgretimElemanlariListele()
        {
            Console.WriteLine("Bolume Kayitli Ogretim Elemanlari Listesi:");
            foreach (OgretimElemanlari o in ogretimElemanlari)
            {
                Console.WriteLine(o);
            }
        }
        public override string ToString()
        {
            return $"{name}";
        }
    }
}
