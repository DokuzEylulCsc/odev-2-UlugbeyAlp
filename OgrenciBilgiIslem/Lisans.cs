using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;

namespace OgrenciBilgiIslem
{
    [Serializable]
    public class Lisans:Ogrenci
    {
        public Lisans() { }
        public Lisans(string name, string surname, int no) : base(name,surname,no)
        {

        }
    }
}
