using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;

namespace OgrenciBilgiIslem
{
    [Serializable]
    [XmlType(TypeName = "Sube")]
    public class Sube
    {
        private int name;
        private List<Ogrenci> ogrenciler;

        public Sube() { }

        [XmlElement("Sube Name")]
        public int Name { get { return name; } set { name = value; } }

        [XmlArray("Ogrenciler")]
        [XmlArrayItem("Ogrenci", typeof(Ogrenci))]
        public List<Ogrenci> Ogrenciler { get { return ogrenciler; } set { ogrenciler = value; } }

        public Sube(int name)
        {
            this.name = name;
            ogrenciler = new List<Ogrenci>();
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
            Console.WriteLine("Bolume Kayitli Ogrenci Listesi:");
            foreach (Ogrenci o in ogrenciler)
            {
                Console.WriteLine(o.ToString());
            }
        }
        public override string ToString()
        {
            return $"{name}";
        }
    }
}
