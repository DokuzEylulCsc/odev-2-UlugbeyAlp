using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;

namespace OgrenciBilgiIslem
{
    [Serializable]
    [XmlRoot("Universite")]
    [XmlInclude(typeof(Ders))]
    [XmlInclude(typeof(Sube))]
    [XmlInclude(typeof(OgretimElemanlari))]
    [XmlInclude(typeof(Fakulte))]
    [XmlInclude(typeof(Bolum))]
    [XmlInclude(typeof(Ogrenci))]
    [XmlInclude(typeof(YuksekLisans))]
    [XmlInclude(typeof(Lisans))]
    [XmlInclude(typeof(Doktora))]
    public class Universite
    {
        private string name;
        private List<Fakulte> fakulteler;

        public Universite() { }

        [XmlElement("Universite Name")]
        public string Name { get { return name; } set { name = value; } }

        [XmlArray("Fakulteler")]
        [XmlArrayItem("Fakulte", typeof(Fakulte))]
        public List<Fakulte> Fakulteler { get { return fakulteler; } set { fakulteler = value; } }

        public Fakulte FakulteAra(string name)
        {
            Fakulte f = null;
            foreach (Fakulte a in fakulteler)
            {
                if (String.Equals(a.Name, name))
                {
                    f = a;
                    break;
                }
            }
            if (f == null) { Console.WriteLine("Fakulte Bulunamadi"); }
            return f;
        }

        public Universite(string name)
        {
            this.name = name;
            fakulteler = new List<Fakulte>();
        }

        public void FakulteEkle(string f)
        {
            fakulteler.Add(new Fakulte(f));
        }

        public void FakulteSil(Fakulte f)
        {
            fakulteler.Remove(f);
        }

        public void FakulteleriListele()
        {
            foreach (Fakulte fa in fakulteler)
            {
                Console.WriteLine("Fakulte Listesi:\n");
                Console.WriteLine(fa);
                Console.WriteLine("\n");
            }
        }
    }
}
