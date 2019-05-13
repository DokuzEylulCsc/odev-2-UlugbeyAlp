using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;

namespace OgrenciBilgiIslem
{
    [Serializable]
    [XmlType(TypeName = "Ogretim Elemanlari")]
    public class OgretimElemanlari
    {
        private string name;
        private string surname;

        public OgretimElemanlari() { }

        [XmlElement("Ogretim Elemani Name")]
        public string Name { get { return name; } set { name = value; } }
        [XmlElement("Ogretim Elemani Surname")]
        public string Surname { get { return surname; } set { surname = value; } }

        public OgretimElemanlari(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }

        public override string ToString()
        {
            return $"Ad:{name} Soyad:{surname}";
        }
    }
    [Serializable]
    [XmlType(TypeName = "OgretimElemanlariMemento")]
    public class OgretimElemanlariMemento
    {
        public string name { get; set; }
        public string surname { get; set; }
    }
    [Serializable]
    [XmlType(TypeName = "OgretimElemanlariMemento")]
    public class OgretimElemanlariMemory
    {
        public OgretimElemanlariMemento OgretimElemanlariKopya { get; set; }
    }
}
