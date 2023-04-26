using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
namespace aynı_urunde_adet_artırma
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
            int miktar=Convert.ToInt32(Interaction.InputBox("kaç adet ürün gireceksiniz"));
            Class1[] urunlerim = new Class1[miktar];
            int sayac = 0;
            for(int i = 0; i< urunlerim.Length; i++)
            {
                int barkodNO = Convert.ToInt32(Interaction.InputBox("barkod no giriniz"));
                bool kontrol = false;
                byte cevap = 0;
                foreach(Class1 urunum in urunlerim)
                {
                    if(urunum != null)
                    {
                        if (urunum.Barkod == barkodNO)
                        {
                            kontrol = true;
                            cevap = Convert.ToByte(Interaction.MsgBox("bu barkod nolu ürün var tekrar barkod girmek ister misiniz",MsgBoxStyle.YesNo));
                            break;
                        }
                    }
                }
                if(kontrol=true && cevap == 6)
                {
                    i--;
                    continue;
                }
                else if(kontrol=true && cevap == 7)
                {
                    i--;
                    foreach(Class1 urunum2 in urunlerim)
                    {
                        if (urunum2.Barkod == barkodNO)
                        {
                            urunum2.Adet++;
                            break;
                        }
                    }
                    continue;
                }
                Class1 yeni_urun = new Class1()
                {
                    Barkod = barkodNO,
                    Urun_ad = Interaction.InputBox("ürün adını giriniz"),
                };
                sayac++;
                urunlerim[i]= yeni_urun;
                byte tmmdv = Convert.ToByte(Interaction.MsgBox("devam etmek istiyor musunuz", MsgBoxStyle.YesNo));
                if (tmmdv == 7) break;
            }
            Array.Resize(ref urunlerim, sayac);
            foreach(Class1 gel_urun in urunlerim)
            {
                if (gel_urun.Adet == 0) ListBox1.Items.Add(gel_urun.bilgi());
                else ListBox1.Items.Add(gel_urun.bilgi() + " "+"ürünün şu anlık adedi" + (gel_urun.Adet + 1));
            }
        }
    }
}