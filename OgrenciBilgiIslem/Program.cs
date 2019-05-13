using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;

namespace OgrenciBilgiIslem
{
    class Program
    {
        static void Main(string[] args)
        {
            Uygulama uygulama = new Uygulama();
            uygulama.Basla();
        }
    }
}
