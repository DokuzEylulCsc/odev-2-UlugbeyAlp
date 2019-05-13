using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;

namespace OgrenciBilgiIslem
{
    [Serializable]
    [XmlType(TypeName = "Fakulte")]
    public class Fakulte
    {
        protected string name;
        private List<Bolum> bolumler;

        public Fakulte() { }

        [XmlElement("Fakulte Name")]
        public string Name { get { return name; } set { name = value; } }
        [XmlArray("Bolumler")]
        [XmlArrayItem("Bolumler", typeof(Bolum))]
        public List<Bolum> Bolumler { get { return bolumler; } set { bolumler = value; } }

        public Fakulte(string name)
        {
            this.name = name;
            bolumler = new List<Bolum>();
        }
        public void BolumEkle(string b)
        {
            bolumler.Add(new Bolum(b));
        }
        public Bolum BolumAra(string name)
        {
            Bolum o = null;
            foreach (Bolum a in bolumler)
            {
                if (String.Equals(a.Name, name) )
                {
                    o = a;
                    break;
                }
            }
            if (o == null) { Console.WriteLine("Ogrenci Bulunamadi"); }
            return o;
        }
        public void BolumleriListele()
        {
            Console.WriteLine("Fakultedeki Bolumlerin Listesi:");
            foreach (Bolum b in bolumler)
            {
                Console.WriteLine(b.ToString());
            }
        }

        public override string ToString()
        {
            return $"Fakulte Adi: {name}";
        }
    }
}
