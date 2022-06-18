/****************************************************************************
**					      SAKARYA UNIVERSITESI
**			     BILGISAYAR VE BILISIM BILIMLERI FAKULTESI
**		             BILGISAYAR MUHENDISLIGI BOLUMU
**			    NESNEYE DAYALI PROGRAMLAMA DERSI BAHAR DONEMİ ODEV2
**
**
**			    	ODEV NUMARASI.... : ODEV2                 en son işlem burda yapıldı....!
**				    OGRENCI ADI.......: BASAK SEKER
**				    OGRENCI NUMARASI..: B211210028
**				    DERS GRUBU........: A
**
**
**
****************************************************************************/




using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ÖDEV2_B211210028
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        TextBox txtSayi = new TextBox();
        Button btn = new Button();
        Label lbl1 = new Label();       //gerekli nesnleri oluşturdum..1 textbox, 3 label, 1button
        Label lbl2 = new Label();
        Label lbl3 = new Label();


        private void Form1_Load(object sender, EventArgs e)
        {

            btn.Text = "HESAPLA"; //butonun adı
            btn.Height = 28; //butonun yüksekliği                                       //HESAPLA butonu için gerekli özellikleri tanımladım
            btn.Width = 112; //genişliği
            btn.Location = new Point(196, 153); //butonun formdaki konumu
            this.Controls.Add(btn); //ve forma butonu ekledim
            btn.Click += new EventHandler(btn_click); //çalışması için  btn_click adına nesne oluşturdum


            lbl1.AutoSize = true;// kendi uzunluğunu otomatik atarlayan özelliği tanımladım..
            lbl1.Text = "FATURA(SAYI İLE)";//label adı
            lbl1.Location = new Point(52, 51);//konumu
            this.Controls.Add(lbl1);//forma ekledim

            lbl2.AutoSize = true;
            lbl2.Text = "FATURA(YAZI İLE)";            //lbl1 aynısı..
            lbl2.Location = new Point(52, 103);
            this.Controls.Add(lbl2);


            lbl3.AutoSize = true;
            lbl3.Text = "______________________________";  //sonucun gösterileceği label
            lbl3.Location = new Point(232, 103);
            this.Controls.Add(lbl3);


            txtSayi.Location = new Point(235, 51);
            txtSayi.Width = 180;
            txtSayi.Height = 23;                      //kullanıcının veri girdiği textbox
            this.Controls.Add(txtSayi);


            this.Font = new Font(this.Font, FontStyle.Bold);  //formdaki tüm yazıları bold yaptım

        }



        private string yaziyaCevir(decimal fatura)  //yazıyaCevir adında method tanımladım
        {
            string sTutar = fatura.ToString("F2").Replace('.', ','); // Replace yöntemi ile string ifade içerisindeki karakterlerin değiştirilmesi sağlanır// kullanıcı ondalık ayracı olarak  . kullanma durumu için            
            string lira = sTutar.Substring(0, sTutar.IndexOf(',')); // kullanıcının girdiği stringte 0'dan ","e kadar olan kısmı arattım..bu tutarın tam kısmı 
            string kurus = sTutar.Substring(sTutar.IndexOf(',') + 1, 2);//stringte ","den bir sonraki 2 kısmı arattım bunda kuruş kısmı..
            string yazi = "";

            int lira_uzunluğu = lira.Length;

            if (lira_uzunluğu > 5)
            {
                MessageBox.Show("EN FAZLA 5 BASAMAKLI SAYI GİREBİLİRSİNİZ.hfhfh.");
                this.Close();
            }


            string[] birler = { "", "BİR", "İKİ", "ÜÇ", "DÖRT", "BEŞ", "ALTI", "YEDİ", "SEKİZ", "DOKUZ" };
            string[] onlar = { "", "ON", "YİRMİ", "OTUZ", "KIRK", "ELLİ", "ALTMIŞ", "YETMİŞ", "SEKSEN", "DOKSAN" };
            string[] binler = { "KATRİLYON", "TRİLYON", "MİLYAR", "MİLYON", "BİN", "" };

            int grupSayisi = 6; //sayıdaki 3'lü grup sayısı. katrilyon içi 6. (1.234,00 daki grup sayısı 2'dir.)


            lira = lira.PadLeft(grupSayisi * 3, '0'); //tam kısmın soluna '0' eklenerek sayı 'grup sayısı x 3' basakmaklı yapılıyor.            

            string grupDegeri;

            for (int i = 0; i < grupSayisi * 3; i += 3) //sayı 3'erli gruplar halinde ele alınıyor.
            {
                grupDegeri = "";

                if (lira.Substring(i, 1) != "0")//ilk eleman 0 değilse
                    grupDegeri += birler[Convert.ToInt32(lira.Substring(i, 1))] + "YÜZ"; //yüzler                

                if (grupDegeri == "BİRYÜZ") //biryüz düzeltiliyor.
                    grupDegeri = "YÜZ";

                grupDegeri += onlar[Convert.ToInt32(lira.Substring(i + 1, 1))]; //onlar

                grupDegeri += birler[Convert.ToInt32(lira.Substring(i + 2, 1))]; //birler                

                if (grupDegeri != "") //binler
                    grupDegeri += binler[i / 3];

                if (grupDegeri == "BİRBİN") //birbin düzeltiliyor.
                    grupDegeri = "BİN";

                yazi += grupDegeri;
            }

            if (yazi != "")//yazı 0 değilse
                yazi += " TL ";//faturayı yazdırdık..

            int yaziUzunlugu = yazi.Length;//yazının uzunluğunu bulduk




            if (kurus.Substring(0, 1) != "0") //kuruş onlar
                yazi += onlar[Convert.ToInt32(kurus.Substring(0, 1))];

            if (kurus.Substring(1, 1) != "0") //kuruş birler
                yazi += birler[Convert.ToInt32(kurus.Substring(1, 1))];

            if (yazi.Length > yaziUzunlugu)
                yazi += " Kr.";
            else
                yazi += "SIFIR Kr.";

            return yazi;
        }


        private void btn_click(object sender, EventArgs e)
        {
            lbl3.Text = yaziyaCevir(Convert.ToDecimal(txtSayi.Text));
        }
    }
}
