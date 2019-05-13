using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;

namespace OgrenciBilgiIslem
{
    [Serializable]
    [XmlType(TypeName = "Ders")]
    public class Ders
    {
        private string name;
        private OgretimElemanlari ogretimElemani;
        private List<Sube> subeler;
        private List<Ogrenci> ogrenciler;

        [XmlArray("Subeler")]
        [XmlArrayItem("Subeler",typeof(Sube))]
        public List<Sube> Subeler { get { return subeler; } set { subeler = value; } }

        [XmlElement("Ders Name")]
        public string Name { get { return name; } set { name = value; } }

        [XmlArray("Ogrenciler")]
        [XmlArrayItem("Ogrenci", typeof(Ogrenci))]
        public List<Ogrenci> Ogrenciler { get { return ogrenciler; } set { ogrenciler = value; } }

        [XmlElement("Ogretim Elemani Name")]
        //public OgretimElemanlari OgretimElemani { get { return ogretimElemani; } set { ogretimElemani = value; } }

        public OgretimElemanlari OgretimElemani { get { return ogretimElemani; } }

        public void OgretimElemaniEkle(OgretimElemanlari o){ ogretimElemani = o; }

        public Ders() { }
        public Ders(string name, int subesayisi)
        {
            this.name = name;
            subeler = new List<Sube>();
            ogrenciler = new List<Ogrenci>();
            ogretimElemani = null;
            int c = 1;
            for (int i = 0; i < subesayisi; i++)
            {
                subeler.Add(new Sube(c));
                c++;
            }
        }
        public void SubeleriListele()
        {
            Console.WriteLine("Bolume Kayitli Ogrenci Listesi:");
            foreach (Sube s in subeler)
            {
                Console.WriteLine(s.ToString());
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
            Console.WriteLine("Derse Kayitli Ogrenci Listesi:\n");
            foreach (Ogrenci o in ogrenciler)
            {
                Console.WriteLine(o.ToString());
                Console.WriteLine("\n");
            }
            //for(int i=0;i<ogrenciler.Count();i++)
            //{
            //    Console.WriteLine(ogrenciler[i].ToString());
            //    Console.WriteLine("\n");
            //}
        }
        public override string ToString()
        {
            return $"{name}";
        }
    }
}
