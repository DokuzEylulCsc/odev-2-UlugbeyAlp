using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;

namespace OgrenciBilgiIslem
{
    [Serializable]
    [XmlType(TypeName = "Ogrenci")]
    public abstract class Ogrenci
    {
        protected string name;
        protected string surname;
        protected int no;

        public Ogrenci() { }

        [XmlElement("Ogrenci Name")]
        public string Name { get { return name; } set { name = value; } }
        [XmlElement("Ogrenci Surname")]
        public string Surname { get { return surname; } set { surname = value; } }
        [XmlElement("Ogrenci No")]
        public int No { get { return no; } set { no = value; } }

        public Ogrenci(string name, string surname, int no)
        {
            this.name = name;
            this.surname = surname;
            this.no = no;
        }

        public override string ToString()
        {
            return $"Ad:{name} Soyad:{surname} No:{no}";
        }
    }
}
