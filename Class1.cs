using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aynı_urunde_adet_artırma
{
    public class Class1
    {
        private int barkod;
        private string urun_ad;
        private int adet;

        public int Barkod { get => barkod; set => barkod = value; }
        public string Urun_ad { get => urun_ad; set => urun_ad = value; }
        public int Adet { get => adet; set => adet = value; }

        public string bilgi()
        {
            return "ürün barkod:" + barkod + " " + "ürün adı:" + urun_ad;
        }
    }
}