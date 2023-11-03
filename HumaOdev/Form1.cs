using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumaOdev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        string islem = null; //Hangi işlemin yapılacağını buraya kaydedeceğiz
        string num = "0"; //Ekranda yazdıracağımız son giridiye sayı ekleyip çıkaracağımız için bu değişkeni "string" türünde tanımlıyoruz
        float num2 = 0; //Üzerinde işlem yapılacak sayıyı kaydedeceğimiz değişkeni oluşturuyoruz
        bool prossesFinish = false; //Yeni girdi olacağı zaman eski işlemin tamamlanıp tamamlanmadığını kaydedeceğimiz değişkeni oluşturuyoruz


        private void prosses(String prs) //İşlem tuşlarının (+,-,*,/) işlevlerini yazıyoruz 
        {
            if(islem != null) //Eğer daha önceki işlem tamamlanmadan yeni işlem yapılması isteniyorsa eski işlemi hesaplıyoruz
            {
                calculate();
                prossesFinish = false; //İşleme devam ettiğimiz için "prossesFinish" değişkenini "False" yapıyoruz
            }
            num2 = float.Parse(num); //Önceki girdiyi "Float" türüne dönüştürüp hafızaya alıyoruz
            num = "0";  //Yeni girdi için son girdiyi kaydettiğimiz değişkeni sıfırlıyoruz
            textBox1.Text = num; //Ekrana yazdırıyoruz
            islem = prs; //Son olarak yapılması istenen işlemi hafızaya kaydediyoruz
        }


        private void addNum(String numI)  //Sayı tuşlarının yapacağı işlemleri bu fonksiyonda yazıyoruz.
        {
            if (prossesFinish) //Eğer daha önce bir işlem tamamlandıysa yeni işlem için son girdiyi temizliyip işlemi sonlandırıyoeuz
            {
                num = "";
                prossesFinish = false;
            }

            if (num == "0") num = "";  //Sayıya sağdan ekleme yapacağımızdan en solda sıfır var ise temizliyoruz 

            num += numI; //Yeni sayıyı sağdan ekliyoruz
            textBox1.Text = num; //Ekrana Yazdırıyoruz
        }

        private void calculate()  //Hesaplamalar için fonksiyon oluşturuyoruz
        {
            float sonuc = 0; //Bir sonuç değişkeni oluşturuyoruz
            bool err = false; //Olası geçersiz işlemlerde daha sonra gerekli işlemleri yapmak için hata olup olmadığını kaydedeceğimiz değişkeni oluşturuyoruz 

            switch (islem)   //Hangi işlemin yapılacağını belirliyor ve işlemi gerçekleştiriyoruz
            {
                case "add":
                    sonuc = float.Parse(num) + num2;
                    break;

                case "sub":
                    sonuc = num2 - float.Parse(num);
                    break;

                case "mult":
                    sonuc = num2 * float.Parse(num);
                    break;

                case "divs":
                    if (float.Parse(num) == 0) // Sıfıra bölme tanımsız olduğundan kullanıcının bu işlemi yapmaya çalışıp çalışmadığını tespit ediyoruz
                    {
                        textBox1.Text = "Tanımsızdır"; //Sıfıra bölme istenmişse ekrana "Tanımsızdır" yazdırıp hata değişkenini "True" duruma alıyoruz
                        err = true; 
                    }
                    else //Sorun yok ise hesaplama yapıyoruz
                        sonuc = num2 / float.Parse(num);
                    break;

            }

            num2 = 0;  //İşi biten verileri sıfırlıyoruz
            islem = null;

            if (err)  num = "0"; //Hata var ise son girşi sıfıra eşitliyerek kısmen uygulamayı sıfırlamış oluyoruz
            else //Hata yok ise:
            {
                num = sonuc.ToString(); //Socun devamından işlem yapılabilmesi için sonucu son girdiye aktarıyoruz
                textBox1.Text = sonuc.ToString(); //Sonucu ekrana yazdırıyoruz           
                prossesFinish = true; //İşlemin tamamlandığı bilgisini ilgili değişkene kaydediyoruz
            }       
        }

        //Butonları işlevlerine yönlendiriyoruz

        private void button12_Click(object sender, EventArgs e)
        {
            calculate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prosses("add");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            prosses("sub");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            prosses("mult");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            prosses("divs");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addNum("7");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            addNum("4");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            addNum("8");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            addNum("9");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            addNum("6");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addNum("5");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            addNum("3");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            addNum("2");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            addNum("1");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            addNum("0");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if(!num.Contains(",")) addNum(",");  //Sayıda başka virgül olmadığını teyit ediyoruz. Var ise işlem yapmıyoruz
        }

        //"C" tuşuna basıldığında son girdiyi (num) sıfırlayıp ekrana yazdırıyoruz.
        private void button17_Click(object sender, EventArgs e)
        {
            num = "0"; 
            textBox1.Text = num;
        }
    }
}
